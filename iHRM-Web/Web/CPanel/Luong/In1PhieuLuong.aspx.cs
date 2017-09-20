using System;
using System.Linq;
using iHRM.WebPC.Base;
using iHRM.WebPC.Classes;
using iHRM.Core.Business;

namespace iHRM.WebPC.Cpanel.Luong
{
    public partial class In1PhieuLuong : FrontEndPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["id"] != null)
                {
                    var db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);
                    var bl = db.tbBangLuongThangs.SingleOrDefault(i => i.id == new Guid(Request["id"]));
                    int soNC = Convert.ToInt16(Request["soNC"]);

                    if (bl != null)
                    {
                        Response.Redirect(string.Format("~/Cpanel/Luong/InPhieuLuong.aspx?m={0}&y={1}&soNC={2}&empID={3}",
                            bl.thang.Value.Month, bl.thang.Value.Year,soNC, bl.empoyeeID
                        ));
                    }
                }
            }
        }

        protected override string PageView() { return "inPhieuLuong"; }
    }
}