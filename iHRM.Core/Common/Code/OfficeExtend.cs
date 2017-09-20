using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Cells;
using System.IO;
using System.Data;
//using Aspose.Words;
//using Aspose.Words.Tables;
using System.Drawing;

namespace iHRM.Common.Code
{
    //ducnm 2014-02-19
    public partial class ExcelExtend
    {
        #region define

        //ducnm 2014-02-19
        /// <summary>
        /// vị trí vẽ viền cho ô
        /// </summary>
        public enum BorderPosition
        {
            Top = 1,
            Right = 2,
            Bottom = 4,
            Left = 8,
            DiagonalDown = 16,
            DiagonalUp = 32,
            Around = 15,
            All = 63,
            Full = 64
        }
        #endregion

        #region Fields
        protected Workbook _workbook = null;
        protected Worksheet _worksheet = null;
        protected string _filePath = "";

        public string ActiveSheet
        {
            get
            {
                return _worksheet == null ? "" : _worksheet.Name;
            }
            set
            {
                _worksheet = _workbook.Worksheets[value];
                if (_worksheet == null)
                    throw new Exception("Can not find the sheet: " + value);
            }
        }
        #endregion

        #region Intruction
        public void OpenFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new Exception("Can't find file: \n" + filePath);

            try
            {
                _filePath = filePath;
                _workbook = new Workbook();
                _workbook.Open(filePath);
                _worksheet = _workbook.Worksheets[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void NewFile()
        {
            try
            {
                _workbook = new Workbook();
                _worksheet = _workbook.Worksheets[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Methods
        public void ClearPageBreak()
        {
            _worksheet.VPageBreaks.Clear();
            _worksheet.HPageBreaks.Clear();
        }
        public void removeHorginPageBreakAt(int row)
        {
            _worksheet.HPageBreaks.RemoveAt(row);
        }
        public void removeVerticalPageBreakAt(int col)
        {
            _worksheet.VPageBreaks.RemoveAt(col);
        }
        /// <summary>
        /// Author: Bùi Văn Long
        /// </summary>
        /// <param name="row"> dòng set Pagebreak</param>
        /// <param name="col"> cột set Pagebreak</param>
        public void setPageBreakAtCell(int row, int col)
        {
            _worksheet.HPageBreaks.Add(row, col);
            _worksheet.VPageBreaks.Add(row, col);
        }
        /// <summary>
        /// Author: Bùi Văn Long
        /// </summary>
        /// <param name="name">Tên ô setPageBreak</param>
        public void setHorPageBreakAtCell(string name)
        {
            _worksheet.HPageBreaks.Add(name);
        }
        /// <summary>
        /// Author: Bùi Văn Long
        /// </summary>
        /// <param name="name">Tên ô setPageBreak</param>
        public void setVerPageBreakAtCell(string name)
        {
            _worksheet.VPageBreaks.Add(name); 
        }
        public void setPageBreakPreview(bool IsPageBreakPreview)
        {
            _worksheet.IsPageBreakPreview = IsPageBreakPreview;
        }
        #region WriteDataTable
        /// <summary>
        /// Author: Nguyễn Đức Thuận
        /// Created on: 05/07/2011  5:46 CH
        /// Todo: Insert data từ datatable vào sheet
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="SheetName">Name of the sheet.</param>
        /// <param name="firstRow">The first row.</param>
        /// <param name="firstCollumn">The first collumn.</param>
        public void WriteDataTable(DataTable dataTable, int firstRow, int firstCollumn)
        {
            try
            {
                _worksheet.Cells.ImportDataTable(dataTable, false, firstRow, firstCollumn, true);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public void ConvertStringToNumericValue()
        {
            _worksheet.Cells.ConvertStringToNumericValue();
        }
        /// <summary>
        /// Author: Nguyễn Đức Thuận
        /// Created on: 05/07/2011  5:46 CH
        /// Todo: Insert data từ datatable vào sheet
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="firstRow">The first row.</param>
        /// <param name="firstCollumn">The first collumn.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="collumnNumber">The collumn number.</param>
        /// <param name="isAllData">if set to <c>true</c> [is all data].</param>        
        public void WriteDataTable(DataTable dataTable, int firstRow, int firstCollumn, int rowNumber, int collumnNumber, bool isAllData)
        {
            try
            {
                if (!isAllData)
                    _worksheet.Cells.ImportDataTable(dataTable, false, firstRow, firstCollumn, rowNumber, collumnNumber);
                else
                    _worksheet.Cells.ImportDataTable(dataTable, false, firstRow, firstCollumn);

                _worksheet.Cells.DeleteRow(firstRow + dataTable.Rows.Count);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Author: Nguyen Duc Thuan
        /// Created on: 7/18/2011  5:58 PM
        /// Todo: Import data tu table co group du lieu
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="firstRow">The first row.</param>
        /// <param name="firstCollumn">The first collumn.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="collumnNumber">The collumn number.</param>
        /// <param name="groupName">Name of the group. Ten truong can group khi fill len excel</param>
        public void WriteDataTable(DataTable dataTable, int firstRow, int firstCollumn, int rowNumber, int collumnNumber, string groupName)
        {
            try
            {
                if (collumnNumber.Equals(0))
                {
                    collumnNumber = dataTable.Columns.Count;
                }
                string filter;
                DataTable dt = dataTable.Clone();
                List<string> groups = (from r in dataTable.AsEnumerable()
                                       group r by new { groupName = r.Field<string>(groupName) } into m
                                       select m.Key.groupName).ToList();


                foreach (string value in groups)
                {
                    //Tao row moi
                    _worksheet.Cells.InsertRow(firstRow);
                    //merge cell insert name group
                    _worksheet.Cells.Merge(firstRow, firstCollumn, 1, collumnNumber);

                    WriteToCell(firstRow, firstCollumn, value);

                    firstRow++;

                    filter = " " + groupName + " = '" + value + "' ";
                    //Select all row cung group
                    dt.Rows.Add(dataTable.Select(filter));
                    //INsert cac row cuung group
                    WriteDataTable(dt, firstRow, firstCollumn, dt.Rows.Count, collumnNumber - 1, false);

                    //foreach (DataRow row in rows)
                    //{
                    //    //Tao row moi
                    //    worksheet.Cells.InsertRow(firstRow);
                    //    //IMport row
                    //    worksheet.Cells.ImportDataRow(row, firstRow, firstCollumn);
                    //    firstRow++;
                    //}

                }

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //ducnm 17-11-2014
        /// <summary>
        /// lấy tất cả dữ liệu ở sheet
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllAvalidData()
        {
            try
            {
                return _worksheet.Cells.ExportDataTable(0, 0, _worksheet.Cells.MaxDataRow + 1, _worksheet.Cells.MaxDataColumn + 1, true);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        #endregion

        #region WriteToCell
        //ducnm 2014-02-19
        /// <summary>
        /// Thực hiện set value cho cell
        /// </summary>
        /// <param name="cellName">Tên của ô (VD "B6")</param>
        /// <param name="value">Giá trị</param>
        public bool WriteToCell(string cellName, object value)
        {
            Aspose.Cells.Cell cell = _worksheet.Cells[cellName];
            return WriteToCell(cell.Row, cell.Column, value);
        }

        //ducnm 2014-02-19
        /// <summary>
        /// Thực hiện set value cho cell
        /// </summary>
        /// <param name="rowIndex">chỉ số dòng (dòng 1 chỉ số là 0)</param>
        /// <param name="colIndex">chỉ số cột (cột A chỉ số là 1)</param>
        /// <param name="value">giá trị của ô</param>
        /// <returns></returns>
        public bool WriteToCell(int rowIndex, int colIndex, object value)
        {
            try
            {
                object[] obj = new object[1] { value };
                _worksheet.Cells.ImportObjectArray(obj, rowIndex, colIndex, false);
                return true;
            }
            catch { }
            return false;
        }

        #endregion
        #region Border

        //ducnm 2014-02-19
        /// <summary>
        /// Thực hiện đặt viền cho ô
        /// </summary>
        /// <param name="cellName">Tên của ô (VD "B6")</param>
        /// <param name="position">Vị trí viền (mặc định viền xung quanh)</param>
        /// <param name="color">màu viền (mặc định đen)</param>
        public bool SetCellBorder(string cellName, BorderPosition position = BorderPosition.Around, System.Drawing.Color? color = null)
        {
            Aspose.Cells.Cell cell = _worksheet.Cells[cellName];
            return SetCellBorder(cell, position, color);
        }

        //ducnm 2014-02-19
        /// <summary>
        /// Thực hiện đặt viền cho ô
        /// </summary>
        /// <param name="rowIndex">chỉ số dòng (dòng 1 chỉ số là 0)</param>
        /// <param name="colIndex">chỉ số cột (cột A chỉ số là 1)</param>
        /// <param name="position">Vị trí viền (mặc định viền xung quanh)</param>
        /// <param name="color">màu viền (mặc định đen)</param>
        /// <returns></returns>
        public bool SetCellBorder(int rowIndex, int colIndex, BorderPosition position = BorderPosition.Around, System.Drawing.Color? color = null)
        {
            Aspose.Cells.Cell cell = _worksheet.Cells[rowIndex, colIndex];
            return SetCellBorder(cell, position, color);
        }

        //ducnm 2014-02-19
        /// <summary>
        /// Tạo viền cho ô
        /// </summary>        
        /// <param name="cell"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        private bool SetCellBorder(Aspose.Cells.Cell cell, BorderPosition position = BorderPosition.Around, System.Drawing.Color? color = null)
        {
            try
            {
                System.Drawing.Color c = color ?? System.Drawing.Color.Black;
                Aspose.Cells.Style style = cell.GetStyle();

                if (((int)position & (int)BorderPosition.Top) == (int)BorderPosition.Top)
                {
                    style.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
                    style.Borders[Aspose.Cells.BorderType.TopBorder].Color = c;
                }
                if (((int)position & (int)BorderPosition.Right) == (int)BorderPosition.Right)
                {
                    style.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
                    style.Borders[Aspose.Cells.BorderType.RightBorder].Color = c;
                }
                if (((int)position & (int)BorderPosition.Bottom) == (int)BorderPosition.Bottom)
                {
                    style.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
                    style.Borders[Aspose.Cells.BorderType.BottomBorder].Color = c;
                }
                if (((int)position & (int)BorderPosition.Left) == (int)BorderPosition.Left)
                {
                    style.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
                    style.Borders[Aspose.Cells.BorderType.LeftBorder].Color = c;
                }
                if (((int)position & (int)BorderPosition.DiagonalDown) == (int)BorderPosition.DiagonalDown)
                {
                    style.Borders[Aspose.Cells.BorderType.DiagonalDown].LineStyle = Aspose.Cells.CellBorderType.Thin;
                    style.Borders[Aspose.Cells.BorderType.DiagonalDown].Color = c;
                }
                if ((((int)position & (int)BorderPosition.DiagonalUp) == (int)BorderPosition.DiagonalUp) || (position == BorderPosition.Full))
                {
                    style.Borders[Aspose.Cells.BorderType.DiagonalUp].LineStyle = Aspose.Cells.CellBorderType.Thin;
                    style.Borders[Aspose.Cells.BorderType.DiagonalUp].Color = c;
                }

                //Apply the border styles to the cell
                cell.SetStyle(style);
                return true;
            }
            catch { }
            return false;
        }

        //ducnm 2014-02-17
        /// <summary>
        /// Tạo viền cho nhóm ô
        /// </summary>
        /// <param name="topLeftCellName">Tên ô đầu (phía trên bên trái) vd "A1"</param>
        /// <param name="bottomRightCellName">Tên ô (phía dưới bên phải) vd "B4"</param>
        /// <param name="position">Vị trí của viền</param>
        /// <param name="color">Màu của viền</param>
        public void SetRangeBorder(string topLeftCellName, string bottomRightCellName, BorderPosition position = BorderPosition.Around, System.Drawing.Color? color = null)
        {
            Aspose.Cells.Range range = _worksheet.Cells.CreateRange(topLeftCellName, bottomRightCellName);
            SetRangeBorder(range, position, color);
        }

        //ducnm 2014-02-17
        /// <summary>
        /// Tạo viền cho nhóm ô
        /// </summary>
        /// <param name="rowIndex">chỉ số dòng (dòng 1 chỉ số là 0)</param>
        /// <param name="colIndex">chỉ số cột (cột A chỉ số là 1)</param>
        /// <param name="rowNumber">có bao nhiêu dòng</param>
        /// <param name="collumnNumber">bao nhiêu cột</param>
        /// <param name="position">Vị trí của viền</param>
        /// <param name="color">Màu của viền</param>
        public void SetRangeBorder(int firstRow, int firstColumn, int rowNumber, int columnNumber, BorderPosition position = BorderPosition.Around, System.Drawing.Color? color = null)
        {
            Aspose.Cells.Range range = _worksheet.Cells.CreateRange(firstRow, firstColumn, rowNumber, columnNumber);
            SetRangeBorder(range, position, color);
        }

        //ducnm 2014-02-17
        /// <summary>
        /// tạo viền cho range
        /// </summary>
        /// <param name="range"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        private void SetRangeBorder(Aspose.Cells.Range range, BorderPosition position = BorderPosition.Around, System.Drawing.Color? color = null)
        {
            System.Drawing.Color c = color ?? System.Drawing.Color.Black;
            if (((int)position & (int)BorderPosition.Top) == (int)BorderPosition.Top) range.SetOutlineBorder(Aspose.Cells.BorderType.TopBorder, CellBorderType.Thin, c);
            if (((int)position & (int)BorderPosition.Right) == (int)BorderPosition.Right) range.SetOutlineBorder(Aspose.Cells.BorderType.RightBorder, CellBorderType.Thin, c);
            if (((int)position & (int)BorderPosition.Bottom) == (int)BorderPosition.Bottom) range.SetOutlineBorder(Aspose.Cells.BorderType.BottomBorder, CellBorderType.Thin, c);
            if (((int)position & (int)BorderPosition.Left) == (int)BorderPosition.Left) range.SetOutlineBorder(Aspose.Cells.BorderType.LeftBorder, CellBorderType.Thin, c);
            if (((int)position & (int)BorderPosition.DiagonalDown) == (int)BorderPosition.DiagonalDown) range.SetOutlineBorder(Aspose.Cells.BorderType.DiagonalDown, CellBorderType.Thin, c);
            if (((int)position & (int)BorderPosition.DiagonalUp) == (int)BorderPosition.DiagonalUp) range.SetOutlineBorder(Aspose.Cells.BorderType.DiagonalUp, CellBorderType.Thin, c);

            if (((int)position & (int)BorderPosition.Full) == (int)BorderPosition.Full)
            {
                for (int i = 0; i < range.RowCount; i++)
                    for (int j = 0; j < range.ColumnCount; j++)
                        SetCellBorder(range.FirstRow + i, range.FirstColumn + j);
            }
        }
        #endregion

        #region Bg color

        //ducnm 2014-02-25
        /// <summary>
        /// Thực hiện đặt mầu nền cho ô
        /// </summary>
        /// <param name="rowIndex">chỉ số dòng (dòng 1 chỉ số là 0)</param>
        /// <param name="colIndex">chỉ số cột (cột A chỉ số là 1)</param>
        /// <param name="color">màu nền (mặc định trắng)</param>
        /// <returns></returns>
        public void SetCellBgColor(int rowIndex, int colIndex, Color? color = null)
        {
            Color c = color ?? Color.White;
            Aspose.Cells.Cell cell = _worksheet.Cells[rowIndex, colIndex];
            cell.GetStyle().BackgroundColor = c;
        }

        //ducnm 2014-02-25
        /// <summary>
        /// Tô mầu nền cho nhóm ô
        /// </summary>
        /// <param name="topLeftCellName">Tên ô đầu (phía trên bên trái) vd "A1"</param>
        /// <param name="bottomRightCellName">Tên ô (phía dưới bên phải) vd "B4"</param>
        /// <param name="color">Màu của nền</param>
        public void SetRangeBgColor(string topLeftCellName, string bottomRightCellName, System.Drawing.Color? color = null)
        {
            Aspose.Cells.Range range = _worksheet.Cells.CreateRange(topLeftCellName, bottomRightCellName);
            SetRangeBgColor(range, color);
        }

        //ducnm 2014-02-25
        /// <summary>
        /// Tô nền cho nhóm ô
        /// </summary>
        /// <param name="rowIndex">chỉ số dòng (dòng 1 chỉ số là 0)</param>
        /// <param name="colIndex">chỉ số cột (cột A chỉ số là 1)</param>
        /// <param name="rowNumber">có bao nhiêu dòng</param>
        /// <param name="collumnNumber">bao nhiêu cột</param>
        /// <param name="color">Màu của viền</param>
        public void SetRangeBgColor(int firstRow, int firstColumn, int rowNumber, int columnNumber, System.Drawing.Color? color = null)
        {
            Aspose.Cells.Range range = _worksheet.Cells.CreateRange(firstRow, firstColumn, rowNumber, columnNumber);
            SetRangeBgColor(range, color);
        }

        //ducnm 2014-02-25
        /// <summary>
        /// tô nền cho range
        /// </summary>
        /// <param name="range"></param>
        /// <param name="color"></param>
        private void SetRangeBgColor(Aspose.Cells.Range range, System.Drawing.Color? color = null)
        {
            System.Drawing.Color c = color ?? System.Drawing.Color.White;
            //Aspose.Cells.Style s = range.Style ?? range[0, 0].GetStyle();
            Aspose.Cells.Style s = range[0, 0].GetStyle();
            s.BackgroundColor = c;
            s.Update();
            range.ApplyStyle(s, (new StyleFlag() { All = true }));
        }
        #endregion

        #region FreezePanes

        /// <summary>
        /// FreezePanes
        /// </summary>
        /// <param name="cellName">Tên cột</param>
        /// <param name="freezedRow"></param>
        /// <param name="freezedCol"></param>
        public void FreezePanes(string cellName)
        {
            Aspose.Cells.Cell cell = _worksheet.Cells[cellName];
            _worksheet.FreezePanes(cellName, cell.Row, cell.Column);
        }

        /// <summary>
        /// FreezePanes
        /// </summary>
        /// <param name="rowIdx"></param>
        /// <param name="colIdx"></param>
        /// <param name="freezedRow"></param>
        /// <param name="freezedCol"></param>
        public void FreezePanes(int freezedRow, int freezedCol)
        {
            _worksheet.FreezePanes(freezedRow, freezedCol, freezedRow, freezedCol);
        }

        /// <summary>
        /// UnFreezePanes
        /// </summary>
        public void UnFreezePanes()
        {
            _worksheet.UnFreezePanes();
        }
        #endregion

        #region Merge

        //Nguyen Duc Thuan 2011-08-08
        /// <summary>
        /// Merge cells sheet
        /// </summary>
        /// <param name="firstRow">The first row.</param>
        /// <param name="firstCollumn">The first collumn.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="collumnNumber">The collumn number.</param>
        public void Merge(int firstRow, int firstCollumn, int rowNumber, int collumnNumber)
        {
            _worksheet.Cells.Merge(firstRow, firstCollumn, rowNumber, collumnNumber);
        }

        //ducnm 2014-02-19
        /// <summary>
        /// Merge cells
        /// </summary>
        /// <param name="cellNameStart">tên của ô bắt đầu merge</param>
        /// <param name="rowNumber">số dòng muốn merge</param>
        /// <param name="collumnNumber">số cột muốn merge</param>
        public void Merge(string cellNameStart, int rowNumber, int collumnNumber)
        {
            Aspose.Cells.Cell cell = _worksheet.Cells[cellNameStart];
            _worksheet.Cells.Merge(cell.Row, cell.Column, rowNumber, collumnNumber);
        }

        //ducnm 2014-02-19
        /// <summary>
        /// Merge cells
        /// </summary>
        /// <param name="cellNameStart">tên của ô bắt đầu merge</param>
        /// <param name="cellNameEnd">tên của ô merge đến</param>
        public void Merge(string cellNameStart, string cellNameEnd)
        {
            Aspose.Cells.Range range = _worksheet.Cells.CreateRange(cellNameStart, cellNameEnd);
            range.Merge();
        }

        #endregion

        #region Range
        public Aspose.Cells.Range GetNamedRange(string NamedRangeName)
        {
            Aspose.Cells.Range r = _workbook.Worksheets.GetRangeByName(string.Format("{0}!{1}", ActiveSheet, NamedRangeName));
            if (r == null)
                r = _workbook.Worksheets.GetRangeByName(NamedRangeName);
            return r;
        }
        public bool SetNamedRangeValue(string NamedRangeName, object value)
        {
            Aspose.Cells.Range range = GetNamedRange(NamedRangeName);
            if (range == null)
                return false;
            range[0, 0].PutValue(value);
            return true;
        }
        public object GetNamedRangeValue(string NamedRangeName)
        {
            Aspose.Cells.Range range = GetNamedRange(NamedRangeName);
            if (range == null)
                return null;
            return range[0, 0].Value;
        }
        #endregion

        #region Insert/Copy/Delete

        /// <summary>
        /// Chèn dòng
        /// </summary>
        /// <param name="rowIndex">chỉ số của dòng (dòng 1 chỉ số là 0)</param>
        public void InsertRow(int rowIndex)
        {
            _worksheet.Cells.InsertRow(rowIndex);
        }

        /// <summary>
        /// Chèn cột
        /// </summary>
        /// <param name="columnIndex">Chỉ số của cột (cột A chỉ số là 1)</param>
        public void InsertColumn(int columnIndex)
        {
            _worksheet.Cells.InsertColumn(columnIndex);
        }

        /// <summary>
        /// Xóa dòng
        /// </summary>
        /// <param name="rowIndex">chỉ số của dòng (dòng 1 chỉ số là 0)</param>
        public void DeleteRow(int rowIndex)
        {
            _worksheet.Cells.DeleteRow(rowIndex);
        }

        /// <summary>
        /// Xóa cột
        /// </summary>
        /// <param name="columnIndex">Chỉ số của cột (cột A chỉ số là 1)</param>
        public void DeleteColumn(int colIndex)
        {
            _worksheet.Cells.DeleteColumn(colIndex);
        }

        /// <summary>
        /// Copy row
        /// </summary>
        /// <param name="srcRowIndex">Index of the SRC row (index start at 0)</param>
        /// <param name="desRowIndex">Index of the DES row (index start at 0)</param>
        public void CopyRow(int srcRowIndex, int desRowIndex)
        {
            _worksheet.Cells.CopyRow(null, srcRowIndex, desRowIndex);
        }

        /// <summary>
        /// Ẩn dòng
        /// </summary>
        /// <param name="row">The row index (index start at 0)</param>
        public void Hide(int rowIndex)
        {
            _worksheet.Cells.HideRow(rowIndex);
        }
        #endregion

        #region misc

        /// <summary>
        /// thêm mới sheet
        /// </summary>
        /// <param name="sheetName"></param>
        public void AddSheet(string sheetName)
        {
            _worksheet = _workbook.Worksheets.Add(sheetName);
        }

        /// <summary>
        /// Save file 
        /// </summary>
        public void Save()
        {
            if (_filePath == "")
                throw new Exception("File path???");
            _workbook.Save(_filePath);
        }

        /// <summary>
        /// Save file 
        /// </summary>
        /// <param name="fileName">The path of file.</param>
        public void Save(string filePath)
        {
            _workbook.Save(filePath);
        }
        #endregion
        #endregion
    }

    ////ducnm 2014-03-27
    //public partial class WordExtend
    //{
    //    protected static bool indebugMode = true;

    //    #region define
    //    public enum FontStyle
    //    {
    //        None = 0, Bold = 1, Italic = 2, StrikeThrough = 4, Subscript = 8, Superscript = 16, SmallCaps = 64, Outline = 128, AllCaps = 256
    //    }
    //    #endregion

    //    #region Fields
    //    protected DocumentBuilder _builder;
    //    protected Document _doc;

    //    protected string _filePath = "";
    //    #endregion

    //    #region Intruction
    //    public WordExtend()
    //    {
    //    }

    //    public void OpenFile(string PathNFile)
    //    {
    //        if (!File.Exists(PathNFile))
    //            throw new FileNotFoundException("File not found...", PathNFile);

    //        _filePath = PathNFile;
    //        this._doc = new Document(PathNFile);
    //        this._builder = new DocumentBuilder(this._doc);
    //    }

    //    public void NewFile()
    //    {
    //        _filePath = "";
    //        this._doc = new Document();
    //        this._builder = new DocumentBuilder(this._doc);
    //    }
    //    #endregion

    //    #region Boolmark

    //    /// <summary>
    //    /// Chèn ảnh tại bookmark
    //    /// </summary>
    //    /// <param name="BookMark">tên bookmark</param>
    //    /// <param name="PathNFileImg">đường dẫn tuyệt đối tới file ảnh</param>
    //    public void BoolmarkInsertImage(string BookMark, string PathNFileImg)
    //    {
    //        try
    //        {
    //            if (!File.Exists(PathNFileImg))
    //                throw new FileNotFoundException("Image not found", PathNFileImg);

    //            this._builder.MoveToBookmark(BookMark);
    //            this._builder.InsertImage(PathNFileImg);
    //        }
    //        catch (Exception ex)
    //        {
    //            if (indebugMode)
    //            throw ex;
    //        }
    //    }

    //    /// <summary>
    //    /// Chèn ảnh tại bookmark
    //    /// </summary>
    //    /// <param name="BookMark">tên bookmark</param>
    //    /// <param name="PathNFileImg">đường dẫn tuyệt đối tới file ảnh</param>
    //    /// <param name="Width">Độ rộng ảnh muốn chèn, chiều cao sẽ đc tự tính</param>
    //    public void BoolmarkInsertImage(string BookMark, string PathNFileImg, double Width)
    //    {
    //        try
    //        {
    //            if (!File.Exists(PathNFileImg))
    //                throw new FileNotFoundException("Image not found", PathNFileImg);

    //            this._builder.MoveToBookmark(BookMark);
    //            System.Drawing.Image image = new System.Drawing.Bitmap(PathNFileImg);
    //            double height = image.Height;
    //            double width = image.Width;
    //            double num3 = (100.0 * Width) / width;
    //            double num4 = (num3 * height) / 100.0;
    //            this._builder.InsertImage(PathNFileImg, Width, num4);
    //        }
    //        catch (Exception ex)
    //        {
    //            if (indebugMode)
    //                throw ex;
    //        }
    //    }

    //    /// <summary>
    //    /// Chèn ảnh tại bookmark
    //    /// </summary>
    //    /// <param name="BookMark">tên bookmark</param>
    //    /// <param name="PathNFileImg">đường dẫn tuyệt đối tới file ảnh</param>
    //    /// <param name="Width">Độ rộng ảnh muốn chèn</param>
    //    /// <param name="Height">Chiều cao ảnh muốn chèn</param>
    //    public void BoolmarkInsertImage(string BookMark, string PathNFileImg, double Width, double Height)
    //    {
    //        try
    //        {
    //            if (!File.Exists(PathNFileImg))
    //                throw new FileNotFoundException("Image not found", PathNFileImg);

    //            this._builder.MoveToBookmark(BookMark);
    //            this._builder.InsertImage(PathNFileImg, Width, Height);
    //        }
    //        catch (Exception ex)
    //        {
    //            if (indebugMode)
    //                throw ex;
    //        }
    //    }

    //    /// <summary>
    //    /// Đưa giá trị vào bookmark
    //    /// </summary>
    //    /// <param name="bookMark">tên bookmark</param>
    //    /// <param name="value">gái trị</param>
    //    /// <param name="fontName">tên font</param>
    //    /// <param name="fontSize">kích thước chữ</param>
    //    /// <param name="fontStyle">Kiểu, dùng | của FontStyle</param>
    //    /// <param name="color">màu (mặc định đen)</param>
    //    /// <param name="underline">gạch dưới</param>
    //    public void WriteToBoolmark(string bookMark, string value, string fontName = "", double fontSize = 0, int fontStyle = 0, System.Drawing.Color? color = null, Underline underline = Underline.None)
    //    {
    //        this._builder.MoveToBookmark(bookMark);
    //        this.WriteToWord(value, fontName, fontSize, fontStyle, color, underline);
    //    }
    //    #endregion

    //    #region MergeField

    //    /// <summary>
    //    /// Đưa giá trị vào MergeField
    //    /// </summary>
    //    /// <param name="mergeField">tên field</param>
    //    /// <param name="value">gái trị</param>
    //    /// <param name="fontName">tên font</param>
    //    /// <param name="fontSize">kích thước chữ</param>
    //    /// <param name="fontStyle">Kiểu, dùng | của FontStyle</param>
    //    /// <param name="color">màu (mặc định đen)</param>
    //    /// <param name="underline">gạch dưới</param>
    //    public void WriteToMergeField(string mergeField, string value, string fontName = "", double fontSize = 0, int fontStyle = 0, System.Drawing.Color? color = null, Underline underline = Underline.None)
    //    {
    //        this._builder.MoveToMergeField(mergeField);

    //        this.WriteToWord(value, fontName, fontSize, fontStyle, color, underline);
    //    }

    //    /// <summary>
    //    /// Đưa giá trị vào MergeField
    //    /// </summary>
    //    /// <param name="mergeField">tên field</param>
    //    /// <param name="dt">Datatable muốn ghi</param>
    //    public void WriteDataTableToMergeField(DataTable dt, string mergeField)
    //    {
    //        try
    //        {
    //            dt.TableName = mergeField;
    //            this._doc.MailMerge.ExecuteWithRegions(dt);
    //        }
    //        catch (Exception ex)
    //        {
    //            if (indebugMode)
    //                throw ex;
    //        }
    //    }

    //    /// <summary>
    //    /// Đưa giá trị vào MergeField
    //    /// </summary>
    //    /// <param name="ds">DataSet muốn ghi, rất quan trọng: ds cần có tên bảng đúng với tên MergeField và có hỗ trợ liên kết giữa các bảng để fill cho chuẩn</param>
    //    public void WriteDataSetToMergeField(DataSet ds)
    //    {
    //        try
    //        {
    //            this._doc.MailMerge.ExecuteWithRegions(ds);
    //        }
    //        catch (Exception ex)
    //        {
    //            if (indebugMode)
    //                throw ex;
    //        }
    //    }
    //    #endregion

    //    #region misc

    //    /// <summary>
    //    /// Ghi giá trị vào word
    //    /// </summary>
    //    /// <param name="value">gái trị</param>
    //    /// <param name="fontName">tên font</param>
    //    /// <param name="fontSize">kích thước chữ</param>
    //    /// <param name="fontStyle">Kiểu, dùng | của FontStyle</param>
    //    /// <param name="color">màu (mặc định đen)</param>
    //    /// <param name="underline">gạch dưới</param>
    //    public void WriteToWord(string value, string fontName = "", double fontSize = 0, int fontStyle = 0, System.Drawing.Color? color = null, Underline underline = Underline.None)
    //    {
    //        try
    //        {
    //            Aspose.Words.Font oldFont = this._builder.Font;

    //            if (!string.IsNullOrWhiteSpace(fontName))
    //                this._builder.Font.Name = fontName;
    //            if (fontSize > 0)
    //                this._builder.Font.Size = fontSize;
    //            if (color != null)
    //                this._builder.Font.Color = color.Value;
    //            this._builder.Font.AllCaps       = (fontStyle & (int)FontStyle.AllCaps)          == (int)FontStyle.AllCaps;
    //            this._builder.Font.Bold          = (fontStyle & (int)FontStyle.Bold)             == (int)FontStyle.Bold;
    //            this._builder.Font.Italic        = (fontStyle & (int)FontStyle.Italic)           == (int)FontStyle.Italic;
    //            this._builder.Font.Outline       = (fontStyle & (int)FontStyle.Outline)          == (int)FontStyle.Outline;
    //            this._builder.Font.SmallCaps     = (fontStyle & (int)FontStyle.SmallCaps)        == (int)FontStyle.SmallCaps;
    //            this._builder.Font.StrikeThrough = (fontStyle & (int)FontStyle.StrikeThrough)    == (int)FontStyle.StrikeThrough;
    //            this._builder.Font.Subscript     = (fontStyle & (int)FontStyle.Subscript)        == (int)FontStyle.Subscript;
    //            this._builder.Font.Superscript   = (fontStyle & (int)FontStyle.Superscript)      == (int)FontStyle.Superscript;
    //            this._builder.Font.Underline     = underline;

    //            this._builder.Write(value);

    //            this._builder.Font.Name          = oldFont.Name;
    //            this._builder.Font.Size          = oldFont.Size;
    //            this._builder.Font.Color         = oldFont.Color;
    //            this._builder.Font.AllCaps       = oldFont.AllCaps;
    //            this._builder.Font.Bold          = oldFont.Bold;
    //            this._builder.Font.Italic        = oldFont.Italic;
    //            this._builder.Font.Outline       = oldFont.Outline;
    //            this._builder.Font.SmallCaps     = oldFont.SmallCaps;
    //            this._builder.Font.StrikeThrough = oldFont.StrikeThrough;
    //            this._builder.Font.Subscript     = oldFont.Subscript;
    //            this._builder.Font.Superscript   = oldFont.Superscript;
    //            this._builder.Font.Underline     = oldFont.Underline;
    //        }
    //        catch (Exception ex)
    //        {
    //            if (indebugMode)
    //                throw ex;
    //        }
    //    }

    //    public void insertTable(int TableID, DataTable DT)
    //    {
    //        try
    //        {
    //            Exception exception;
    //            Table table = (Table)this._doc.GetChild(NodeType.Table, TableID, true);
    //            if (table == null)
    //            {
    //                exception = new Exception("Ko tim thay table " + TableID + " trong word!");
    //                throw exception;
    //            }
    //            Aspose.Words.Tables.Row row = table.Rows[table.Rows.Count - 1];
    //            table.Rows.RemoveAt(table.Rows.Count - 1);
    //            if (DT.Columns.Count != row.Cells.Count)
    //            {
    //                exception = new Exception("So cot cua DataTable & So cot cua table trong Word ko bang nhau!");
    //                throw exception;
    //            }
    //            for (int i = 0; i < DT.Rows.Count; i++)
    //            {
    //                Aspose.Words.Tables.Row node = (Aspose.Words.Tables.Row)row.Clone(true);
    //                table.Rows.Add(node);
    //                int num2 = 0;
    //                foreach (Aspose.Words.Tables.Cell cell in node.Cells)
    //                {
    //                    string text = cell.Paragraphs[0].Runs[0].Text;
    //                    cell.Paragraphs[0].Runs[0].Text = DT.Rows[i][num2].ToString();
    //                    num2++;
    //                }
    //            }
    //        }
    //        catch (Exception exception2)
    //        {
    //            throw exception2;
    //        }
    //    }

    //    /// <summary>
    //    /// lưu lại
    //    /// </summary>
    //    /// <param name="PathNFile"></param>
    //    public void Save(string PathNFile = "")
    //    {
    //        if (string.IsNullOrWhiteSpace(PathNFile))
    //            PathNFile = this._filePath;

    //        if (string.IsNullOrWhiteSpace(PathNFile))
    //            throw new ArgumentException("File to save ???", PathNFile);

    //        try
    //        {
    //            this._doc.Save(PathNFile);
    //        }
    //        catch (Exception ex)
    //        {
    //            if (indebugMode)
    //                throw ex;
    //        }
    //    }
    //    #endregion
    //}
}
