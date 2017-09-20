using System.IO;

namespace iHRM.Win.Cls
{
    public class AppConfig
    {
        public string frmLogin_saveId = "";
        public string frmLogin_savePw = "";
        public string frmLogin_saveDb = "";
        public bool frmLogin_autoLog = false;
        public string strcnn = "";
        public string istyle = "";
        public int InstalledDLL = 0;
    }
    
}

public class Config
{
    public static iHRM.Win.Cls.AppConfig appConfig = null;

    public static void Load()
    {
        try
        {
            appConfig = iHRM.Win.Cls.iSerializer.DeserializeFromXmlFile<iHRM.Win.Cls.AppConfig>(Path.Combine(win_globall.apppath, "app.cfg"));
        }
        catch
        {
            appConfig = new iHRM.Win.Cls.AppConfig();
        }
    }

    public static void Save()
    {
        try
        {
            iHRM.Win.Cls.iSerializer.SerializeToXmlFile(appConfig, Path.Combine(win_globall.apppath, "app.cfg"));
        }
        catch
        {
            throw;
        }
    }
}
