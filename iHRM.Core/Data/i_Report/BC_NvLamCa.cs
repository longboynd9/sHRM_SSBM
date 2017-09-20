using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHRM.Core.i_Report
{
    public class BC_NvLamCa : i_ReportBase
    {
        public BC_NvLamCa()
        {
            Caption = "BC Nhân Viên Làm Ca";
            ProcName = "i_rp_BC_NvLamCa";

            Filters.Add(new i_ReportItem() { DataIndex = "MaNV", Caption = "Mã Nhân viên", DataType = i_ReportDataType.MaNV });
            Filters.Add(new i_ReportItem() { DataIndex = "MaPB", Caption = "Phòng Ban", DataType = i_ReportDataType.PhongBan });
            Filters.Add(new i_ReportItem() { DataIndex = "CaLam", Caption = "Ca Làm", DataType = i_ReportDataType.String,
                DataSource = new i_Report_ItemDataSource() { DisplayField = "ten", ValueField = "id", DataSource = "SELECT id, ten FROM tbCaLamViec" }
            });
            Filters.Add(new i_ReportItem() { DataIndex = "TuNgay", Caption = "Từ ngày", DataType = i_ReportDataType.Date });
            Filters.Add(new i_ReportItem() { DataIndex = "DenNgay", Caption = "Đến ngày", DataType = i_ReportDataType.Date });

            Columns.Add(new i_ReportItem() { DataIndex = "ngay", Caption = "Ngày", DataType = i_ReportDataType.Date });
            Columns.Add(new i_ReportItem() { DataIndex = "EmployeeID", Caption = "Mã NV", DataType = i_ReportDataType.String, Column_Width = 55 });
            Columns.Add(new i_ReportItem() { DataIndex = "EmployeeName", Caption = "Họ và tên", DataType = i_ReportDataType.String, Column_Width = 125 });
            Columns.Add(new i_ReportItem() { DataIndex = "IDCard", Caption = "CMND", DataType = i_ReportDataType.String });
            Columns.Add(new i_ReportItem() { DataIndex = "DepName", Caption = "Phòng ban", DataType = i_ReportDataType.String });
            Columns.Add(new i_ReportItem() { DataIndex = "calam", Caption = "Ca làm", DataType = i_ReportDataType.String });
        }
    }
}
