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
using System.Management;
using System.Security.Cryptography;
using System.IO;
using iHRM.Common.Code;

namespace iHRM.Win.Frm.Common
{
    public partial class frmInputKey : DevExpress.XtraEditors.XtraForm
    {
        public frmInputKey()
        {
            InitializeComponent();
        }

        private void frmInputKey_Load(object sender, EventArgs e)
        {
            txtIDCPU.Text = KeysHRM.GetIDCPU();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            try
            {
                string key = txtKey.Text;
                string strLicensePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\license.key";
                string strDecrypt = KeysHRM.Decrypt(key, true);
                if (KeysHRM.getIDCPUFromKey(strDecrypt) == txtIDCPU.Text)
                {
                    MessageBox.Show("Active thành công!. Bạn hãy vào lại chương trình để tiếp tục sử dụng. ", "Active phần mềm", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (File.Exists(strLicensePath))
                    {
                        File.Delete(strLicensePath);
                    }
                    File.WriteAllText(strLicensePath, key);
                }
                else
                {
                    MessageBox.Show("Active không thành công!. Key không hợp lệ", "Active phần mềm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Application.ExitThread();
                Application.Exit();
                Environment.Exit(0);
            }
            catch (Exception)
            {
                MessageBox.Show("Active không thành công!. Key không hợp lệ", "Active phần mềm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}