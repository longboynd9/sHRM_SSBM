using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using iHRM.Core.Business;

namespace iHRM.WebPC.Cpanel.Admin
{
    public partial class SQLManagement : BackEndPageBase
    {
        protected override void initRight()
        {
            adm_FuncID = 55;
            adm_RequiredAdmin = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProcName();

                stt_lblUser.Text = LoginHelper.isLogin ? LoginHelper.user.loginID : "-";
            }
        }

        void LoadProcName()
        {
            //DataTable dt = ADOController.ExeProcedure("admin_listAllProc");
            //stoProcName.DataSource = dt;
            //stoProcName.DataBind();
        }

        protected void stoProcName_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            LoadProcName();
        }

        [DirectMethod]
        public string generateProcDefine(string procName)
        {
            DataTable dt = Provider.ExecuteDataTableReader("admin_getProcDefineText", new SqlParameter("procname", procName));
            if (dt != null || dt.Rows.Count > 0)
                return (dt.Rows[0][0] as string);

            return "";
        }
        [DirectMethod]
        public string generateProcExec(string procName)
        {
            string s = "exec " + procName;

            DataTable dt = Provider.ExecuteDataTableReader_SQL(string.Format("SELECT * FROM INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME='{0}'", procName));
            if (dt != null || dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                    s += "\n\t" + dr["PARAMETER_NAME"] + " = ''";
            }

            return s;
        }

        protected void stoProcName_BeforeRecordUpdated(object sender, BeforeRecordUpdatedEventArgs e)
        {
            try
            {
                var ret = Provider.ExecuteNonQuery("sp_rename",
                    new SqlParameter("objname", e.Keys["name"]),
                    new SqlParameter("newname", e.NewValues["name"])
                );

                stt.Icon = Icon.Accept;
                stt.SetStatus(ret.Message);
            }
            catch (Exception ex)
            {
                stt.Icon = Icon.Error;
                stt.SetStatus(ex.Message);
                LoadProcName();
            }
        }

        protected void btnExecute_DirectClick(object sender, DirectEventArgs e)
        {
            string sql = txtSql.Text;
            if (!string.IsNullOrWhiteSpace(e.ExtraParams["sql"]))
                sql = e.ExtraParams["sql"];

            if (!string.IsNullOrWhiteSpace(sql))
            {
                try
                {
                    var ret = Provider.ExecuteNonQuery_SQL(sql);

                    grd_sqlResult.ColumnModel.Columns.Clear();
                    sto_sqlResult.RemoveFields();
                    foreach (DataColumn dc in ret.Data.Columns)
                    {
                        grd_sqlResult.ColumnModel.Columns.Add(new Ext.Net.Column()
                        {
                            DataIndex = dc.ColumnName,
                            Header = (string.IsNullOrWhiteSpace(dc.Caption) ? dc.ColumnName : dc.Caption)
                        });

                        sto_sqlResult.AddField(new RecordField(dc.ColumnName, RecordFieldType.Auto));
                    }

                    sto_sqlResult.DataSource = ret.Data;
                    sto_sqlResult.DataBind();
                    txt_sqlMessage.Text = ret.Message;
                    stt_lblRowAffect.Text = ret.NumberOfRowAffected + " dòng";

                    grd_sqlResult.Reconfigure();
                    stt.Icon = Icon.Accept;
                    stt.SetStatus("Câu lệnh thực hiện thành công");

                    if (ret.Data.Rows.Count > 0)
                        tabResult.SetActiveTab(0);
                }
                catch (Exception ex)
                {
                    stt.Icon = Icon.Error;
                    txt_sqlMessage.Text = ex.Message;
                    stt.SetStatus("Câu lệnh đã hoàn tất với lỗi...");

                    tabResult.SetActiveTab(1);
                }
            }
        }
    }
}