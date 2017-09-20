using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.i_Import
{
    public partial class Importer : dlgCustomBase
    {
        private string fileFilter = "Excel|*.xls;*.xlsx";
        public string FileFilter
        {
            get { return fileFilter; }
            set { fileFilter = value; }
        }

        protected ImportData DtDataImport = new ImportData();
        protected DataTable dtDataExcelImported = null;

        protected event Action OnPreData;
        protected event Action<DataTable> OnImportData;
        protected event Action<DataRow> OnImportRow;

        public Importer()
        {
            InitializeComponent();
        }
        private void Importer_Load(object sender, EventArgs e)
        {
            grd.DataSource = DtDataImport.DtColumn;
            btnDoImport.Left = this.Width - btnDoImport.Width - 15 - (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.None ? 0 : 6);
        }

        private void txtFilePath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = fileFilter;
            if (od.ShowDialog() == DialogResult.OK)
                txtFilePath.Text = od.FileName;
        }


        private void bgw_import_DoWork(object sender, DoWorkEventArgs e)
        {
            if (OnImportData != null)
            {
                try
                {
                    OnImportData(dtDataExcelImported);
                }
                catch(Exception ex)
                {
                    bgw_import.ReportProgress(-1, ex.Message);
                }
            }
            else
            {
                
                for (int i = 0; i < dtDataExcelImported.Rows.Count; i++)
                {
                    try
                    {
                        if (OnImportRow != null)
                            OnImportRow(dtDataExcelImported.Rows[i]);

                        bgw_import.ReportProgress(1, i);
                    }
                    catch (Exception ex)
                    {
                        bgw_import.ReportProgress(-1, ex.Message);
                    }
                }
            } 
        }
        private void bgw_import_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case -1:
                    richTextBox1.AppendText((string)e.UserState);
                    break;
                case 1:
                    prg.EditValue = e.UserState;
                    break;
            }
        }
        private void bgw_import_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnDoImport.Enabled = false;
            btnDoImport.Image = Properties.Resources.play;
            prg.EditValue = prg.Properties.Maximum;
        }

        private void Analyze_Click(object sender, EventArgs e)
        {
            if (!txtFilePath.Text.EndsWith(".xls", StringComparison.CurrentCultureIgnoreCase))
            {
                GUIHelper.Notifications("Cần chọn file " + fileFilter, this.Form_Title, GUIHelper.NotifiType.error);
                return;
            }

            ExcelExtend excel = new ExcelExtend();
            excel.OpenFile(txtFilePath.Text);
            dtDataExcelImported = excel.GetAllAvalidData();

            DataTable dt = new DataTable();
            dt.Columns.Add("ten");
            foreach (DataColumn dc in dtDataExcelImported.Columns)
            {
                var dr = dt.NewRow();
                dr["ten"] = dc.ColumnName;
                dt.Rows.Add(dr);
            }
            bsMapping.DataSource = dt;

            richTextBox1.AppendText("Analyzing..\n");
            richTextBox1.AppendText(string.Format("Getted {0:#,0} row in excel..\n", dtDataExcelImported.Rows.Count));

            xtraTabPage2.PageEnabled = true;
            btnDoImport.Enabled = true;
            btnAnalyze.Enabled = false;
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        private void btnDoImport_Click(object sender, EventArgs e)
        {
            if (!DtDataImport.DtColumn_HasData())
            {
                GUIHelper.Notifications("Chưa có cột nào được mapping", this.Form_Title, GUIHelper.NotifiType.error);
                return;
            }

            if (OnPreData != null)
            {
                try
                {
                    OnPreData();
                }
                catch(Exception ex)
                {
                    GUIHelper.Notifications(ex.Message, this.Form_Title, GUIHelper.NotifiType.error);
                    return;
                }
            }

            btnDoImport.Enabled = false;
            btnDoImport.Image = Properties.Resources.loading;
            if (!bgw_import.IsBusy)
            {
                prg.Properties.Maximum = dtDataExcelImported.Rows.Count;
                bgw_import.RunWorkerAsync();
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
            }
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            btnAnalyze.Enabled = true;
        }

        protected void OutLog_DuringImport(string log)
        {
            if (bgw_import.IsBusy)
                bgw_import.ReportProgress(-1, log);
        }
        
    }
}
