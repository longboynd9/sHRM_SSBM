using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace iHRM.Win.Frm.QuetThe.CauHinh
{
    public class LoaiNgayLamThem : lstBase_grdEdit
    {
        public LoaiNgayLamThem()
        {
            lstData.FormCaption = "Loại ngày làm thêm";
            lstData.IdColumnName = "id";
            lstData.TableName = "tbLoaiNgayLamThem";

            lstData.GrdColumns.Add(new GridColumn1("tenLoai", "Loại", ControlBinding_DataType.String));
            lstData.GrdColumns.Add(new GridColumn1("heSoLuong", "Hệ số lương", ControlBinding_DataType.Float));
        }

        protected override void OnInitNewRow(ref DataRow r)
        {
            r[lstData.IdColumnName] = Guid.NewGuid();
        }
    }
}
