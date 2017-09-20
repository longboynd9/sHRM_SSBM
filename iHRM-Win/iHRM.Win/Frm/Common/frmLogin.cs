using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Win.Cls;
using iHRM.Win.ExtClass;
using iHRM.Win.Frm.mainForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using UpdateConfig;

namespace iHRM.Win.Frm.Common
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        iHRM.Core.Business.Logic.Common.login logic = new iHRM.Core.Business.Logic.Common.login();
        string _appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public bool isNeedUpdate = false;
        Cls.MoreFormByControl mf;
        Updater updater = new UpdateConfig.Updater();
        public frmLogin()
        {
            InitializeComponent();
            mf = new MoreFormByControl(this, panel1, labelControl1);
        }

        private void login_Load(object sender, EventArgs e)
        {
            UpdateConfig.ftp ftpClient = new UpdateConfig.ftp(@"ftp://103.28.39.47/", "long", "Ab123456");
            updater.downloadServer(ftpClient, updater._updateConfigLocal.version_sHRM_file, updater._apppath + @"\update_Server.cfg");
            if (updater.isNewVersionAvailable(updater._apppath + @"\update_Server.cfg", updater._apppath + @"\update.cfg"))
            {
                isNeedUpdate = true;
                btnLogin.Text = "Cập nhật PM";
            }
            else
            {
                isNeedUpdate = false;
            }
            if (win_globall.agrs == "/admin" || string.IsNullOrWhiteSpace(Config.appConfig.strcnn))
            {
                btnCauHinh.Visible = true;
            }

            var dt = logic.GetAllConnection();
            cmbDB.Properties.Items.AddRange(dt.Select().Select(i => i["code"]).ToArray());

            if (!string.IsNullOrWhiteSpace(Config.appConfig.frmLogin_saveId))
            {
                chkRemember.Checked = true;
                txtID.Text = Config.appConfig.frmLogin_saveId;
                txtPW.Text = Cls.Tools.Decrypt(Config.appConfig.frmLogin_savePw, "frmLogin_savePw1");
                cmbDB.EditValue = Config.appConfig.frmLogin_saveDb;
                chkAutoLogin.Checked = Config.appConfig.frmLogin_autoLog;

                if (chkAutoLogin.Checked)
                {
                    timer1.Start();
                    return;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int _countDown2AutoLogin = 5;
        private void timer1_Tick(object sender, EventArgs e)
        {
            _countDown2AutoLogin -= 1;
            chkAutoLogin.Text = "Tự động đăng nhập sau " + _countDown2AutoLogin + "s";
            if (_countDown2AutoLogin <= 0)
            {
                timer1.Stop();
                btnLogin_Click(null, null);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (isNeedUpdate)
            {
                Process.Start(updater._apppath + @"\UpdatesHRM.exe");
                Application.ExitThread();
                Application.Exit();
                Environment.Exit(0);
            }
            if (Interface_Company.isNeedKey && !isSucessKey())
            {
                frmInputKey frmKey = new frmInputKey();
                frmKey.ShowDialog();
                return;
            }
            if (timer1.Enabled)
                timer1.Stop();

            if (string.IsNullOrWhiteSpace(Provider.ConnectionString))
            {
                GUIHelper.MessageError("Chưa chọn cấu hình...");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbDB.Text))
            {
                GUIHelper.MessageBox("Please Choose DB");
                return;
            }

            progressPanel1.Visible = true;
            btnLogin.Enabled = false;
            if (!bgwLogin.IsBusy)
                bgwLogin.RunWorkerAsync();
        }

        private bool isSucessKey()
        {
            try
            {
                string strFilePath = _appPath + @"\license.key";
                if (!File.Exists(strFilePath))
                {
                    return false;
                }
                else
                {
                    string IDCPU = KeysHRM.GetIDCPU();
                    string strLicenseFile = File.ReadAllText(strFilePath);
                    if (strLicenseFile != "")
                    {
                        string strLicenseFileDecrypted = KeysHRM.Decrypt(strLicenseFile, true);
                        string IDCPUFromLicenseFile = KeysHRM.getIDCPUFromKey(strLicenseFileDecrypted);
                        DateTime DateStartFromLicenseFile = KeysHRM.getDateStartFromKey(strLicenseFileDecrypted);
                        int NumdayFromLicenseFile = KeysHRM.getNumdayFromKey(strLicenseFileDecrypted);
                        if (IDCPU == IDCPUFromLicenseFile)
                        {
                            if (DateStartFromLicenseFile.AddDays(NumdayFromLicenseFile) >= DateTime.Now)
                            {
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("License của bạn đã hết hạn! ", "Active phần mềm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("License của bạn không hợp lệ! ", "Active phần mềm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                        return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void Logged()
        {
            try
            {
                txtPW.Text = "";
                this.Hide();
                main.Load();
                if (main.Instance.ShowDialog() == DialogResult.OK)
                {
                    Provider.ConnectionString = frmConnect.buildcauhinh(Config.appConfig.strcnn);
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
                this.Close();
            }
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm.Common.frmConnect cauhinh = new Frm.Common.frmConnect();
            try
            {
                cauhinh.ShowDialog();
            }
            finally
            {
                this.Show();
            }
        }

        private void chkRemember_CheckedChanged(object sender, EventArgs e)
        {
            chkAutoLogin.Enabled = chkRemember.Checked;
        }

        private void chkAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Stop();
        }

        private void bgwLogin_DoWork(object sender, DoWorkEventArgs e)
        {
            var dr = logic.GetAllConnection().Select("code='" + cmbDB.Text + "'").FirstOrDefault();
            if (dr == null)
            {
                bgwLogin.ReportProgress(1);
                return;
            }
            LoginHelper.Dept = dr;
            Provider.ConnectionString = dr["strcnn"].ToString();
            Provider.ConnectionString_MCC = dr["strMCC"].ToString();
            Provider.ConnectionString_PushServer = dr["strPushServer"].ToString();

            LoginHelper.loginin(txtID.Text, txtPW.Text);
        }

        private void bgwLogin_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {
                GUIHelper.MessageBox("Please Choose DB");
            }
        }

        private void bgwLogin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (LoginHelper.isLogin)
            {
                CacheDataTable.ds = new DataSet();
                Config.appConfig.frmLogin_autoLog = chkAutoLogin.Checked;
                Config.appConfig.frmLogin_saveId = chkRemember.Checked ? txtID.Text : "";
                Config.appConfig.frmLogin_savePw = chkRemember.Checked ? Cls.Tools.Encrypt(txtPW.Text, "frmLogin_savePw1") : "";
                Config.appConfig.frmLogin_saveDb = chkRemember.Checked ? cmbDB.Text : "";
                Config.Save();
                Logged();
            }
            else
            {
                GUIHelper.MessageError("Đăng nhập không thành công!");
            }
            btnLogin.Enabled = true;
        }
    }
}
