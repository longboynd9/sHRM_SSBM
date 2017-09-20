using iHRM.Common.Code;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class NhapDuLieuQuetThe : dlgCustomBase
    {
        string[] FilesChoised;
        ImportData DtDataImport = new ImportData();

        public NhapDuLieuQuetThe()
        {
            InitializeComponent();
        }
        private void NhapDuLieuQuetThe_Load(object sender, EventArgs e)
        {
            string datas = Core.Business.Logic.AllLogic.SaveData_Get("ImpDLQuetThe_win");
            if (string.IsNullOrWhiteSpace(datas))
                datas = "10,1,2,3,5";
            if (datas[0] == '2')
                ktPhay.Checked = true;
            datas = datas.Substring(1);
            var a = datas.Split(',');

            DtDataImport.DtColumn_AddData("somay", Lng.QuetThe_Import.somay, a.Length > 0 ? a[0] : "0");
            DtDataImport.DtColumn_AddData("ngay", Lng.QuetThe_Import.ngay, a.Length > 1 ? a[1] : "1");
            DtDataImport.DtColumn_AddData("gio", Lng.QuetThe_Import.gio, a.Length > 2 ? a[2] : "2");
            DtDataImport.DtColumn_AddData("mathe", Lng.QuetThe_Import.mathe, a.Length > 3 ? a[3] : "3");
            DtDataImport.DtColumn_AddData("mamay", Lng.QuetThe_Import.mamay, a.Length > 4 ? a[4] : "4");
            DtDataImport.DtColumn_AddData("maNV", Lng.QuetThe_Import.maNV, a.Length > 5 ? a[5] : "5");

            grd.DataSource = DtDataImport.DtColumn;
        }

        private void txtFilePath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Text file|*.txt";
            od.Multiselect = true;
            if (od.ShowDialog() == DialogResult.OK)
            {
                FilesChoised = od.FileNames;
                txtFilePath.Text = string.Format("{0} File choised", FilesChoised.Length);
                btnDoImport.Enabled = true;
            }
        }


        private void bgw_import_DoWork(object sender, DoWorkEventArgs e)
        {
            Core.Controller.QuetThe.NhapDuLieuQuetThe controller = new Core.Controller.QuetThe.NhapDuLieuQuetThe();

            int m_soMay, m_ngay, m_gio, m_maThe, m_maMay, m_maNV;
            #region mapping
            var dic = DtDataImport.DtColumn_GetData();
            m_soMay = int.Parse(dic["somay"]);
            m_ngay = int.Parse(dic["ngay"]);
            m_gio = int.Parse(dic["gio"]);
            m_maThe = int.Parse(dic["mathe"]);
            m_maMay = int.Parse(dic["mamay"]);
            m_maNV = int.Parse(dic["maNV"]);
            #endregion

            //save state
            string datas = "1";
            if (ktPhay.Checked)
                datas = "2";
            datas += string.Format("{0},{1},{2},{3},{4},{5}", m_soMay, m_ngay, m_gio, m_maThe, m_maMay, m_maNV);
            Core.Business.Logic.AllLogic.SaveData_Set("ImpDLQuetThe_win", datas);

            for (int i = 0; i < FilesChoised.Length; i++)
            {
                try
                {
                    string s = controller.doImport(FilesChoised[i], m_soMay, m_ngay, m_gio, m_maThe, m_maMay, m_maNV, ktPhay.Checked ? ',' : '\t');
                    bgw_import.ReportProgress(1, i + 1);
                    bgw_import.ReportProgress(2, s);
                }
                catch (Exception ex)
                {
                    bgw_import.ReportProgress(-1, ex);
                }
            }
        }
        private void bgw_import_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case -1:
                    richTextBox1.AppendText("\n" + e.UserState);
                    break;
                case 1:
                    prg.EditValue = e.UserState;
                    break;
                case 2:
                    richTextBox1.AppendText("\n" + e.UserState);
                    break;
            }
        }
        private void bgw_import_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnDoImport.Enabled = true;
            btnDoImport.Image = Properties.Resources.play;
            prg.EditValue = prg.Properties.Maximum;
        }
        
        private void btnDoImport_Click(object sender, EventArgs e)
        {
            btnDoImport.Enabled = false;
            btnDoImport.Image = Properties.Resources.loading;
            if (!bgw_import.IsBusy)
            {
                prg.Properties.Maximum = FilesChoised.Length;
                bgw_import.RunWorkerAsync();
            }
        }
    }
}
