using iHRM.Core.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iHRM.WebPC.Site
{
    public partial class search : global::iHRM.WebPC.Base.FrontEndPageBase
    {
        global::iHRM.Core.Business.Logic.News.BaiViet_Front logic = new global::iHRM.Core.Business.Logic.News.BaiViet_Front();

        protected override string PageView() { return "search"; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string searchText = Request["search_block_form"];
            Parser.Parse("search-text", searchText);
            
            if (!IsPostBack)
            {
                var dtBV = logic.Search(searchText);

                if (dtBV.Rows.Count == 1)
                {
                    Response.Redirect("~" + UrlRewrite.Gen_BaiViet(dtBV.Rows[0]));
                    return;
                }

                Parser.BeginBlock("LstBV");
                foreach (System.Data.DataRow dr in dtBV.Rows)
                {
                    Parser.Parse("LstBV_link", UrlRewrite.Gen_BaiViet(dr));
                    Parser.Parse("LstBV_img", GenPathInUploadFolder(DbHelper.DrGetString(dr, "anhDaiDien")));
                    Parser.Parse("LstBV_title", DbHelper.DrGetString(dr, GetLngColumn("tieude")));
                    Parser.Parse("LstBV_desc", DbHelper.DrGetString(dr, GetLngColumn("gioithieu")));

                    Parser.ParseBlock("LstBV");
                }
                Parser.EndBlock("LstBV");

            }
        }
    }
}