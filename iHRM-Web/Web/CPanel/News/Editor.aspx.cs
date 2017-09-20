using Ext.Net;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iHRM.Core.Business;
using System.Data;

namespace iHRM.WebPC.Cpanel.News
{
    public partial class Editor : System.Web.UI.Page
    {
        global::iHRM.Core.Business.Logic.News.DanhMucBaiViet logicDM = new global::iHRM.Core.Business.Logic.News.DanhMucBaiViet();
        global::iHRM.Core.Business.Logic.News.BaiViet logic = new global::iHRM.Core.Business.Logic.News.BaiViet();
        protected void Page_Load(object sender, EventArgs e)
        {
            loadDmTin();

            cbostatus.Items.AddRange(Enums.eStatus_Alias.Select(i => new Ext.Net.ListItem(i.Value, ((int)i.Key).ToString())));

            if (!IsPostBack)
            {
                cbostatus.SelectedItem.Value = Convert.ToString((int)Enums.eStatus.KichHoat);


                Guid? id = null;
                DataRow item = null;

                if (Request["id"] == null)
                {
                    id = createNew();
                }
                else
                {
                    id = new Guid(Request["id"]);
                    if (id != null)
                    {
                        item = logic.GetById(id.Value);

                        if (item == null)
                        {
                            id = createNew();
                            if (id != null)
                                item = logic.GetById(id.Value);
                        }
                    }
                }

                if (id != null)
                {
                    hId.Value = DbHelper.DrGet(item, "idBaiViet");
                    if (!string.IsNullOrWhiteSpace(DbHelper.DrGetString(item, "anhDaiDien")))
                        ImageUploader1.imgUrl = "/" + web_globall.uploadFolder + DbHelper.DrGetString(item, "anhDaiDien");
                    txtcode.Text = DbHelper.DrGetString(item, "maBV");
                    txttitle.Text = DbHelper.DrGetString(item, "tieude");
                    txttitle_EN.Text = DbHelper.DrGetString(item, "tieude_EN");
                    txttitle_KR.Text = DbHelper.DrGetString(item, "tieude_KR");
                    CKEditor3.Text = DbHelper.DrGetString(item, "gioithieu");
                    CKEditor4.Text = DbHelper.DrGetString(item, "gioithieu_EN");
                    CKEditor4_2.Text = DbHelper.DrGetString(item, "gioithieu_KR");
                    cmbcategoryId.Value = DbHelper.DrGetString(item, "idDanhMuc");

                    CKEditor1.Text = DbHelper.DrGetString(item, "noidung");
                    CKEditor2.Text = DbHelper.DrGetString(item, "noidung_EN");
                    CKEditor2_2.Text = DbHelper.DrGetString(item, "noidung_KR");
                    txtOrder.Value = DbHelper.DrGet(item, "sapxep");
                    txtTag.Text = DbHelper.DrGetString(item, "tags");
                    cbostatus.SelectedItem.Value = DbHelper.DrGetString(item, "status");

                }
            }
        }

        Guid? createNew()
        {
            Guid? id = null;
            if (Request["catid"] != null)
            {
                id = Guid.NewGuid();
                logic.CreateNew(id);
                logic.UpdateIdBv4DanhMucBaiViet(new Guid(Request["catid"]), id.Value);
            }

            return id;
        }



        void loadDmTin()
        {
            var dt = logicDM.GetAll();
            var itemR = dt.Select("parentID is NULL").FirstOrDefault();
            cmbcategoryId.Items.Clear();
            LoadDM(DbHelper.DrGetGuid(itemR, "idDanhMucBV"), dt, "");
        }
        private void LoadDM(Guid? parentid, System.Data.DataTable dt, string space)
        {
            var lst2 = dt.Select("parentID='" + parentid + "'").OrderBy(i => i["displayOrder"]);
            foreach (var item in lst2)
            {
                cmbcategoryId.Items.Add(new Ext.Net.ListItem(space + DbHelper.DrGetString(item, "ten"), DbHelper.DrGetString(item, "idDanhMucBV")));
                LoadDM(DbHelper.DrGetGuid(item, "idDanhMucBV"), dt, space + "---");
            }
        }

        void getFormData(DataRow item)
        {
            if (ImageUploader1.hasFile)
            {
                if (!string.IsNullOrWhiteSpace(item["anhDaiDien"] as string))
                {
                    try
                    {
                        System.IO.File.Delete(Server.MapPath("~/" + web_globall.uploadFolder + item["anhDaiDien"]));
                    }
                    catch { }
                }
                item["anhDaiDien"] = ImageUploader1.save("/" + web_globall.uploadFolder + "/BaiViet").Replace("/" + web_globall.uploadFolder, "");
            }

            item["maBV"] = txtcode.Text;
            item["tieude"] = txttitle.Text;
            item["tieude_EN"] = txttitle_EN.Text;
            item["tieude_KR"] = txttitle_KR.Text;
            item["gioithieu"] = CKEditor3.Text;
            item["gioithieu_EN"] = CKEditor4.Text;
            item["gioithieu_KR"] = CKEditor4_2.Text;
            item["idDanhMuc"] = cmbcategoryId.Value ?? DBNull.Value;

            item["noidung"] = CKEditor1.Text;
            item["noidung_EN"] = CKEditor2.Text;
            item["noidung_KR"] = CKEditor2_2.Text;
            item["sapxep"] = txtOrder.Value ?? 0;
            item["tags"] = txtTag.Text;
            item["status"] = cbostatus.SelectedItem.Value;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(hId.Value as string))
                {
                    var item = global::iHRM.Core.Business.Logic.AllLogic.GetSchema("tbBaiViet").NewRow();
                    getFormData(item);
                    item["idBaiViet"] = logic.InsertOrUpdate(item);

                    if (DbHelper.DrGet(item, "idBaiViet") != null)
                    {
                        Tools.messageConfirmSuccess(Lng.common_msg.Add_Success);
                        txttitle.Text = "";
                        CKEditor1.Text = CKEditor2.Text = CKEditor3.Text = CKEditor4.Text = "";
                    }
                    else
                    {
                        Tools.messageConfirmSuccess(Lng.common_msg.Add_Success);
                    }
                }
                else
                {
                    var item = logic.GetById(new Guid(hId.Value as string));
                    getFormData(item);
                    item["idBaiViet"] = logic.InsertOrUpdate(item);

                    if (DbHelper.DrGet(item, "idBaiViet") != null)
                    {
                        Tools.messageConfirmSuccess(Lng.common_msg.Edit_Success);
                    }
                    else
                    {
                        Tools.messageConfirmSuccess(Lng.common_msg.Edit_Fail);
                    }
                }
            }
            catch (Exception ex)
            {
                Tools.messageConfirmErr(string.Format(Lng.common_msg.Error_While_Exec, ex));
            }
        }

    }
}