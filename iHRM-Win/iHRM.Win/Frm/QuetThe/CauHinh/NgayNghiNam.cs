using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace iHRM.Win.Frm.QuetThe.CauHinh
{
    public class NgayNghiNam : lstBase_grdEdit
    {
        public NgayNghiNam()
        {
            lstData.FormCaption = "Ngày nghỉ trong năm";
            lstData.IdColumnName = "id";
            lstData.TableName = "tbNgayNghiPhepNam";

            lstData.GrdColumns.Add(new GridColumn1("ngay", "Ngày", ControlBinding_DataType.Int));
            lstData.GrdColumns.Add(new GridColumn1("thang", "Tháng", ControlBinding_DataType.Int));
            lstData.GrdColumns.Add(new GridColumn1("nam", "Năm", ControlBinding_DataType.Int));
            lstData.GrdColumns.Add(new GridColumn1("ten", "Tên ngày nghỉ", ControlBinding_DataType.String));
        }

        protected override void OnInitNewRow(ref DataRow r)
        {
            r[lstData.IdColumnName] = Guid.NewGuid();
        }
    }
}
