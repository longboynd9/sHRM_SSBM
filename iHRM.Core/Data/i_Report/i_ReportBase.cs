using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHRM.Core.i_Report
{
    public enum i_ReportDataType { Int, Float, Date, String, Bool, MaNV, PhongBan }

    public class i_Report_ItemDataSource
    {
        public string DisplayField { get; set; }
        public string ValueField { get; set; }
        public string DataSource { get; set; }
    }

    public class i_ReportItem
    {
        public string DataIndex { get; set; }
        public i_ReportDataType DataType { get; set; }
        public string Caption { get; set; }
        public string Format { get; set; }
        public int Column_Width { get; set; }

        public i_Report_ItemDataSource DataSource { get; set; }
    }

    public class i_ReportBase
    {
        public string Caption { get; set; }
        public string ProcName { get; set; }
        public string ExcelName { get; set; }

        public List<i_ReportItem> Filters = new List<i_ReportItem>();
        public List<i_ReportItem> Columns = new List<i_ReportItem>();
    }
}
