using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace iHRM.Win.Frm.Common
{
    public partial class frmHuongDanSuDung : DevExpress.XtraEditors.XtraForm
    {
        public frmHuongDanSuDung()
        {
            InitializeComponent();
        }

        private void frmHuongDanSuDung_Load(object sender, EventArgs e)
        {

            //object filename = @"C:\Desktop\Test.doc";
            //Microsoft.Office.Interop.Word.Application AC = new Microsoft.Office.Interop.Word.Application();
            //Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
            //object readOnly = false;
            //object isVisible = true;
            //object missing = System.Reflection.Missing.Value;
            //try
            //{
            //    doc = AC.Documents.Open(ref filename, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            //    doc.Content.Select();
            //    doc.Content.Copy();
            //    richTextBox1.Paste();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ERROR: " + ex.Message);
            //}
            //finally
            //{
            //    doc.Close(ref missing, ref missing, ref missing);
            //}
        }
    }
}