using iHRM.Core.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iHRM.WebPC.UserControl.Master
{
    public partial class Header : WebPart.WebPartBase
    {
        //global::iHRM.Core.Business.Logic.News.DanhMucBaiViet logic = new global::iHRM.Core.Business.Logic.News.DanhMucBaiViet();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void OnGen()
        {
            //var dt = logic.GetMainMenu();
            //var root = dt.Select("parentID IS NULL").FirstOrDefault();
            //string s = GenMenu(DbHelper.DrGetGuid(root, "idDanhMucBV"), dt, 1);
            //Parser.Parse("mainmenu", s);
        }

        string GenMenu(Guid? parentID, DataTable dt, int lv)
        {
            if (lv == 3)
                return "";

            string s = "";
            foreach (DataRow dr in dt.Select("parentID='" + parentID + "'"))
            {
                string link = DbHelper.DrGetString(dr, "link");
                string sub = GenMenu(DbHelper.DrGetGuid(dr, "idDanhMucBV"), dt, lv + 1);
                s += string.Format("<li data-id='{3}'><a href='{0}'>{1}</a>{2}</li>",
                    string.IsNullOrWhiteSpace(link) ? UrlRewrite.Gen_DanhMucBaiViet(dr) : link,
                    DbHelper.DrGetString(dr, global::iHRM.WebPC.Base.FrontEndPageBase.GetLngColumn("ten")),
                    sub == "" ? "" : string.Format("<ul class='sub'>{0}</ul>", sub),
                    DbHelper.DrGetGuid(dr, "idDanhMucBV")
                );
            }

            return s;
        }
    }
}