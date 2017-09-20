using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;

namespace iHRM.Win.Cls
{
    //ducnm - 8/1/2016
    /// <summary>
    /// Thư viện hỗ trợ xuất BC ra excel trên win
    /// </summary>
    public class ExcelExportHelper : iHRM.Common.Code.baseExcelExportHelper
    {
        public ExcelExportHelper() { }
        public ExcelExportHelper(string reportPath)
        {
            if (!reportPath.EndsWith(".xls"))
                reportPath += ".xls";
            string filePath = Path.Combine(win_globall.apppath, "ExcelTemplate", reportPath);
            string fileName = string.Format("{0}_{1}.xls", Path.GetFileNameWithoutExtension(reportPath), Guid.NewGuid().ToString("N"));
            string temporaryPath = Path.Combine(win_globall.apppath, "ExcelTemplate", "$Temporary", fileName);
            File.Copy(filePath, temporaryPath);
            OpenFile(temporaryPath);
        }

        ~ExcelExportHelper()
        {
            //File.Delete(_filePath);
        }
        
        public void RendAndFlush(string FlushFileName = "", string savedFile = "")
        {
            Save();
            if (!string.IsNullOrWhiteSpace(savedFile))
                File.Move(_filePath, savedFile);
        }
    }
}