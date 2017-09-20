using iHRM.Core.Business;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Common
{
    public partial class frmConnect : DevExpress.XtraEditors.XtraForm
    {
        iHRM.Core.Business.Logic.Common.login logic = new iHRM.Core.Business.Logic.Common.login();
        bool installAsServer = false;

        Cls.MoreFormByControl mf;
        public frmConnect()
        {
            InitializeComponent();
            mf = new MoreFormByControl(this, panel1, labelControl1);
            xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void login_Load(object sender, EventArgs e)
        {
            setcauhinhstring(Config.appConfig.strcnn);
        }

        #region sub
        public string BuildConnection(bool hasDb = true)
        {
            //Data Source=192.168.1.108;Initial Catalog=IVT_PMBH;Persist Security Info=True;User ID=sa;Password=123456@ivt

            string strcnn = string.Format("Data Source={0};", cboSV.Text);


            if (cboAU.SelectedIndex == 1)
                strcnn += string.Format("User ID={0};Password={1};", txtID.Text, txtPW.Text);


            if (!string.IsNullOrWhiteSpace(cboDB.Text))
            {
                if (hasDb)
                    strcnn += string.Format("Initial Catalog={0};", cboDB.Text);
            }

            strcnn += (cboAU.SelectedIndex == 0 ? "Integrated Security=SSPI;" : "Persist Security Info=True;");
            return strcnn;
        }

        bool checkConnection()
        {
            string strcnn = installAsServer ? BuildConnection(false) : BuildConnection(true);

            SqlConnection cnn = new SqlConnection(strcnn);
            try
            {
                cnn.Open();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
        }

        /// <span class="code-SummaryComment"><summary></span>
        /// Executes a shell command synchronously.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="command">string command</param></span>
        /// <span class="code-SummaryComment"><returns>string, as output of the command.</returns></span>
        public static string ExecuteCommandSync(string command, bool wait = false)
        {
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = procStartInfo;
                p.Start();
                if (wait)
                    p.WaitForExit();
                // Get the output into a string
                return p.StandardOutput.ReadToEnd();
            }
            catch (Exception objException)
            {
                MessageBox.Show(objException.Message);
            }
            return "";
        }
        
        #endregion

        #region form event
        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            if (checkConnection())
                GUIHelper.MessageBox("Kết nối thành công");
            else
                GUIHelper.MessageError("Kết nối không thành công");
        }

        private void cboAU_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtID.Enabled = txtPW.Enabled = (cboAU.SelectedIndex == 1);
        }

        private void btnInstallAsServer_Click(object sender, EventArgs e)
        {
            installAsServer = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }
        private void btnInstallAsClient_Click(object sender, EventArgs e)
        {
            installAsServer = false;
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
            linkLabel1.Image = Properties.Resources.loading;
        }

        System.Data.DataTable dtInstance = null;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Data.Sql.SqlDataSourceEnumerator instance = System.Data.Sql.SqlDataSourceEnumerator.Instance;
            dtInstance = instance.GetDataSources();
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cboSV.Tag = 1;
            cboSV.Items.Clear();
            foreach (DataRow dr in dtInstance.Rows)
                cboSV.Items.Add("" + dr[0] + (string.IsNullOrWhiteSpace(dr[1].ToString()) ? "" : "\\" + dr[1]));
            cboSV.DroppedDown = true;
            linkLabel1.Image = null;
        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!backgroundWorker2.IsBusy)
                backgroundWorker2.RunWorkerAsync();
            linkLabel2.Image = Properties.Resources.loading;
        }

        System.Data.DataTable dtDatabase = null;
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            SqlConnection cnn = new SqlConnection(BuildConnection(false));
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dtDatabase = new DataTable();
            try
            {
                cmd.CommandText = "sp_databases";
                da.Fill(dtDatabase);
            }
            catch
            {
            }
            finally
            {
                cnn.Dispose();
                cmd.Dispose();
                da.Dispose();
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cboDB.DataSource = dtDatabase;
            cboDB.DroppedDown = true;
            linkLabel2.Image = null;
        }

        private void Connector_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {
                if (MessageBox.Show("Are you sure to close?", "Confirm", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                    e.Cancel = true;
            }
        }
        
        #endregion

        bool Install()
        {
            if (!checkConnection())
            {
                GUIHelper.MessageError("Kết nối không thành công");
                return false;
            }

            try
            {
                string strcnn = BuildConnection();

                if (installAsServer)
                {
                    //string.Format("IF EXISTS(select * from sys.databases where name='{0}') DROP DATABASE {0}", cboDB.Text);

                    //Business.DataBase.dcDatabaseDataContext db = new Business.DataBase.dcDatabaseDataContext(strcnn);
                    //if (db.DatabaseExists())
                    //    db.DeleteDatabase();
                    //db.CreateDatabase();

                    //db.ExecuteCommand(Properties.Resources.gendata);
                }

                saveConnection();
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
                return false;
            }

            return true;
        }

        #region sub
        void saveConnection()
        {
            Config.appConfig.strcnn = getcauhinhstring();
            iHRM.Core.Business.Provider.ConnectionString = frmConnect.buildcauhinh(Config.appConfig.strcnn);
            Config.Save();
        }

        /// <summary>
        /// lấy thông tin cấu hình bởi 1 dòng
        /// </summary>
        /// <returns></returns>
        string getcauhinhstring()
        {
            return string.Format("{0};{1};{2};{3};{4}",
                cboSV.Text,
                cboAU.SelectedIndex,
                txtID.Text,
                Tools.EncryptPW(txtPW.Text),
                cboDB.Text
            );
        }
        void setcauhinhstring(string cauhinh)
        {
            try
            {
                string[] a = cauhinh.Split(';');
                cboSV.Text = a[0];
                int i = -1;
                int.TryParse(a[1], out i);
                cboAU.SelectedIndex = i;
                txtID.Text = a[2];
                txtPW.Text = Tools.DecryptPW(a[3]);
                cboDB.Text = a[4];
            }
            catch { }
        }
        public static string buildcauhinh(string cauhinh)
        {
            string[] a = cauhinh.Split(';');
            if (a.Length != 5)
                return "";

            int i = -1;
            int.TryParse(a[1], out i);

            string strcnn = string.Format("Data Source={0};", a[0]);

            if (i == 1)
                strcnn += string.Format("User ID={0};Password={1};", a[2], Tools.DecryptPW(a[3]));

            if (!string.IsNullOrWhiteSpace(a[4]))
                strcnn += string.Format("Initial Catalog={0};", a[4]);

            strcnn += (i == 0 ? "Integrated Security=SSPI;" : "Persist Security Info=True;");
            return strcnn;
        }
        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Install())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
