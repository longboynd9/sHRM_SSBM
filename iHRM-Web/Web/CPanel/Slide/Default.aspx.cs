using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using System.Data;
using iHRM.Core.Business;
using iHRM.Core.Business.Logic;

namespace iHRM.WebPC.Cpanel.Slide
{
    public partial class Default : BackEndPageBase
    {
        global::iHRM.Core.Business.Logic.Slide.Slide Logic = new global::iHRM.Core.Business.Logic.Slide.Slide();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cbostatus.Items.AddRange(Enums.eStatus_Alias.Select(i => new Ext.Net.ListItem(i.Value, ((int)i.Key).ToString())));
                cbostatus.SelectedItem.Value =Convert.ToString((int)Enums.eStatus.KichHoat);
                LoadData();
            }
        }

        void LoadData()
        {
            stoCategory.DataSource = Logic.GetCategory();
            stoCategory.DataBind();

            Store1_OnRefresh(null, null);
        }
        protected void Store1_OnRefresh(object sender, StoreRefreshDataEventArgs e)
        {
            Store1.DataSource = Logic.GetAll();
            Store1.DataBind();
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
                        EditRecord(commandId);
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

        void EditRecord(string id)
        {
            DataRow item = Logic.GetById(new Guid(id));
            if (item == null)
            {
                Tools.messageConfirmErr(Lng.common_msg.RecordNotFound);
                return;
            }
            else
            {
                hId.Value = DbHelper.DrGet(item, "id");
                txtcaption.Text = DbHelper.DrGetString(item, "title");
                txtghichu.Text = DbHelper.DrGetString(item, "desciption");
                txtcaption_EN.Text = DbHelper.DrGetString(item, "title_EN");
                txtghichu_EN.Text = DbHelper.DrGetString(item, "desciption_EN");
                txtcaption_KR.Text = DbHelper.DrGetString(item, "title_KR");
                txtghichu_KR.Text = DbHelper.DrGetString(item, "desciption_KR");
                txtlink.Text = DbHelper.DrGetString(item, "link");
                txtOrder.Value = DbHelper.DrGet(item, "displayOrder");
                cbovitri.SelectedItem.Value = DbHelper.DrGetString(item, "category");
                ImageUploader1.imgUrl = "/" + web_globall.uploadFolder + DbHelper.DrGetString(item, "image");
                cbostatus.SelectedItem.Value = DbHelper.DrGetString(item, "status");

                btnClear.Hidden = true;
                wEditor.Show();
            }
        }
        void DeleteRecord(string id)
        {
            try
            {
                DataRow item = Logic.GetById(new Guid(id));
                if (!string.IsNullOrWhiteSpace(DbHelper.DrGetString(item, "anh")))
                {
                    try
                    {
                        System.IO.File.Delete(Server.MapPath(DbHelper.DrGetString(item, "anh")));
                    }
                    catch { }
                }

                Logic.Delete(item);

                Tools.messageConfirmSuccess(Lng.common_msg.Delete_Success);
                LoadData();
                //X.AddScript("Store1.remove(Store1.getById('" + item.id + "'));");
            }
            catch (Exception ex)
            {
                if (globall.indebug)
                    throw;

                Tools.messageConfirmErr(string.Format(Lng.common_msg.Error_While_Exec, ex.Message));
                return;
            }
        }
      

        /// <summary>
        /// Double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnDblClick(object sender, DirectEventArgs e)
        {
            try
            {
                EditRecord(e.ExtraParams["id"]);
            }
            catch (Exception ex)
            {
                if (globall.indebug)
                    throw;

                Tools.message(string.Format(Lng.common_msg.Error_While_Exec, ex.Message));
                return;
            }
        }

        protected void btnAdd_DirectClick(object sender, DirectEventArgs e)
        {
            formCT.Reset();
            hId.Value = "";
            btnClear.Hidden = false;
            wEditor.Show();
        }

        protected void btnSearch_DirectClick(object sender, DirectEventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Trim(' ', '\t');
            LoadData();
        }

        void getEditorValue(DataRow f)
        {
            f["title"] = txtcaption.Text;
            f["desciption"] = txtghichu.Text;
            f["title_EN"] = txtcaption_EN.Text;
            f["desciption_EN"] = txtghichu_EN.Text;
            f["title_KR"] = txtcaption_KR.Text;
            f["desciption_KR"] = txtghichu_KR.Text;
            f["link"] = txtlink.Text;
            f["category"] = cbovitri.Value;
            f["displayOrder"] = (int)((double?)txtOrder.Value ?? 0);
            if (ImageUploader1.hasFile)
            {
                if (!string.IsNullOrWhiteSpace(f["image"] as string))
                {
                    try
                    {
                        System.IO.File.Delete(Server.MapPath("~/" + web_globall.uploadFolder + f["image"]));
                    }
                    catch { }
                }
                f["image"] = ImageUploader1.save("/" + web_globall.uploadFolder + "/slide").Replace("/" + web_globall.uploadFolder, "");
            }
            f["status"] = int.Parse(cbostatus.SelectedItem.Value);
        }

        protected void btnOk_DirectClick(object sender, DirectEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(hId.Value.ToString())) //add
            {
                DataRow f = AllLogic.GetSchema("tbSlide").NewRow();
                if (!ImageUploader1.hasFile)
                {
                    Tools.message("Chưa chọn ảnh");
                    return;
                }

                getEditorValue(f);

                try
                {
                    Logic.InsertOrUpdate(f);

                    Tools.message("Add success");
                    LoadData();
                    formCT.Reset();
                }
                catch
                {
                    //Tools.message("Has error while adding, please try again later...");
                    Tools.message("Lỗi trong quá trình thêm mới, vui lòng thử lại sau...");
                }
            }

            else
            {
                 DataRow f = Logic.GetById(new Guid(hId.Value.ToString()));

                getEditorValue(f);

                try
                {
                    Logic.InsertOrUpdate(f);

                    Tools.message("Edit success");
                    LoadData();
                    wEditor.Hide();
                }
                catch
                {
                    Tools.message("Lỗi trong quá trình sửa, vui lòng thử lại sau...");
                }
            }
        }
    }
}