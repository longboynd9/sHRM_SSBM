using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHRM.Core.i_Report
{
    public class BC_NvDkNghi : i_ReportBase
    {
        public BC_NvDkNghi()
        {
            Caption = "BC Nhân Viên Đăng Ký Nghỉ";
            ProcName = "i_rp_BC_NvDkNghi";

            Filters.Add(new i_ReportItem() { DataIndex = "MaNV", Caption = "Mã Nhân viên", DataType = i_ReportDataType.MaNV });
            Filters.Add(new i_ReportItem() { DataIndex = "MaPB", Caption = "Phòng Ban", DataType = i_ReportDataType.PhongBan });
            Filters.Add(new i_ReportItem() { DataIndex = "LyDo", Caption = "Lý do", DataType = i_ReportDataType.Int,
                DataSource = new i_Report_ItemDataSource() { DisplayField = "lydo", ValueField = "id", DataSource = "SELECT id, lydo FROM tbLyDoVangMat" }
            });
            Filters.Add(new i_ReportItem() { DataIndex = "TuNgay", Caption = "Từ ngày", DataType = i_ReportDataType.Date });
            Filters.Add(new i_ReportItem() { DataIndex = "DenNgay", Caption = "Đến ngày", DataType = i_ReportDataType.Date });

            Columns.Add(new i_ReportItem() { DataIndex = "ngay", Caption = "Ngày", DataType = i_ReportDataType.Date });
            Columns.Add(new i_ReportItem() { DataIndex = "EmployeeID", Caption = "Mã NV", DataType = i_ReportDataType.String, Column_Width = 55 });
            Columns.Add(new i_ReportItem() { DataIndex = "EmployeeName", Caption = "Họ và tên", DataType = i_ReportDataType.String, Column_Width = 125 });
            Columns.Add(new i_ReportItem() { DataIndex = "IDCard", Caption = "CMND", DataType = i_ReportDataType.String });
            Columns.Add(new i_ReportItem() { DataIndex = "DepName", Caption = "Phòng ban", DataType = i_ReportDataType.String });
            Columns.Add(new i_ReportItem() { DataIndex = "LyDoVangMat", Caption = "Lý do", DataType = i_ReportDataType.String });
            Columns.Add(new i_ReportItem() { DataIndex = "nghiCaNgay", Caption = "Nghỉ", DataType = i_ReportDataType.String });
            Columns.Add(new i_ReportItem() { DataIndex = "coHuongLuong", Caption = "Có hưởng lương", DataType = i_ReportDataType.String });
        }
    }
}
