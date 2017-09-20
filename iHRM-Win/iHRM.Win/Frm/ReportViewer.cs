using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm
{
    public partial class ReportViewer : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public ReportViewer()
        {
            InitializeComponent();
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
        }

        public void ViewReport(object rp)
        {
            documentViewer1.DocumentSource = rp;
            this.Show();
        }
    }
}
