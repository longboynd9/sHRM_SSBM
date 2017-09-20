using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using iHRM.Core.Business;
using System.Data.SqlClient;

namespace iHRM.WebPC.Cpanel.News
{
    public partial class Default : BackEndPageBase
    {
        global::iHRM.Core.Business.Logic.News.DanhMucBaiViet logicDM = new global::iHRM.Core.Business.Logic.News.DanhMucBaiViet();
        global::iHRM.Core.Business.Logic.News.BaiViet logic = new global::iHRM.Core.Business.Logic.News.BaiViet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cbostatus.Items.AddRange(Enums.eStatus_Alias.Select(i => new Ext.Net.ListItem(i.Value, ((int)i.Key).ToString())));
                loadDmTin();
                X.AddScript("ar = { " + string.Join(",", Enums.eStatus_Alias.Select(i => string.Format("k{0}: '{1}'", (int)i.Key, i.Value))) + " }");
            }
        }

        void loadDmTin()
        {
            var dt = logicDM.GetAll();
            var itemR = dt.Select("parentID is NULL").FirstOrDefault();
            cbodanhmuc.Items.Clear();
            LoadDM(DbHelper.DrGetGuid(itemR, "idDanhMucBV"), dt, "");
        }
        private void LoadDM(Guid? parentid, System.Data.DataTable dt, string space)
        {
            var lst2 = dt.Select("parentID='" + parentid + "'").OrderBy(i => i["displayOrder"]);
            foreach (var item in lst2)
            {
                cbodanhmuc.Items.Add(new Ext.Net.ListItem(space + DbHelper.DrGetString(item, "ten"), DbHelper.DrGetString(item, "idDanhMucBV")));
                LoadDM(DbHelper.DrGetGuid(item, "idDanhMucBV"), dt, space + "---");
            }
        }

        protected void Store1_OnRefresh(object sender, StoreRefreshDataEventArgs e)
        {
            logic.VirtualPaging.PageSize = e.Limit;
            logic.VirtualPaging.Page = (int)(e.Start / e.Limit) + 1;

            var dt = logic.GetAll(
                            new SqlParameter("SearchKey", txtSearch.Text),
                            new SqlParameter("idDanhMuc", cbodanhmuc.Value),
                            new SqlParameter("status_filter", cbostatus.Value)
                        );
            dt.Columns.Add("linklink");
            foreach (System.Data.DataRow dr in dt.Rows)
                dr["linklink"] = UrlRewrite.Gen_BaiViet(dr);
            Store1.DataSource = dt;
            Store1.DataBind();

            e.Total = logic.VirtualPaging.RecordCount;

            (this.Store1.Proxy[0] as PageProxy).Total = logic.VirtualPaging.RecordCount;
        }

        /// <summary>
        /// sự kiện command trong gridpanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnCommand(object sender, DirectEventArgs e)
        {
            try
            {
                string commandId = e.ExtraParams["id"];
                string commandName = e.ExtraParams["command"];

                switch (commandName)
                {
                    case "Edit":
                        X.AddScript("OpenEditor('" + commandId + "', 'Cập nhật bài viết')");
                        break;
                    case "Delete":
                        DeleteRecord(commandId);
                        break;
                }
            }
            catch
            {
                if (globall.indebug)
                    throw;
            }
        }

        void DeleteRecord(string id)
        {
            try
            {
                if (logic.Delete(logic.GetById(new Guid(id))))
                {
                    Tools.messageConfirmSuccess(Lng.common_msg.Delete_Success);
                    //LoadData();
                    X.AddScript("Store1.remove(Store1.getById('" + id + "'));");
                }
                else
                {
                    Tools.messageConfirmErr(Lng.common_msg.Delete_Fail);
                }
            }
            catch (Exception ex)
            {
                if (globall.indebug)
                    throw;

                Tools.messageConfirmErr(string.Format(Lng.common_msg.Error_While_Exec, ex.Message));
                return;
            }
        }

    }
}