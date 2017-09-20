using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace iHRM.Win.Frm.Common
{
    public partial class frmError : DevExpress.XtraEditors.XtraForm
    {
        public frmError()
        {
            InitializeComponent();
        }
        private void frmError_Load(object sender, EventArgs e)
        {

        }

        public void ShowEx(Exception ex)
        {
            textBox1.Text = ex.Message;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}