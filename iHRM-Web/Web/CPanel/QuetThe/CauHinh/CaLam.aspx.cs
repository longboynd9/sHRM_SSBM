using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using Ext.Net;
using System.IO;
using iHRM.Core.Business.Logic;
using System.Data;
using System.Xml;
using iHRM.Core.Business.DbObject;

namespace iHRM.WebPC.Cpanel.QuetThe
{
    public partial class CaLam : BackEndPageBase
    {
        global::iHRM.Core.Business.Logic.ChamCong.calam logic = new global::iHRM.Core.Business.Logic.ChamCong.calam();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !X.IsAjaxRequest)
            {
                LoadData();
            }
        }

        void LoadData()
        {
            Store1.DataSource = logic.GetAllCaLam();
            Store1.DataBind();
        }

        protected void grd_OnCommand(object sender, DirectEventArgs e)
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
                        LoadData();
                        break;
                    case "Ca":
                        wTangCa.Title = "Tính tăng ca của ca " + e.ExtraParams["name"];
                        wTangCa.Show();
                        wTangCa.AutoLoad.Url = "TinhTangCa.aspx?idCa=" + commandId;
                        wTangCa.LoadContent();
                        break;
                }
            }
            catch(Exception ex)
            {
                if (globall.indebug)
                    throw;

                Tools.messageEx(ex);
            }
        }

        private void EditRecord(string commandId)
        {
            var db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);
            var it = db.tbCaLamViecs.SingleOrDefault(i => i.id == new Guid(commandId));

            h_id.Value = it.id;
            FormSetDataContext(frmEditor, it);
            editor.Show();
        }

        private void DeleteRecord(string commandId)
        {
            var db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);
            var it = db.tbCaLamViecs.SingleOrDefault(i => i.id == new Guid(commandId));

            if (it != null)
            {
                db.tbCaLamViecs.DeleteOnSubmit(it);
                db.SubmitChanges();
            }
        }

        protected void btnDangKy_DirectClick(object sender, DirectEventArgs e)
        {
            var db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);
            if (string.IsNullOrWhiteSpace(h_id.Value as string))
            {
                tbCaLamViec it = new tbCaLamViec();
                it.id = Guid.NewGuid();
                FormGetDataContext(frmEditor, it);
                db.tbCaLamViecs.InsertOnSubmit(it);
                db.SubmitChanges();
                Tools.message(Lng.common_msg.Add_Success);
            }
            else
            {
                var it = db.tbCaLamViecs.SingleOrDefault(i => i.id == new Guid(h_id.Value as string));
                FormGetDataContext(frmEditor, it);
                try
                {
                    db.SubmitChanges();
                    Tools.message(Lng.common_msg.Add_Success);
                }
                catch (Exception ex)
                {
                    if (globall.indebug)
                        throw;

                    Tools.messageEx(ex);
                }
            }

            editor.Hide();
            LoadData();
        }

    }
}