using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;

namespace iHRM.WebPC.Cpanel.UC
{
    //ducnm 04-07-2014
    /// <summary>
    /// control úp ảnh
    /// </summary>
    public partial class ImageUploader : System.Web.UI.UserControl
    {
        /// <summary>
        /// ảnh gốc
        /// </summary>
        protected static string noimg = "/Images/noimg.jpg";

        #region public property

        /// <summary>
        /// control file-upload
        /// </summary>
        public FileUploadField imageFileUpload { get { return FileUpload1; } }

        /// <summary>
        /// kiểm tra xem có file đc úp lên hay ko
        /// </summary>
        public bool hasFile { get { return FileUpload1.HasFile; } }

        /// <summary>
        /// link ảnh trên sv
        /// </summary>
        public string imgUrl
        {
            get { return Image1.ImageUrl; }
            set
            {
                Image1.ImageUrl = value;
                if (string.IsNullOrEmpty(Image1.ImageUrl))
                    Image1.ImageUrl = noimg;
            }
        }

        /// <summary>
        /// kích thức tối đa của file (byte)
        /// </summary>
        public int maxFileSize
        {
            get
            {
                if (ViewState["maxFileSize"] == null)
                    return 1024 * 5;
                return (int)ViewState["maxFileSize"];
            }
            set { ViewState["maxFileSize"] = value; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                if (string.IsNullOrEmpty(Image1.ImageUrl))
                    Image1.ImageUrl = noimg;
            }
        }


        /// <summary>
        /// Lưu ảnh đã upload lên sv
        /// </summary>
        /// <param name="rootFolder">Thư mục gốc (vd ~/image)</param>
        /// <param name="fileName">Tên file, nếu để rỗng thì tự sinh và ko trùng, nếu có thì sẽ ghi đè đúng tên đó</param>
        /// <param name="fullPath">trả lại full đường dẫn từ trang chủ (vd /image/anh1.jpg) chỉ việc nhét vào src là đc, nếu ko chỉ trả lại tên file</param>
        /// <returns></returns>
        public string save(string rootFolder, string fileName = "", bool fullPath = true)
        {
            try
            {
                if (!rootFolder.EndsWith("/")) rootFolder += "/";
                if (FileUpload1.HasFile)
                {
                    if (",image/jpeg,image/png,image/gif,image/bmp,image/tif,".IndexOf("," + FileUpload1.PostedFile.ContentType.ToLower() + ",") == -1)
                    {
                        throw new Exception("Tệp tin tải lên không phải là ảnh...");
                    }

                    if (FileUpload1.PostedFile.ContentLength > maxFileSize * 1024)
                    {
                        throw new Exception("Tệp tin tải vượt quá kích thước cho phép!!!");
                    }

                    if (string.IsNullOrEmpty(fileName))
                    {
                        fileName = System.IO.Path.GetFileNameWithoutExtension(FileUpload1.FileName);
                        string ex = System.IO.Path.GetExtension(FileUpload1.FileName);
                        while (System.IO.File.Exists(Server.MapPath(rootFolder + fileName + ex)))
                            fileName += ((new Random()).Next()).ToString();
                        fileName += ex;
                    }
                    if (!System.IO.Directory.Exists(Server.MapPath(rootFolder)))
                        System.IO.Directory.CreateDirectory(Server.MapPath(rootFolder));
                    FileUpload1.PostedFile.SaveAs(Server.MapPath(rootFolder + fileName));
                    return (fullPath ? rootFolder.Replace("~/", "/") : "") + fileName;
                }
                else
                {
                    throw new Exception("Không có file tải lên...");
                }
            }
            finally
            {
                regDelFileUploaded();
            }
        }

        /// <summary>
        /// convert ảnh sang base64 dạng text
        /// </summary>
        /// <returns></returns>
        public string ToBase64()
        {
            try
            {
                if (FileUpload1.HasFile)
                { 
                    if (",image/jpeg,image/png,image/gif,image/bmp,image/tif,".IndexOf("," + FileUpload1.PostedFile.ContentType.ToLower() + ",") == -1)
                    {
                        throw new Exception("Tệp tin tải lên không phải là ảnh...");
                    }

                    if (FileUpload1.PostedFile.ContentLength > maxFileSize * 1024)
                    {
                        throw new Exception("Tệp tin tải vượt quá kích thước cho phép!!!");
                    }

                    return "data:" + FileUpload1.PostedFile.ContentType.ToLower() + ";base64," + Convert.ToBase64String(FileUpload1.FileBytes);
                }
                else
                {
                    return "";
                }
            }
            finally
            {
                regDelFileUploaded();
            }
        }

        void regDelFileUploaded()
        {
            X.AddScript(string.Format("Ext.getCmp('{0}_btnDelImageUpload').fireEvent('click');", this.ID));
        }
    }
}