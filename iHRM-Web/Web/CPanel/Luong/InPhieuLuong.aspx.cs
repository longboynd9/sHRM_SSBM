using System;
using System.Data;
using System.Linq;
using iHRM.WebPC.Base;
using iHRM.Core.Business;

namespace iHRM.WebPC.Cpanel.Luong
{
    public partial class InPhieuLuong : FrontEndPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["m"] != null && Request["y"] != null)
                {
                    Core.Controller.Luong.InPhieuLuong controller = new Core.Controller.Luong.InPhieuLuong();

                    DateTime ngay = new DateTime(int.Parse(Request["y"]), int.Parse(Request["m"]), 1);
                    DateTime tuNgay = new DateTime(ngay.Year, ngay.Month, 17);
                    DateTime denNgay = new DateTime(ngay.AddMonths(1).Year, ngay.AddMonths(1).Month, 16);

                    var dt = controller.GetData(new DateTime(int.Parse(Request["y"]), int.Parse(Request["m"]), 1),
                        int.Parse(Request["soNC"]),
                        Request["empID"],
                        string.IsNullOrWhiteSpace(Request["group1ID"]) ? 0 : Convert.ToInt32(Request["group1ID"]), 
                        Request["dep"],
                        tuNgay,
                        denNgay
                    );

                    Parser.BeginBlock("In");
                    foreach (DataRow dr in dt.Rows)
                    {
                        foreach(DataColumn dc in dt.Columns)
                            Parser.Parse(dc.ColumnName, dr[dc] as string);

                        Parser.ParseBlock("In");
                    }
                    Parser.EndBlock("In");
                }
            }
        }

        protected override string PageView() { return "inPhieuLuong"; }

    }
}