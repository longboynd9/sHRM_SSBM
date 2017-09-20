using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Common
{
    public partial class frmProgress : dlgCustomBase
    {
        public enum OutMessageStatus { normal, success, error, warning }
        public frmProgress()
        {
            InitializeComponent();
        }
        private void frmProgress_Load(object sender, EventArgs e)
        {

        }

        public void SetProgressValue(int v)
        {
            prg.Visible = (v >= 0);
            if (v < 0) v = 0;
            if (v > 100) v = 100;
            prg.EditValue = v;
        }
        public void SetProgressText(string text)
        {
            labelControl3.Text = text;
        }
        public void SetProgressStatus(mainBase.DoProgress_status stt)
        {
            switch (stt)
            {
                case mainBase.DoProgress_status.start:
                case mainBase.DoProgress_status.running:
                    pictureBox2.Image = Properties.Resources.loading;
                    break;
                case mainBase.DoProgress_status.complete:
                    pictureBox2.Image = Properties.Resources.ico20_tick;
                    break;
            }
        }
        public void OutProgressMessage(string text, OutMessageStatus stt = OutMessageStatus.normal)
        {
            switch (stt)
            {
                case OutMessageStatus.normal:
                    richTextBox1.SelectionColor = Color.Black;
                    break;
                case OutMessageStatus.success:
                    richTextBox1.SelectionColor = Color.Green;
                    break;
                case OutMessageStatus.error:
                    richTextBox1.SelectionColor = Color.Red;
                    break;
                case OutMessageStatus.warning:
                    richTextBox1.SelectionColor = Color.Orange;
                    break;
            }

            richTextBox1.AppendText(string.Format("\n[{0:HH:mm:ss}]: {1}", DateTime.Now, text));
        }

        private void frmProgress_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
        }
    }
}
