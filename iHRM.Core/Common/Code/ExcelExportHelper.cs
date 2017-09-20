using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;


namespace iHRM.Common.Code
{
    //ducnm - 18/03/2014
    /// <summary>
    /// Thư viện hỗ trợ xuất BC ra excel
    /// </summary>
    public class baseExcelExportHelper : ExcelExtend
    {
        public class ColumnFormater
        {
            public string format { get; set; }
            public bool convert0toEmpty { get; set; }
        }
        public Dictionary<string, ColumnFormater> ColumnFormaters = new Dictionary<string, ColumnFormater>();

        public baseExcelExportHelper() { }
        
        public void FillDataTable(DataTable dt)
        {
            int FirstRow, FirstColumn;
            var lst = GetBC_FillDataHead(out FirstRow, out FirstColumn);
            FillDataTableByHead(dt, FirstRow, FirstColumn, lst);
        }
        public void FillDataTable<T>(IList<T> dt)
        {
            int FirstRow, FirstColumn;
            var lst = GetBC_FillDataHead(out FirstRow, out FirstColumn);
            FillDataTableByHead(dt, FirstRow, FirstColumn, lst);
        }

        private List<string> GetBC_FillDataHead(out int FirstRow, out int FirstColumn)
        {
            FirstRow = 0;
            FirstColumn = 0;
            List<string> lst = new List<string>();
            Aspose.Cells.Range r = GetNamedRange("BC_FillData");
            if (r == null)
                return lst;

            DataTable dtDefine = r.ExportDataTable();
            if (dtDefine.Rows.Count == 0)
                throw new ArgumentException("BC_FillData invalid");

            for (int i = 0; i < dtDefine.Columns.Count; i++)
                lst.Add(dtDefine.Rows[0][i] as string);

            //clear
            for (int i = 0; i < r.ColumnCount; i++)
                r[0, i].PutValue(null);

            FirstRow = r.FirstRow;
            FirstColumn = r.FirstColumn;
            return lst;
        }
        public void FillDataTableByHead(DataTable dt, int rowIdx, int colIdx, List<string> headDataIndex)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                base.InsertRow(rowIdx + i + 1);
                for (int j = 0; j < headDataIndex.Count; j++)
                {
                    string col = headDataIndex[j];
                    if (string.IsNullOrWhiteSpace(col) || col == "#VALUE!")
                        continue;

                    if (col.StartsWith("$"))
                    {
                        switch (col)
                        {
                            case "$STT":
                                WriteToCell(rowIdx + i, colIdx + j, i + 1);
                                break;
                        }
                    }
                    else if (col.StartsWith("#"))
                    {
                        col = col.Substring(1);
                        if (dt.Columns.Contains(col))
                        {
                            object value = dt.Rows[i][col];
                            if (ColumnFormaters.ContainsKey(col))
                            {
                                ColumnFormater cf = ColumnFormaters[col];
                                if (cf.convert0toEmpty)
                                {
                                    if (Convert.ToDecimal((value ?? 0).ToString()) == 0)
                                        value = null;
                                }

                                if (!string.IsNullOrWhiteSpace(cf.format))
                                {
                                    value = string.Format(cf.format, value);
                                }
                            }
                            else
                            {
                                if (value is bool)
                                    value = ((value as bool?) == true ? "Có" : "Không");
                                else if (value is DateTime)
                                    //value = string.Format("{0:dd/MM/yyyy}", value);                                    
                                    value = Convert.ToDateTime(value);
                                else if ((value is int || value is long) && value.ToString().Length > 4)
                                    value = string.Format("{0:#,0}", value);
                                //else if ((value is float || value is double || value is decimal) && value.ToString().Length > 2)
                                //    outputvalue = string.Format("{0:#,0.00}", value);
                            }

                            if (!(value == DBNull.Value || value == null))
                                WriteToCell(rowIdx + i, colIdx + j, value);
                        }
                    }
                }
            }
        }

        public void FillDataTableByHead<T>(IList<T> dt, int rowIdx, int colIdx, List<string> headDataIndex)
        {
            for (int i = 0; i < dt.Count; i++)
            {
                base.InsertRow(rowIdx + i + 1);
                for (int j = 0; j < headDataIndex.Count; j++)
                {
                    string col = headDataIndex[j];
                    if (string.IsNullOrWhiteSpace(col))
                        continue;

                    if (col.StartsWith("$"))
                    {
                        switch (col)
                        {
                            case "$STT":
                                WriteToCell(rowIdx + i, colIdx + j, i + 1);
                                break;
                        }
                    }
                    else if (col.StartsWith("#"))
                    {
                        col = col.Substring(1);
                        T obj = dt[i];

                        var propertyInfo = obj.GetType().GetProperty(col);
                        if (propertyInfo != null)
                        {
                            object value = propertyInfo.GetValue(obj, null);
                            string outputvalue = "";
                            if (value is bool)
                                outputvalue = ((value as bool?) == true ? "Có" : "Không");
                            else if (value is DateTime)
                                outputvalue = string.Format("{0:dd/MM/yyyy}", value);
                            else if ((value is int || value is long) && value.ToString().Length > 4)
                                outputvalue = string.Format("{0:#,0}", value);
                            else if ((value is float || value is double || value is decimal) && value.ToString().Length > 2)
                                outputvalue = string.Format("{0:#,0.00}", value);
                            else
                                outputvalue = string.Format("{0}", value);

                            WriteToCell(rowIdx + i, colIdx + j, outputvalue);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// <para>Tạo nhóm trên datatable</para>
        /// <para>---donvi---phongban---soluong---</para>
        /// <para>----dv1-----pb1--------3</para>
        /// <para>----dv1-----pb2--------2</para>
        /// <para>----dv1-----pb3--------4</para>
        /// <para>----dv2-----pb21-------4</para>
        /// <para>----dv2-----pb22-------1</para>
        /// <para>--></para>
        /// <para>---donvi---phongban---soluong---STT---</para>
        /// <para>----dv1----------------9---------A</para>
        /// <para>------------pb1--------3---------1</para>
        /// <para>------------pb2--------2---------2</para>
        /// <para>------------pb3--------4---------3</para>
        /// <para>----dv2----------------5---------B</para>
        /// <para>------------pb21-------4---------1</para>
        /// <para>------------pb22-------1---------2</para>
        /// </summary>
        /// <param name="dt">datatable</param>
        /// <param name="col2group">tên column muốn nhóm</param>
        /// <param name="col2addSTT">tên cột sẽ thêm STT</param>
        /// <param name="col2compute">Danh sách các cột sẽ tính tổng: tên_cột/phương_thức vd "SoLuong/Sum"</param>
        public static DataTable CreateGroupInDT(DataTable dt0, string col2group, string col2addSTT = "STT", string[] col2compute = null)
        {
            if (dt0 == null)
                return new DataTable();

            string group = "";
            int gCount = 0, gCount2 = 1;
            if (dt0.Rows.Count == 0)
                return new DataTable();

            DataTable dt = dt0.AsEnumerable().OrderBy(i => i[col2group]).CopyToDataTable();
            dt.Columns.Add(col2addSTT);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                if ((dr[col2group] as string) != group)
                {
                    DataRow dr2 = dt.NewRow();
                    dr2[col2addSTT] = IntToAAA(gCount);
                    dr2[col2group] = dr[col2group];
                    if (col2compute != null)
                    {
                        string c1, c2;
                        int i1;
                        foreach (string s in col2compute)
                        {
                            try
                            {
                                i1 = s.IndexOf("/");
                                if (i1 == -1)
                                    throw new ArgumentException("cột tính toán sai định dạng, định dạng chấp nhận: tên_cột/phương_thức vd \"SoLuong/Sum\"");
                                c1 = s.Substring(0, i1);
                                c2 = s.Substring(i1 + 1);
                                dr2[c1] = dt.Compute(string.Format("{1}({0})", c1, c2), col2group + "='" + dr[col2group] + "'");
                            }
                            catch { throw; }
                        }
                    }
                    dt.Rows.InsertAt(dr2, i);
                    group = dr[col2group] as string;
                    gCount += 1;
                    i += 1;
                    gCount2 = 1;
                }

                dr[col2group] = "";
                dr[col2addSTT] = gCount2;
                gCount2 += 1;
            }

            return dt;
        }
        public static string IntToAAA(int i)
        {
            string converted = "";
            int lv = 0;
            while (true)
            {
                converted = (char)('A' - lv + i % 26) + converted;
                i = (int)(i / 26);
                if (i == 0) break;
                lv = 1;
            }
            return converted;
        }
    }

    ////ducnm - 18/03/2014
    ///// <summary>
    ///// Thư viện hỗ trợ xuất BC ra word
    ///// </summary>
    //public class WordExportHelper : WordExtend
    //{
    //    public string BC_donVi { get; set; }
    //    public string BC_ngay { get; set; }
    //    public string BC_title { get; set; }
    //    public string BC_filter { get; set; }
    //    public string BC_description { get; set; }

    //    public WordExportHelper(string reportPath)
    //    {
    //        if (!reportPath.EndsWith(".dotx"))
    //            reportPath += ".dotx";
    //        string filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/ExcelTemplate"), reportPath);
    //        OpenFile(filePath);
    //    }

    //    ~WordExportHelper()
    //    {
    //    }

    //    public static void CreateRownumber(DataTable dt, string colName = "STT")
    //    {
    //        dt.Columns.Add(colName, typeof(int));
    //        for (int i = 0; i < dt.Rows.Count; i++)
    //            dt.Rows[i][colName] = (i + 1);
    //    }

    //    private void FillDataTableByHead<T>(IList<T> dt, int rowIdx, int colIdx, List<string> headDataIndex)
    //    {
    //    }

    //    public void RendAndFlush(string FlushFileName = "")
    //    {
    //        if (string.IsNullOrWhiteSpace(BC_ngay))
    //        {
    //            BC_ngay = string.Format("..... , ngày {0:dd} tháng {0:MM} năm {0:yyyy}", DateTime.Today);
    //        }

    //        WriteToMergeField("BC_donVi", BC_donVi ?? "");
    //        WriteToMergeField("BC_ngay", BC_ngay ?? "");
    //        WriteToMergeField("BC_title", BC_title ?? "");
    //        WriteToMergeField("BC_filter", BC_filter ?? "");
    //        WriteToMergeField("BC_description", BC_description ?? "");


    //        string fileName = string.Format("{0}_{1}.doc", Path.GetFileNameWithoutExtension(base._filePath), Guid.NewGuid().ToString("N"));
    //        string temporaryPath = Path.Combine(HttpContext.Current.Server.MapPath("~/ExcelTemplate/$Temporary"), fileName);
    //        Save(temporaryPath);
    //        HttpContext.Current.Response.Redirect(string.Format("~/ExcelTemplate/Download.aspx?fp={0}&fn={1}",
    //            temporaryPath,
    //            FlushFileName == "" ? HttpContext.Current.Server.UrlEncode(BC_title) : FlushFileName)
    //        );
    //    }
    //}
}