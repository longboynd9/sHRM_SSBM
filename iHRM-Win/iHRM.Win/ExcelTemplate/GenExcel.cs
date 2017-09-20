using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.ExcelTemplate
{
    public partial class GenExcel : DevExpress.XtraEditors.XtraForm
    {
        public event Action<BackgroundWorker> OnDoing;
        public event Action<int, object> OnReport;

        public GenExcel()
        {
            InitializeComponent();
        }
        private void GenExcel_Load(object sender, EventArgs e)
        {
            bw1.RunWorkerAsync();
        }
        
        private void bw1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (OnDoing != null)
                OnDoing(bw1);
        }
        private void bw1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case -1:
                    progressPanel1.Caption = e.UserState.ToString();
                    break;
                case -2:
                    progressPanel1.Description = e.UserState.ToString();
                    break;
                default:
                    if (OnReport != null)
                        OnReport(e.ProgressPercentage, e.UserState);
                    break;
            }
        }
        private void bw1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
