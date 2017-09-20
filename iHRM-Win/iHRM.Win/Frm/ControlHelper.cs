using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace iHRM.Win.Frm
{

    public enum ControlBinding_DataType { Int, Float, String, Bool, DateTime, TimeSpan, Guid, Image }

    public class ControlBinding
    {
        public string DataIndex { get; set; }
        public DevExpress.XtraEditors.BaseEdit Edit { get; set; }
        public ControlBinding_DataType DataType { get; set; }

        public ControlBinding(string dataIndex, DevExpress.XtraEditors.BaseEdit edit, ControlBinding_DataType dataType)
        {
            DataIndex = dataIndex;
            Edit = edit;
            DataType = dataType;
        }
    }
    public class DlgData
    {
        public string IdColumnName = "";
        public string CaptionColumnName = "";
        public string FormCaption = "";

        public List<ControlBinding> CB = new List<ControlBinding>();
    }

    public class GridColumn1
    {
        public string DataIndex { get; set; }
        public string Caption { get; set; }
        public ControlBinding_DataType DataType { get; set; }
        public bool Visible { get; set; }
        public int Width { get; set; }

        public GridColumn1(string dataIndex, string caption, ControlBinding_DataType dataType, bool visible = true, int width = 0)
        {
            DataIndex = dataIndex;
            Caption = caption;
            DataType = dataType;
            Visible = visible;
            Width = width;
        }
    }
    public class LstData
    {
        public string TableName { get; set; }
        public string IdColumnName { get; set; }
        public string FormCaption { get; set; }

        private List<GridColumn1> grdColumns = new List<GridColumn1>();
        public List<GridColumn1> GrdColumns
        {
            get { return grdColumns; }
            set { grdColumns = value; }
        }
    }
    public class ImportData
    {
        public DataTable DtColumn;
        public ImportData()
        {
            DtColumn = new DataTable();
            DtColumn.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("c1"),
                new DataColumn("c1Text"),
                new DataColumn("c2"),
            });
        }
        public void DtColumn_AddData(string c1, string c1Text, string c2 = "")
        {
            var dr = DtColumn.NewRow();
            dr["c1"] = c1;
            dr["c1Text"] = c1Text;
            dr["c2"] = c2;
            DtColumn.Rows.Add(dr);
        }

        public bool DtColumn_HasData()
        {
            if (DtColumn != null && DtColumn.Rows.Count > 0)
            {
                foreach (DataRow dr in DtColumn.Rows)
                {
                    if (!string.IsNullOrWhiteSpace(dr["c2"] as string))
                        return true;
                }
            }

            return false;
        }

        public Dictionary<string,string> DtColumn_GetData()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (DtColumn != null && DtColumn.Rows.Count > 0)
            {
                foreach (DataRow dr in DtColumn.Rows)
                {
                    if (!string.IsNullOrWhiteSpace(dr["c2"] as string))
                        dic.Add(dr["c1"] as string, dr["c2"] as string);
                }
            }
            return dic;
        }
    }

    public class ControlHelper
    {
    }
}
