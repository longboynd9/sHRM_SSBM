using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UpdateConfig;

namespace UpdatesHRM
{
    public partial class sHRM_Update : Form
    {
        Updater updater = new Updater();
        public sHRM_Update()
        {
            InitializeComponent();
            progressBar.Maximum = 100;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
            btnUpdate.Enabled = false;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Download từ host về:
            backgroundWorker.ReportProgress(1);
            //Thread.Sleep(new TimeSpan(0, 0, 10));
            ftp ftpClient = new ftp(@"ftp://103.28.39.47", "long", "Ab123456");

            backgroundWorker.ReportProgress(2);
            //Thread.Sleep(new TimeSpan(0, 0, 10));
            string a = ftpClient.download(updater._updateConfigLocal.rar_filename_Host, updater._apppath + @"\update.rar");

            backgroundWorker.ReportProgress(3, a);
            //Thread.Sleep(new TimeSpan(0, 0, 10));
            string a1 = ftpClient.download(updater._updateConfigLocal.version_sHRM_file, updater._apppath + @"\update.cfg") + "\n";

            //Giải nén
            backgroundWorker.ReportProgress(4, a1);
            //Thread.Sleep(new TimeSpan(0, 0, 10));
            string a2 = ExtractFile(updater._apppath + @"\update.rar", updater._apppath + @"\");
            backgroundWorker.ReportProgress(5, a2);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {
                labelProgress.Text = "Đang kết nối tới server...";
                progressBar.Value = 10;
            }
            if (e.ProgressPercentage == 2)
            {
                labelProgress.Text = "Đang tải file update.rar...";
                progressBar.Value = 60;
            }
            if (e.ProgressPercentage == 3)
            {
                labelProgress.Text = "Đang tải file update.cfg...";
                rtbError.Text += e.UserState.ToString();
                progressBar.Value = 70;
            }
            if (e.ProgressPercentage == 4)
            {
                labelProgress.Text = "Đang giải nén file update.rar";
                rtbError.Text += "\n" + e.UserState.ToString();
                progressBar.Value = 100;
            }
            if (e.ProgressPercentage == 5)
            {
                rtbError.Text += "\n" + e.UserState.ToString();
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            labelProgress.Text = "Update phần mềm thành công!";
            btnUpdate.Enabled = true;
        }

        private void sHRM_Update_Load(object sender, EventArgs e)
        {
            string a = Path.Combine(updater._apppath, @"update_Server.cfg");
            UpdateConfig.UpdateConfig updateConfigRemote = Serializer.DeserializeFromXmlFile<UpdateConfig.UpdateConfig>(a);
            UpdateConfig.UpdateConfig updateConfigLocal = Serializer.DeserializeFromXmlFile<UpdateConfig.UpdateConfig>(Path.Combine(updater._apppath, @"update.cfg"));
            labelPBHienTai.Text = "Hiện tại phiên bản sHRM của bạn là: " + updateConfigLocal.version_Now_Client;
            labelPBMoiNhat.Text = "Hiện tại phiên bản mới nhất sHRM là: " + updateConfigRemote.version_Now_Client;
        }
        private string ExtractFile(string rar_file, string path_file)
        {
            try
            {
                ProcessStartInfo ps = new ProcessStartInfo();
                // - File chương trình nén và giải nén Winar
                ps.FileName = updater._apppath + @"\RAR.exe";
                // - Tham số truyền vào câu lệnh (vd: rar.exe x - trong đó x là tham số)
                // - rar_file: tên file nén | path_file: đường dẫn giải nén(file đc giải nén, thư mục đc giải nén)
                // - \" Thêm vào một dấu nháy kép ("")
                ps.Arguments = "x -y \"" + rar_file + "\" \"" + path_file + "\"";
                ps.WindowStyle = ProcessWindowStyle.Hidden;     // - Ẩn cửa sổ giải nén
                // - Chạy câu lệnh giải nén
                Process proc = Process.Start(ps);
                // - Thoát sau khi giải nén xong
                proc.WaitForExit();
                return "Giải nén " + rar_file.Substring(rar_file.LastIndexOf("\\")+1,rar_file.Length-rar_file.LastIndexOf("\\")-1)+ " thành công.";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        private void btnTruyCapsHRM_Click(object sender, EventArgs e)
        {
            ProcessStartInfo ps = new ProcessStartInfo();
            ps.FileName = updater._apppath + @"\iHRM.Win.exe";
            Process proc = Process.Start(ps);
            Application.ExitThread();
            Application.Exit();
            Environment.Exit(0);
        }
    }
}
