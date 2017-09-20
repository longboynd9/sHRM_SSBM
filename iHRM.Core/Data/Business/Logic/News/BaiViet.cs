using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.News
{
    public class BaiViet : LogicBase
    {
        public VirtualPagingInfo VirtualPaging
        {
            get { return _VirtualPaging; }
            set { _VirtualPaging = value; }
        }

        public BaiViet()
            : base(iHRM.Core.Business.TableConst.tbBaiViet.TableName)
        {
            _VirtualPaging = new VirtualPagingInfo();
        }

        public string GetNoiDung(Guid? idBaiViet, eLanguage lng = eLanguage.VN)
        {
            var dr = Provider.ExecuteDataRow("p_tbBaiViet_GetNoiDung",
                new SqlParameter("idBaiViet", idBaiViet),
                new SqlParameter("lng", lng)
            );
            return dr == null ? "" : dr[0] as string;
        }
        public bool SetNoiDung(Guid? idBaiViet, string noidung, eLanguage lng = eLanguage.VN)
        {
            return Provider.ExecNoneQuery("p_tbBaiViet_SetNoiDung",
                new SqlParameter("idBaiViet", idBaiViet),
                new SqlParameter("noidung", noidung),
                new SqlParameter("lng", lng)
            ) > 0;
        }

        public DataRow GetByIdx(int idx)
        {
            return Provider.ExecuteDataRow("p_tbBaiViet_GetByIdx", new SqlParameter("idx", idx));
        }

        public Guid? CreateNew(Guid? id)
        {
            return Provider.ExecuteScalar("p_tbBaiViet_CreateNew",
                new SqlParameter("idBaiViet", id)
            ) as Guid?;
        }
        public int UpdateIdBv4DanhMucBaiViet(Guid idDanhMucBV, Guid idBaiViet)
        {
            return Provider.ExecNoneQuery("p_tbBaiViet_UpdateIdBv4DanhMucBaiViet",
                new SqlParameter("idDanhMucBV", idDanhMucBV),
                new SqlParameter("idBaiViet", idBaiViet)
            );
        }
    }
}
