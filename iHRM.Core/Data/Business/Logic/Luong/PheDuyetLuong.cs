using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.Luong
{
    public class PheDuyetLuong
    {
        public virtual DataTable GetLst(string searchKey = "", DateTime? tuNgay = null, DateTime? denNgay = null, bool onlyWaiting = false)
        {
            return Provider.ExecuteDataTable("p_pheDuyetLuong_getLst",
                new SqlParameter("searchKey", searchKey),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                new SqlParameter("onlyWaiting", onlyWaiting)
            );
        }

        public virtual DataRow GetItem(Guid id)
        {
            return Provider.ExecuteDataRow("p_pheDuyetLuong_getItem",
                new SqlParameter("id", id)
            );
        }

        public virtual bool SetItemStatus(Guid id, int status, string status_remark = "")
        {
            return Provider.ExecNoneQuery("p_pheDuyetLuong_setItemStatus",
                new SqlParameter("id", id),
                new SqlParameter("status", status),
                new SqlParameter("status_remark", status_remark)
            ) > 0;
        }
    }
}
