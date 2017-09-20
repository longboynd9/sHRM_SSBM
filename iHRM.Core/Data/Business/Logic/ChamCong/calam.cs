using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.ChamCong
{
    public class calam : LogicBase
    {
        public calam() : base(TableConst.tbCaLamViec.TableName) { }

        public DataTable GetAllCaLam()
        {
            return Provider.ExecuteDataTableReader("p_chamcong_GetCaLam");
        }
        public DataTable GetData(string empID, DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            return Provider.ExecuteDataTableReader("p_chamcong_GetData",
                new SqlParameter("empID", empID),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
        }
        public DataTable GetDataDangKyCaLam(string empID = null, DateTime? tuNgay = null, DateTime? denNgay = null, string depID = null)
        {
            return Provider.ExecuteDataTableReader("p_chamcong_GetData_DangKyCaLam",
                new SqlParameter("empID", empID),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                new SqlParameter("depID", depID)
            );
        }

        public DataTable GetDataDangKyLamThem(string empID = null, DateTime? tuNgay = null, DateTime? denNgay = null, string depID = null)
        {
            return Provider.ExecuteDataTableReader("p_chamcong_GetData_DangKyCaLam",
                new SqlParameter("empID", empID),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                new SqlParameter("depID", depID),
                new SqlParameter("isLamThem", true)
            );
        }

        public DataTable GetDataDangKyVangMat(string empID = null, DateTime? tuNgay = null, DateTime? denNgay = null, int coHuongLuong = 0, string DepID = "")
        {
            return Provider.ExecuteDataTableReader("p_chamcong_GetData_DangKyVangMat",
                new SqlParameter("empID", empID),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                new SqlParameter("coHuongLuong", coHuongLuong)
            );
        }
        public Base.ExecuteResult DangKyCaLam(string empID, DateTime ngay, Guid idCaLam, int? dkLamThem = null, int? hsLuong = null)
        {
            return Provider.ExecuteNonQuery("p_chamcong_CaNhan_DangKyCaLam",
                new SqlParameter("empID", empID),
                new SqlParameter("ngay", ngay),
                new SqlParameter("idCaLam", idCaLam),
                new SqlParameter("dkLamThem", dkLamThem),
                new SqlParameter("hsLuong", hsLuong)
            );
        }
        public int DangKyCaLam_tapThe(string maTapThe, DateTime ngay, Guid idCaLam, int? dkLamThem = null, int? hsLuong = null)
        {
            return Provider.ExecNoneQuery("p_chamcong_CaNhan_DangKyCaLam_tapThe",
                new SqlParameter("maTapThe", maTapThe),
                new SqlParameter("ngay", ngay),
                new SqlParameter("idCaLam", idCaLam),
                new SqlParameter("dkLamThem", dkLamThem),
                new SqlParameter("hsLuong", hsLuong)
            );
        }

        public int DangKyCaLam_nhom1(int idNhom1, DateTime ngay, Guid idCaLam, int? dkLamThem = null, int? hsLuong = null)
        {
            return Provider.ExecNoneQuery("p_chamcong_CaNhan_DangKyCaLam_nhom1",
                new SqlParameter("idNhom1", idNhom1),
                new SqlParameter("ngay", ngay),
                new SqlParameter("idCaLam", idCaLam),
                new SqlParameter("dkLamThem", dkLamThem),
                new SqlParameter("hsLuong", hsLuong)
            );
        }

        public iHRM.Core.Business.Base.ExecuteResult DangKyVangMat(string empID, DateTime ngay, TimeSpan tuGio, TimeSpan denGio, int lyDo, string ghiChu, int coHuongLuong = 1, double? hourLeave = null)
        {
            return Provider.ExecuteNonQuery("p_chamcong_CaNhan_DangKyVangMat",
                new SqlParameter("empID", empID),
                new SqlParameter("ngay", ngay),
                new SqlParameter("tuGio", tuGio),
                new SqlParameter("denGio", denGio),
                new SqlParameter("lyDo", lyDo),
                new SqlParameter("ghiChu", ghiChu),
                new SqlParameter("coHuongLuong", coHuongLuong),
                new SqlParameter("hourLeave", hourLeave)
            );
        }
        public iHRM.Core.Business.Base.ExecuteResult DangKyVangMat2(string empID, DateTime ngay, int caXinNghi, int lyDo, string ghiChu, int coHuongLuong = 1, double? hourLeave = null, bool coTinhChuyenCan = true)
        {
            return Provider.ExecuteNonQuery("p_chamcong_CaNhan_DangKyVangMat2",
                new SqlParameter("empID", empID),
                new SqlParameter("ngay", ngay),
                new SqlParameter("caXinNghi", caXinNghi),
                new SqlParameter("lyDo", lyDo),
                new SqlParameter("ghiChu", ghiChu),
                new SqlParameter("coHuongLuong", coHuongLuong),
                new SqlParameter("hourLeave", hourLeave),
                new SqlParameter("coTinhChuyenCan", coTinhChuyenCan)
            );
        }

        public DataRow checkNV(string empID)
        {
            empID = empID.Trim(' ', '\n', '\r', '\t');
            return Provider.ExecuteDataRow("p_chamcong_checkNV", new SqlParameter("empID", empID));
        }
        public DataRow checkPB(string depID)
        {
            depID = depID.Trim(' ', '\n', '\r', '\t');
            return Provider.ExecuteDataRow("p_chamcong_checkPB", new SqlParameter("depID", depID));
        }


        #region dk ca mac dinh
        public DataTable GetDataDKCaMacDinh(string empID = null, string depID = null)
        {
            return Provider.ExecuteDataTableReader("p_chamcong_GetData_DKCaMacDinh",
                new SqlParameter("empID", empID),
                new SqlParameter("depID", depID)
            );
        }
        public int DKCaMacDinh_DKnhom1(int idNhom1, Guid idCaLam, int? heSoLuong = null, bool chuNhat = false)
        {
            return Provider.ExecNoneQuery("p_chamcong_CaNhan_DKCaMacDinh_DKnhom1",
                new SqlParameter("idNhom1", idNhom1),
                new SqlParameter("idCaLam", idCaLam),
                new SqlParameter("heSoLuong", heSoLuong),
                new SqlParameter("chuNhat", chuNhat)
            );
        }

        public int DKCaMacDinh_DKtapThe(string maTapThe, Guid idCaLam, int? heSoLuong = null, bool chuNhat = false)
        {
            return Provider.ExecNoneQuery("p_chamcong_CaNhan_DKCaMacDinh_DKtapThe",
                new SqlParameter("maTapThe", maTapThe),
                new SqlParameter("idCaLam", idCaLam),
                new SqlParameter("heSoLuong", heSoLuong),
                new SqlParameter("chuNhat", chuNhat)
            );
        }
        #endregion
    }
}
