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
using iHRM.WebPC.Classes;
using System.Text;
using System.Data.SqlClient;
using iHRM.Core.Business;
using System.Globalization;

namespace iHRM.WebPC.Cpanel.Import
{
    public partial class ImportEmployee : BackEndPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["fp"] != null)
            {
                doExe(Request["fp"]);
            }

            if (!IsPostBack)
            {
            }
        }

        protected void btnAttack_Click(object sender, EventArgs e)
        {
            if (txtUpFile.HasFile)
            {
                string p = Server.MapPath("~/Cpanel/Import/Tempory/Import.xls");

                try
                {
                    if (File.Exists(p))
                    {
                        try
                        {
                            File.Delete(p);
                        }
                        catch
                        {
                            do
                            {
                                p = Server.MapPath("~/Cpanel/Import/Tempory/Import" + new Random().Next() + ".xls");
                            }
                            while (File.Exists(p));
                        }
                    }

                    //if (txtUpFile.PostedFile.ContentType.ToLower() != "application/vnd.ms-excel")
                    if (!txtUpFile.FileName.EndsWith(".xls", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Tools.message("Bạn cần nhập file excel (.xls)");
                        return;
                    }

                    txtUpFile.PostedFile.SaveAs(p);
                }
                catch
                {
                    Tools.message("Có lỗi khi lưu file excel");
                    return;
                }

                try
                {
                    doExe(Path.GetFileName(p));
                }
                catch(Exception ex)
                {
                    Tools.messageConfirmErr(ex.Message);
                    return;
                }
            }
        }

        private void doExe(string p)
        {
            ExcelExtend excel = new ExcelExtend();
            excel.OpenFile(Server.MapPath("~/Cpanel/Import/Tempory/" + p));
            var dt = excel.GetAllAvalidData();
            List<Core.Controller.Employee.cMapping> lst = new List<Core.Controller.Employee.cMapping>() 
            { 
                new Core.Controller.Employee.cMapping { c1 = "", c1Text = "-- None --" } 
            };
            foreach (DataColumn dc in dt.Columns)
                lst.Add(new Core.Controller.Employee.cMapping { c1 = dc.ColumnName, c1Text = dc.ColumnName });

            List<Core.Controller.Employee.cMapping> colMapping = new List<Core.Controller.Employee.cMapping>();
            foreach(var it in Core.Controller.Employee.impEmployee.lstEmpMapping)
                colMapping.Add(new Core.Controller.Employee.cMapping() { c1 = it.c1, c1Text = it.c1Text, c2 = it.c2, dataType = it.dataType });

            string code = AllLogic.SaveData_Get("ImpEmp_colMap");
            if (!string.IsNullOrWhiteSpace(code))
            {
                foreach (string s in code.Split(','))
                {
                    if (string.IsNullOrWhiteSpace(s))
                        continue;

                    int i = s.IndexOf(':');
                    if (i == -1)
                        continue;

                    var m = colMapping.SingleOrDefault(it => it.c1 == s.Substring(0, i));
                    if (m != null)
                        m.c2 = s.Substring(i + 1);
                }
            }

            stoColMapping.DataSource = lst;
            stoColMapping.DataBind();

            stoMapping.DataSource = colMapping;
            stoMapping.DataBind();

            h_FileAttacked.Value = p;
            prg1.Hidden = false;
            prg1.Text = p;
            btnPlay.Hidden = false;
            btnStop.Hidden = false;
            pnlChkShow.Hidden = false;

            btnMapping.Hidden = false;
            wMapping.Hidden = false;
        }

    }
}