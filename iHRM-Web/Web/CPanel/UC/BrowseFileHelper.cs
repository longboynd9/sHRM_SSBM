using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace iHRM.WebPC.Cpanel.UC
{
    public class BrowseFileHelper
    {
        public class FolderInfo
        {
            public Guid ID { get; set; }
            public Guid? ParentID { get; set; }
            public string folder { get; set; }
            public string path { get; set; }
        }

        public List<FolderInfo> BrowseHostImage_GetFolder()
        {
            List<FolderInfo> lst = new List<FolderInfo>();

            DirectoryInfo d = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["uploadFolder"]));
            Guid fID = Guid.NewGuid();
            lst.Add(new FolderInfo()
            {
                ID = fID,
                ParentID = null,
                folder = d.Name,
                path = ""
            });

            lst.AddRange(BrowseHostImage_GetFolder_1(d, fID, ""));

            return lst;
        }
        List<FolderInfo> BrowseHostImage_GetFolder_1(DirectoryInfo d, Guid pID, string path)
        {
            List<FolderInfo> lst = new List<FolderInfo>();
            foreach (var di in d.GetDirectories())
            {
                Guid fID = Guid.NewGuid();
                lst.Add(new FolderInfo()
                {
                    ID = fID,
                    ParentID = pID,
                    folder = di.Name,
                    path = path + "/" + di.Name
                });

                lst.AddRange(BrowseHostImage_GetFolder_1(di, fID, path + "/" + di.Name));
            }
            return lst;
        }

        public bool CreateFolder(string fPath)
        {
            try
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["uploadFolder"] + fPath));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteFolder(string fPath)
        {
            try
            {
                Directory.Delete(HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["uploadFolder"] + fPath));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string[] BrowseHostImage_GetFiles(string path)
        {
            DirectoryInfo d = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["uploadFolder"] + path));
            return d.GetFiles().Select(i => i.Name).ToArray();
        }

        public bool DeleteFile(string fPath)
        {
            try
            {
                File.Delete(HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["uploadFolder"] + fPath));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string UploadFile(byte[] f, string fPath)
        {
            // the byte array argument contains the content of the file
            // the string argument contains the name and extension
            // of the file passed in the byte array
            try
            {
                // instance a memory stream and pass the
                // byte array to its constructor
                MemoryStream ms = new MemoryStream(f);

                // instance a filestream pointing to the
                // storage folder, use the original file name
                // to name the resulting file
                FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["uploadFolder"] + fPath), FileMode.Create);

                // write the memory stream containing the original
                // file as a byte array to the filestream
                ms.WriteTo(fs);

                // clean up
                ms.Close();
                fs.Close();
                fs.Dispose();

                // return OK if we made it this far
                return "OK";
            }
            catch (Exception ex)
            {
                // return the error message if the operation fails
                return ex.Message.ToString();
            }
        }

    }
}