using iHRM.Core.Business;
using iHRM.WebPC.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iHRM.WebPC.Site
{
    public partial class news_cat : global::iHRM.WebPC.Base.FrontEndPageBase
    {
        global::iHRM.Core.Business.Logic.News.BaiViet_Front logic = new global::iHRM.Core.Business.Logic.News.BaiViet_Front();

        protected override string PageView() { return "news_cat"; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var cat = logic.GetDmByIdx(int.Parse(Request["idx"]));

                Parser.Parse("catIdd", DbHelper.DrGetString(cat, "idDanhMucBV"));
                Parser.Parse("catName", DbHelper.DrGetString(cat, GetLngColumn("ten")));
                Parser.Parse("catDesc", DbHelper.DrGetString(cat, GetLngColumn("gioithieu")));

                var dtSub = logic.GetSubDm(DbHelper.DrGetGuid(cat, "idDanhMucBV"));
                if (dtSub == null || dtSub.Rows.Count == 0)
                {
                    Parser.RemoveBlock("SubCat");
                }
                else
                {
                    Parser.BeginBlock("SubCatItem");
                    foreach (System.Data.DataRow dr in dtSub.Rows)
                    {
                        Parser.Parse("SubCatItem_Link", UrlRewrite.Gen_DanhMucBaiViet(dr));
                        Parser.Parse("SubCatItem_Name", DbHelper.DrGetString(dr, GetLngColumn("ten")));

                        var dtSub2 = logic.GetSubDm(DbHelper.DrGetGuid(dr, "idDanhMucBV"));
                        
                        Parser.BeginBlock("SubSubCatItem");
                        foreach (System.Data.DataRow dr2 in dtSub2.Rows)
                        {
                            Parser.Parse("SubSubCatItem_Link", UrlRewrite.Gen_DanhMucBaiViet(dr2));
                            Parser.Parse("SubSubCatItem_Name", DbHelper.DrGetString(dr2, GetLngColumn("ten")));

                            Parser.ParseBlock("SubSubCatItem");
                        }
                        Parser.EndBlock("SubSubCatItem");

                        Parser.ParseBlock("SubCatItem");
                    }
                    Parser.EndBlock("SubCatItem");
                }

                int p = 1;
                if (Request["p"] != null)
                    int.TryParse(Request["p"], out p);
                var dtBV = logic.GetBvInDm(DbHelper.DrGetGuid(cat, "idDanhMucBV"), p, SystemConst.danhMucBV_pageSize);

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

                if (dtBV.Rows.Count < SystemConst.danhMucBV_pageSize)
                {
                    Parser.Parse("cat_linkNextPage_display", "hidden");
                }
                else
                {
                    Parser.Parse("cat_linkNextPage_display", "");
                    Parser.Parse("cat_linkNextPage", Request.Url.AbsolutePath + "?p=" + (p + 1));
                }
            }
        }
    }
}