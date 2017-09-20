using DevExpress.XtraPrinting;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iHRM.Win.Frm
{
    public partial class frmBase : DevExpress.XtraEditors.XtraForm
    {
        public long iRule = 0;

        public frmBase()
        {
        }

        public void SaveGrvLayout(DevExpress.XtraGrid.Views.Grid.GridView grv, string subkey = "")
        {
            string key = this.GetType().FullName.Replace("iHRM.Win.Frm.", "") + (subkey == "" ? "" : ("_" + subkey)) + ".xml";
            string path = Path.Combine(win_globall.apppath, "GrvSaveLayout");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string a = Path.Combine(path, key);
            grv.SaveLayoutToXml(Path.Combine(path, key));
        }
        public void LoadGrvLayout(DevExpress.XtraGrid.Views.Grid.GridView grv, string subkey = "")
        {
            string key = this.GetType().FullName.Replace("iHRM.Win.Frm.", "") + (subkey == "" ? "" : ("_" + subkey)) + ".xml";
            string path = Path.Combine(win_globall.apppath, "GrvSaveLayout", key);
            try
            {
                grv.RestoreLayoutFromXml(path);
            }
            catch { }
        }

        public static void SaveGrvLayout_custom(DevExpress.XtraGrid.Views.Grid.GridView grv, string key)
        {
            if (!key.EndsWith(".xml"))
                key += ".xml";
            string path = Path.Combine(win_globall.apppath, "GrvSaveLayout");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string a = Path.Combine(path, key);
            grv.SaveLayoutToXml(Path.Combine(path, key));
        }
        public static void LoadGrvLayout_custom(DevExpress.XtraGrid.Views.Grid.GridView grv, string key)
        {
            if (!key.EndsWith(".xml"))
                key += ".xml";
            string path = Path.Combine(win_globall.apppath, "GrvSaveLayout", key);
            try
            {
                grv.RestoreLayoutFromXml(path);
            }
            catch { }
        }

        /// <summary>
        /// Lấy chuỗi order trên grid
        /// </summary>
        /// <param name="grv"></param>
        /// <returns></returns>
        public static string GetGrvOrderBy(DevExpress.XtraGrid.Views.Grid.GridView grv)
        {
            string OrderBy = "";
            foreach (DevExpress.XtraGrid.Columns.GridColumn sc in grv.SortedColumns)
            {
                OrderBy += (OrderBy == "" ? "" : ",") + sc.FieldName + " " + (sc.SortOrder == DevExpress.Data.ColumnSortOrder.Descending ? "DESC" : "ASC");
            }

            return OrderBy;
        }

        public static void ExportGrid(DevExpress.XtraGrid.GridControl grd)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel (2003)|*.xls|Excel (2007)|*.xlsx |RichText File|*.rtf |Pdf File|*.pdf |Html File|*.html";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string exportFilePath = saveDialog.FileName;
                string fileExtenstion = (new System.IO.FileInfo(exportFilePath)).Extension;
                switch (fileExtenstion)
                {
                    case ".xls":
                        XlsExportOptions options = new XlsExportOptions();
                        options.TextExportMode = TextExportMode.Value;
                        grd.ExportToXls(exportFilePath, options);
                        break;
                    case ".xlsx":
                        grd.ExportToXlsx(exportFilePath);
                        break;
                    case ".rtf":
                        grd.ExportToRtf(exportFilePath);
                        break;
                    case ".pdf":
                        grd.ExportToPdf(exportFilePath);
                        break;
                    case ".html":
                        grd.ExportToHtml(exportFilePath);
                        break;
                    case ".mht":
                        grd.ExportToMht(exportFilePath);
                        break;
                }

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = exportFilePath,
                    UseShellExecute = true
                });
            }
        }
        public static void ShowPreview(DevExpress.XtraGrid.GridControl grd)
        {
            grd.ShowPrintPreview();
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmBase
            // 
            this.ClientSize = new System.Drawing.Size(364, 262);
            this.Name = "frmBase";
            this.ResumeLayout(false);

        }

        protected void SaveFileDialog(string fileSaveName, Byte[] bytearray)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = fileSaveName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream _FileStream =
                                    new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create,
                                  System.IO.FileAccess.Write);
                // Writes a block of bytes to this stream using data from
                // a byte array.
                _FileStream.Write(bytearray, 0, bytearray.Length);
                // close file stream
                _FileStream.Close();
            }
        }

        protected void SetDataContextFromDataRow(object obj, DataRow value)
        {
            foreach (DataColumn dc in value.Table.Columns)
            {
                try
                {
                    if (value[dc.ColumnName] == DBNull.Value || value[dc.ColumnName] == null)
                    {

                    }
                    else
                    {
                        iHRM.Common.Code.PropertyExtension1.SetPropValue(obj, dc.ColumnName, value[dc.ColumnName]);
                    }
                }
                catch { }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idFile">idFile</param>
        /// <param name="dataFiles">Data của file (Binary)</param>
        /// <param name="action">1: Insert or Update, 2: Delete</param>
        /// <param name="duoiFile">Đuôi file</param>
        /// <returns></returns>
        //public static bool AddOrUpdateDbFile(Guid idFile, int action, Binary dataFiles = null, string duoiFile = null)
        //{
        //    bool isSuccess = false;
        //    try
        //    {
        //        dcDatabaseFilesDataContext dbFiles = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);
        //        switch (action)
        //        {
        //            case 1:
        //                var f = dbFiles.tbFiles.FirstOrDefault(p => p.id == idFile);
        //                if (f != null)
        //                {
        //                    f.dataFile = dataFiles;
        //                    f.duoiFile = duoiFile;
        //                    dbFiles.SubmitChanges();
        //                }
        //                else
        //                {
        //                    f = new tbFile();
        //                    f.id = idFile;
        //                    f.dataFile = dataFiles;
        //                    f.duoiFile = duoiFile;
        //                    dbFiles.tbFiles.InsertOnSubmit(f);
        //                    dbFiles.SubmitChanges();
        //                }
        //                isSuccess = true;
        //                break;
        //            case 2:
        //                var f1 = dbFiles.tbFiles.FirstOrDefault(p => p.id == idFile);
        //                if (f1 != null)
        //                {
        //                    dbFiles.tbFiles.DeleteOnSubmit(f1);
        //                    dbFiles.SubmitChanges();
        //                }
        //                isSuccess = true;
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        isSuccess = false;
        //    }
        //    return isSuccess;
        //}
    }
}
