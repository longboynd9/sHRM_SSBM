using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UpdatesHRM;

namespace UpdateConfig
{
    public class UpdateConfig
    {
        public string link_Host = "ftp://103.28.39.47/"; // link của file host
        public string rar_filename_Host = "YSA/update.rar"; // File setup trên host: YSA/update.rar.
        public string version_Now_Client = "1.0"; // version hiện tại client.
        public string version_sHRM_file = "YSA/update.cfg"; // File version trên host: YSA/version.txt
    }
    public class Config
    {
        public static UpdateConfig updateConfig = null;
        static string _apppath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static void Load()
        {
            try
            {
                updateConfig = Serializer.DeserializeFromXmlFile<UpdateConfig>(Path.Combine(_apppath, "update.cfg"));
            }
            catch
            {
                updateConfig = new UpdateConfig();
            }
        }

        public static void Save()
        {
            try
            {
               Serializer.SerializeToXmlFile(updateConfig, Path.Combine(_apppath, "update.cfg"));
            }
            catch
            {
                throw;
            }
        }
    }
}
