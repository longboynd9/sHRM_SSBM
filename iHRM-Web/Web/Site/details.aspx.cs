using iHRM.Core.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iHRM.WebPC.Site
{
    public partial class details : global::iHRM.WebPC.Base.FrontEndPageBase
    {
        protected override string PageView() { return "details"; }

        protected void Page_Load(object sender, EventArgs e)
        {
            DataRow bv = (new global::iHRM.Core.Business.Logic.News.BaiViet()).GetByIdx(int.Parse("0" + Request["idx"]));

            Parser.Parse("title", DbHelper.DrGetString(bv, GetLngColumn("tieude")));
            //Parser.Parse("avatar", DbHelper.DrGetString(bv, "anhDaiDien"));
            Parser.Parse("content", DbHelper.DrGetString(bv, GetLngColumn("noidung")));

            Parser.Parse("catID", DbHelper.DrGetString(bv, "idDanhMuc"));
        }

    }
}