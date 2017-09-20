using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHRM.Core.i_Report
{
    public class BC_NghiPhepNam : i_ReportBase
    {
        public BC_NghiPhepNam()
        {
            Caption = "BC nghỉ phép năm";
            ProcName = "i_rp_BC_NghiPhepNam";

            Filters.Add(new i_ReportItem() { DataIndex = "MaPB", Caption = "Phòng Ban", DataType = i_ReportDataType.PhongBan });

            Columns.Add(new i_ReportItem() { DataIndex = "EmployeeID", Caption = "Mã NV", DataType = i_ReportDataType.String, Column_Width = 55 });
            Columns.Add(new i_ReportItem() { DataIndex = "EmployeeName", Caption = "Họ và tên", DataType = i_ReportDataType.String, Column_Width = 125 });
            Columns.Add(new i_ReportItem() { DataIndex = "IDCard", Caption = "CMND", DataType = i_ReportDataType.String });
            Columns.Add(new i_ReportItem() { DataIndex = "AppliedDate", Caption = "Ngày vào", DataType = i_ReportDataType.Date });
            Columns.Add(new i_ReportItem() { DataIndex = "LeftDate", Caption = "Ngày nghỉ làm", DataType = i_ReportDataType.Date });
            Columns.Add(new i_ReportItem() { DataIndex = "PhepNamCu", Caption = "Phép năm", DataType = i_ReportDataType.Float, Format = "0.0" });
            Columns.Add(new i_ReportItem() { DataIndex = "t1", Caption = "T1", DataType = i_ReportDataType.Float, Column_Width = 35 });
            Columns.Add(new i_ReportItem() { DataIndex = "t2", Caption = "T2", DataType = i_ReportDataType.Float, Column_Width = 35 });
            Columns.Add(new i_ReportItem() { DataIndex = "t3", Caption = "T3", DataType = i_ReportDataType.Float, Column_Width = 35 });
            Columns.Add(new i_ReportItem() { DataIndex = "t4", Caption = "T4", DataType = i_ReportDataType.Float, Column_Width = 35 });
            Columns.Add(new i_ReportItem() { DataIndex = "t5", Caption = "T5", DataType = i_ReportDataType.Float, Column_Width = 35 });
            Columns.Add(new i_ReportItem() { DataIndex = "t6", Caption = "T6", DataType = i_ReportDataType.Float, Column_Width = 35 });
            Columns.Add(new i_ReportItem() { DataIndex = "t7", Caption = "T7", DataType = i_ReportDataType.Float, Column_Width = 35 });
            Columns.Add(new i_ReportItem() { DataIndex = "t8", Caption = "T8", DataType = i_ReportDataType.Float, Column_Width = 35 });
            Columns.Add(new i_ReportItem() { DataIndex = "t9", Caption = "T9", DataType = i_ReportDataType.Float, Column_Width = 35 });
            Columns.Add(new i_ReportItem() { DataIndex = "t10", Caption = "T10", DataType = i_ReportDataType.Float, Column_Width = 35 });
            Columns.Add(new i_ReportItem() { DataIndex = "t11", Caption = "T11", DataType = i_ReportDataType.Float, Column_Width = 35 });
            Columns.Add(new i_ReportItem() { DataIndex = "t12", Caption = "T12", DataType = i_ReportDataType.Float, Column_Width = 35 });
            Columns.Add(new i_ReportItem() { DataIndex = "TongNghiPhep", Caption = "Tổng SD", DataType = i_ReportDataType.Float });
            Columns.Add(new i_ReportItem() { DataIndex = "AnnualLeave", Caption = "PN còn lại", DataType = i_ReportDataType.Float });
        }
    }
}
