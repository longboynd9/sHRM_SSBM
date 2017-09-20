using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHRM.Core.i_Report
{
    public class BC_NvThaiSan : i_ReportBase
    {
        public BC_NvThaiSan()
        {
            Caption = "BC Nhân Viên Thai Sản";
            ProcName = "i_rp_BC_NvThaiSan";
            ExcelName = "BC_NvThaiSan";

            Filters.Add(new i_ReportItem() { DataIndex = "MaPB", Caption = "Phòng Ban", DataType = i_ReportDataType.PhongBan });

            Columns.Add(new i_ReportItem() { DataIndex = "EmployeeID", Caption = "Mã NV", DataType = i_ReportDataType.String, Column_Width = 55 });
            Columns.Add(new i_ReportItem() { DataIndex = "EmployeeName", Caption = "Họ và tên", DataType = i_ReportDataType.String, Column_Width = 125 });
            Columns.Add(new i_ReportItem() { DataIndex = "IDCard", Caption = "CMND", DataType = i_ReportDataType.String });
            Columns.Add(new i_ReportItem() { DataIndex = "AppliedDate", Caption = "Ngày vào", DataType = i_ReportDataType.Date });
            Columns.Add(new i_ReportItem() { DataIndex = "LeftDate", Caption = "Ngày nghỉ làm", DataType = i_ReportDataType.Date });
            Columns.Add(new i_ReportItem() { DataIndex = "DepName", Caption = "Phòng ban", DataType = i_ReportDataType.String });
            Columns.Add(new i_ReportItem() { DataIndex = "tuNgay", Caption = "Từ ngày", DataType = i_ReportDataType.Date });
            Columns.Add(new i_ReportItem() { DataIndex = "denNgay", Caption = "Đến ngày", DataType = i_ReportDataType.Date });
        }
    }
}
