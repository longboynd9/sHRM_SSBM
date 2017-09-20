using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class win_globall
{
    public static string agrs;

    public static string updater_ver = "1.02";
    public static string updater_appcode = "5450982";
    
    #region for save file in app path
    public enum resourcefolder { tepdinhkem }

    private static string _apppath = null;
    /// <summary>
    /// thư mục chạy ct
    /// </summary>
    public static string apppath
    {
        get
        {
            if (_apppath == null)
            {
                try
                {
                    _apppath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                }
                catch
                {
                    _apppath = AppDomain.CurrentDomain.BaseDirectory;
                }
            }
            return _apppath;
        }
    }

    private static string _resourcepath = null;
    /// <summary>
    /// thư mục tài nguyên
    /// </summary>
    public static string resourceGet(resourcefolder folder, string name, bool checkExist = true)
    {
        if (_resourcepath == null)
        {
            _resourcepath = Path.Combine(apppath, "resource");
            if (!Directory.Exists(_resourcepath))
                Directory.CreateDirectory(_resourcepath);

            foreach (resourcefolder f in Enum.GetValues(typeof(resourcefolder)))
                Directory.CreateDirectory(Path.Combine(_resourcepath, f.ToString()));
        }

        if (string.IsNullOrWhiteSpace(name))
            return "";

        string path = Path.Combine(_resourcepath, folder.ToString(), name);
        if (checkExist && !File.Exists(path))
            return "";

        return path;
    }

    /// <summary>
    /// xóa tài nguyên
    /// </summary>
    public static bool resourceDel(resourcefolder folder, string name)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            //xóa file cũ
            try
            {
                File.Delete(resourceGet(folder, name));
                return true;
            }
            catch { }
        }

        return false;
    }

    public static string resourceDelAndSaveFile(string oldFile, string filePath, resourcefolder folder)
    {
        resourceDel(folder, oldFile);
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        string fileExt = Path.GetExtension(filePath);
        while (File.Exists(resourceGet(folder, fileName + fileExt, false)))
            fileName += (new Random()).Next();

        File.Copy(filePath, resourceGet(folder, fileName + fileExt, false));
        return fileName + fileExt;
    }
    #endregion

    public static void ExecCatch(System.Exception ex)
    {
        if (globall.indebug)
            throw ex;

        iHRM.Win.Cls.GUIHelper.MessageError(ex.Message, "Có lỗi ngoại lệ xảy ra!!!");
    }
}
