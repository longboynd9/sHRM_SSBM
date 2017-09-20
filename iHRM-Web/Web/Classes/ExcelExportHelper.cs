using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;

namespace iHRM.WebPC.Classes
{
    //ducnm - 28/12/2015
    /// <summary>
    /// Thư viện hỗ trợ xuất BC ra excel trên web
    /// </summary>
    public class ExcelExportHelper : iHRM.Common.Code.baseExcelExportHelper
    {
        public ExcelExportHelper() { }
        public ExcelExportHelper(string reportPath)
        {
            if (!reportPath.EndsWith(".xls"))
                reportPath += ".xls";
            string filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/ExcelTemplate"), reportPath);
            string fileName = string.Format("{0}_{1}.xls", Path.GetFileNameWithoutExtension(reportPath), Guid.NewGuid().ToString("N"));
            string temporaryPath = Path.Combine(HttpContext.Current.Server.MapPath("~/ExcelTemplate/$Temporary"), fileName);
            File.Copy(filePath, temporaryPath);
            OpenFile(temporaryPath);
        }

        ~ExcelExportHelper()
        {
            //File.Delete(_filePath);
        }
        
        public void RendAndFlush(string FlushFileName = "")
        {
            if (string.IsNullOrWhiteSpace(_filePath))
            {
                string fileName = string.Format("{0}.xls", Guid.NewGuid().ToString("N"));
                _filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/ExcelTemplate/$Temporary"), fileName);
            }

            Save();
            HttpContext.Current.Response.Redirect(string.Format("~/ExcelTemplate/Download.aspx?fp={0}&fn={1}",
                Path.GetFileName(_filePath),
                FlushFileName
            ));
        }
    }
}