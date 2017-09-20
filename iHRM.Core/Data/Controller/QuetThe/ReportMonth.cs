using iHRM.Core.Business.DbObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using iHRM.Core.Business.Logic.ChamCong;
using iHRM.Core.Business;
using System.Data.SqlClient;
using iHRM.Common.Code;

namespace iHRM.Core.Controller.QuetThe
{
    public class ReportMonth : LogicBase
    {
        ReportMonthLogic logic = new ReportMonthLogic();

        public DataTable GetData(string empID, string depID, int? group1ID, DateTime tuNgay, DateTime denNgay, bool isWinform = false)
        {
            DataTable dtData;
            if (!string.IsNullOrWhiteSpace(empID))
            {
                dtData = logic.GetReportMonth_4Emp(tuNgay, denNgay, empID);
            }
            else if (group1ID > 0)
            {
                dtData = logic.GetReportMonth_4Group1(tuNgay, denNgay, group1ID);
            }
            else
            {
                dtData = logic.GetReportMonth(tuNgay, denNgay, depID);
            }

            if (dtData == null || dtData.Rows.Count == 0)
                return dtData;

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("EmployeeID"),
                new DataColumn("tenNV"),
                new DataColumn("ngayVao", typeof(DateTime)),
                new DataColumn("TeamName"),
                new DataColumn("LineName"),
                new DataColumn("DepName"),
                new DataColumn("D1"),
                new DataColumn("D2"),
                new DataColumn("D3"),
                new DataColumn("D4"),
                new DataColumn("D5"),
                new DataColumn("D6"),
                new DataColumn("D7"),
                new DataColumn("D8"),
                new DataColumn("D9"),
                new DataColumn("D10"),
                new DataColumn("D11"),
                new DataColumn("D12"),
                new DataColumn("D13"),
                new DataColumn("D14"),
                new DataColumn("D15"),
                new DataColumn("D16"),
                new DataColumn("D17"),
                new DataColumn("D18"),
                new DataColumn("D19"),
                new DataColumn("D20"),
                new DataColumn("D21"),
                new DataColumn("D22"),
                new DataColumn("D23"),
                new DataColumn("D24"),
                new DataColumn("D25"),
                new DataColumn("D26"),
                new DataColumn("D27"),
                new DataColumn("D28"),
                new DataColumn("D29"),
                new DataColumn("D30"),
                new DataColumn("D31"),
                new DataColumn("Total")
            });

            foreach (DataRow dr in dtData.Rows)
            {
                DataRow r = null;

                var r1 = dt.Select("EmployeeID='" + dr["EmployeeID"]+"'");
                if (r1 == null || r1.Length == 0)
                {
                    r = dt.NewRow();
                    r["EmployeeID"] = dr["EmployeeID"];
                    r["tenNV"] = dr["EmployeeName"];
                    r["ngayVao"] = dr["AppliedDate"];
                    r["TeamName"] = dr["TeamName"];
                    r["LineName"] = dr["LineName"];
                    r["DepName"] = dr["DepName"];
                    r["Total"] = "0";
                    dt.Rows.Add(r);
                }
                else
                {
                    r = r1[0];
                }
                r["D" + ((DateTime)dr["ngay"]).Day] = Helper.GetTrangThai(dr, 1, isWinform);
                r["Total"] = Convert.ToDouble(r["Total"]) + (dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"]));
            }

            return dt;
        }
    }
}
