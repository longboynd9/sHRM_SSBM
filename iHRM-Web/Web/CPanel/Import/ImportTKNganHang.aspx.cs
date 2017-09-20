using iHRM.Common.Code;
using iHRM.Core.Business.Logic;
using iHRM.WebPC.Classes;
using iHRM.WebPC.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iHRM.WebPC.Cpanel.Import
{
    public partial class ImportTKNganHang : System.Web.UI.Page
    {
        iHRM.Core.Business.Logic.Employee.Emp logic = new iHRM.Core.Business.Logic.Employee.Emp();
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
        protected void txtUploadExcel_DirectUp(object sender, EventArgs e)
        {
            if (txtUpFile.HasFile)
            {
                string p = Server.MapPath("~/Cpanel/Import/Tempory/ImportTKNganHang.xls");
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
                                p = Server.MapPath("~/Cpanel/Import/Tempory/ImportTKNganHang" + new Random().Next() + ".xls");
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
                catch (Exception ex)
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
            foreach (var it in Core.Controller.Employee.impEmployee.listSTKNganHang)
                colMapping.Add(new Core.Controller.Employee.cMapping() { c1 = it.c1, c1Text = it.c1Text, c2 = it.c2, dataType = it.dataType });
            stoColMapping.DataSource = lst;
            stoColMapping.DataBind();

            h_FileAttacked.Value = p;
            stoMapping.DataSource = colMapping;
            stoMapping.DataBind();
            wMapping.Hidden = false;
        }

        protected void btnImport_DirectClick(object sender, EventArgs e)
        {
            string value = h_MappingString.Value.ToString();
            if (string.IsNullOrWhiteSpace(value))
            {
                Tools.message("Chọn mapping...");
                return;
            }
            if (string.IsNullOrWhiteSpace(h_FileAttacked.Value as string))
            {
                Tools.message("Chọn file import...");
                return;
            }

            List<Core.Controller.Employee.cMapping> colMapping = new List<Core.Controller.Employee.cMapping>();
            foreach (string s in value.Split(','))
            {
                if (string.IsNullOrWhiteSpace(s))
                    continue;
                int i = s.IndexOf(':');
                if (i == -1)
                    continue;
                colMapping.Add(new Core.Controller.Employee.cMapping() { c1 = s.Substring(0, i), c2 = s.Substring(i + 1) });
            }
            DataTable table_STK = new DataTable();
            ExcelExtend excel = new ExcelExtend();
            excel.OpenFile(Server.MapPath("~/Cpanel/Import/Tempory/" + h_FileAttacked.Value));
            var dt = excel.GetAllAvalidData();
            foreach(var item in colMapping){
                table_STK.Columns.Add( new DataColumn(item.c1,typeof(string)));
            }
            foreach (DataRow dr in dt.Rows)
            {
                DataRow TK_row = table_STK.NewRow();
                foreach (var item in colMapping)
                {
                    TK_row[item.c1] = dr[item.c2];
                }
                table_STK.Rows.Add(TK_row);
            }
            
            try
            {
                var ret = logic.ImportSTKNganHang(table_STK);
                Tools.messageConfirmSuccess("Import thành công (" + ret.NumberOfRowAffected + ")");
            }
            catch (Exception ex)
            {
                Tools.messageEx(ex, "Import fail");
            }
        }
    }
}