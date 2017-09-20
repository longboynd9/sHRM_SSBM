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
    public partial class TinhTangCa : BackEndPageBase
    {
        protected override void initRight()
        {
            adm_FuncID = 222;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["idCa"] == null)
            {
                Response.Write("id Ca lam = ?");
                Response.End();
                return;
            }

            if (!IsPostBack && !X.IsAjaxRequest)
            {
                LoadData();
                Lng.Web_Language.Lng_SetControlTexts(this);
            }
        }

        void LoadData()
        {
            var db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);
            Store1.DataSource = db.tbCaLam_TinhTangCas.Where(i => i.idCaLamViec == new Guid(Request["idCa"])).OrderBy(i => i.idx);
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
            var it = db.tbCaLam_TinhTangCas.SingleOrDefault(i => i.id == new Guid(commandId));

            h_id.Value = it.id;
            FormSetDataContext(frmEditor, it);
            editor.Show();
        }

        private void DeleteRecord(string commandId)
        {
            var db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);
            var it = db.tbCaLam_TinhTangCas.SingleOrDefault(i => i.id == new Guid(commandId));

            if (it != null)
            {
                db.tbCaLam_TinhTangCas.DeleteOnSubmit(it);
                db.SubmitChanges();

                var ca = db.tbCaLamViecs.SingleOrDefault(i => i.id == it.idCaLamViec);
                ca.soTiengTinhTangCa = ca.tbCaLam_TinhTangCas.Sum(i => (i.thoiGian == null ? 0 : i.thoiGian.Value.TotalHours));
                db.SubmitChanges();
            }
        }

        protected void btnDangKy_DirectClick(object sender, DirectEventArgs e)
        {
            var db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);
            if (string.IsNullOrWhiteSpace(h_id.Value as string))
            {
                tbCaLam_TinhTangCa it = new tbCaLam_TinhTangCa();
                it.id = Guid.NewGuid();
                it.idCaLamViec = new Guid(Request["idCa"]);
                FormGetDataContext(frmEditor, it);
                db.tbCaLam_TinhTangCas.InsertOnSubmit(it);
                db.SubmitChanges();

                Core.Business.Provider.ExecNoneQuery("p_tbcalam_recalc_soTiengTinhTangCa", new System.Data.SqlClient.SqlParameter("id", it.idCaLamViec));

                Tools.message(Lng.common_msg.Add_Success);
            }
            else
            {
                var it = db.tbCaLam_TinhTangCas.SingleOrDefault(i => i.id == new Guid(h_id.Value as string));
                FormGetDataContext(frmEditor, it);
                try
                {
                    db.SubmitChanges();

                    Core.Business.Provider.ExecNoneQuery("p_tbcalam_recalc_soTiengTinhTangCa", new System.Data.SqlClient.SqlParameter("id", it.idCaLamViec));

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