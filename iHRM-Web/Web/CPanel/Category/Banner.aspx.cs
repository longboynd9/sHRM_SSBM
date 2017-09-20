using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.IO;
using iHRM.WebPC.Code; using iHRM.Common.Code;

namespace iHRM.WebPC.Cpanel.Category
{
    public partial class Banner : BackEndPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack && !X.IsAjaxRequest)
            {
                Lng.Web_Language.Lng_SetControlTexts(this);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveImage(ImageUploader1);
            SaveImage(ImageUploader2);

            Tools.message(Lng.Category_Banner.msg_1);
        }

        void SaveImage(global::iHRM.WebPC.Cpanel.UC.ImageUploader up)
        {
            if (up.hasFile)
            {
                string p = up.imgUrl;
                up.save("~" + Path.GetDirectoryName(p).Replace("\\", "/"), Path.GetFileName(p));
            }
        }
    }
}