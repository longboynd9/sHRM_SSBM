using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using UpdatesHRM;

namespace UpdateConfig
{
    public class Updater
    {
        public string _apppath;
        public UpdateConfig _updateConfigLocal;
        public Updater()
        {
            _apppath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //string a = Path.Combine(_apppath, @"\update.cfg");
            _updateConfigLocal = Serializer.DeserializeFromXmlFile<UpdateConfig>(_apppath + @"\update.cfg");
        }
        public string getAppPath()
        {
            return _apppath;
        }
        public UpdateConfig getUpdateConfigLocal()
        {
            return _updateConfigLocal;
        }
        public void downloadServer(ftp ftpClient, string remoteFile, string localFile)
        {
            ftpClient.download(remoteFile, localFile);
        }

        public bool isNewVersionAvailable(string remoteUpdateFile, string localUpdateFile)
        {
            UpdateConfig updateConfigRemote = Serializer.DeserializeFromXmlFile<UpdateConfig>(Path.Combine(_apppath, remoteUpdateFile));
            UpdateConfig updateConfigLocal = Serializer.DeserializeFromXmlFile<UpdateConfig>(Path.Combine(_apppath, localUpdateFile));

            double localVersion = 0;
            double remoteVersion = 0;
            try
            {
                localVersion = Convert.ToDouble(updateConfigLocal.version_Now_Client);
                remoteVersion = Convert.ToDouble(updateConfigRemote.version_Now_Client);
            }
            catch (Exception)
            {
            }
            return localVersion < remoteVersion ? true : false;
        }
    }

    public class ftp
    {
        private string host = null;
        private string user = null;
        private string pass = null;
        private FtpWebRequest ftpRequest = null;
        private FtpWebResponse ftpResponse = null;
        private Stream ftpStream = null;
        private int bufferSize = 2048;

        Updater updater = new Updater();
        /* Construct Object */
        public ftp(string hostIP, string userName, string password) { host = hostIP; user = userName; pass = password; }

        /* Download File */
        public string download(string remoteFile, string localFile)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + remoteFile);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Get the FTP Server's Response Stream */
                ftpStream = ftpResponse.GetResponseStream();
                /* Open a File Stream to Write the Downloaded File */
                FileStream localFileStream = new FileStream(localFile, FileMode.Create);
                /* Buffer for the Downloaded Data */
                byte[] byteBuffer = new byte[bufferSize];
                int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                /* Download the File by Writing the Buffered Data Until the Transfer is Complete */
                try
                {
                    while (bytesRead > 0)
                    {
                        localFileStream.Write(byteBuffer, 0, bytesRead);
                        bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                    }
                }
                catch (Exception ex) { return (ex.ToString()); }
                /* Resource Cleanup */
                localFileStream.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (Exception ex) { return (ex.ToString()); }
            return "Download " + remoteFile + " thành công.";
        }
    }
}
