using iHRM.Core.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iHRM.WebPC.WebPart.web.Master
{
    public partial class Footer : WebPart.WebPartBase
    {
        //global::iHRM.Core.Business.Logic.News.DanhMucBaiViet logic = new global::iHRM.Core.Business.Logic.News.DanhMucBaiViet();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void OnGen()
        {
            //var dt = logic.GetMainMenu();
            //var root = dt.Select("parentID IS NULL").FirstOrDefault();
            //Parser.BeginBlock("mainmenu");
            //foreach (DataRow dr in dt.Select("parentID='" + DbHelper.DrGetGuid(root, "idDanhMucBV") + "'").OrderBy(i => i["displayOrder"]))
            //{
            //    string link = DbHelper.DrGetString(dr, "link");
            //    Parser.Parse("link", string.IsNullOrWhiteSpace(link) ? UrlRewrite.Gen_DanhMucBaiViet(dr) : link);
            //    Parser.Parse("name", DbHelper.DrGetString(dr, global::iHRM.WebPC.Base.FrontEndPageBase.GetLngColumn("ten")));
            //    Parser.ParseBlock("mainmenu");
            //}
            //Parser.EndBlock("mainmenu");
        }
    }
}