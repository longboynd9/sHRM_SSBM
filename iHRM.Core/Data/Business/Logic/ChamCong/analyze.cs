using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.ChamCong
{
    public class analyze
    {
        public DataTable GetAllDuLieuQuetThe(DateTime? tuNgay, DateTime? denNgay)
        {
            return Provider.ExecuteDataTableReader("p_duLieuQuetThe_GetAllDuLieuQuetThe",
                 new SqlParameter("tuNgay", tuNgay),
                  new SqlParameter("denNgay", denNgay)
            );
        }
        public DataTable GetAllKetQuaQuetThe_CoThe()
        {
            return Provider.ExecuteDataTableReader("p_duLieuQuetThe_GetAllKetQuaQuetThe_CoThe");
        }
        public int checkLockChamCong(int intDonViId, int intThang, int intNam)
        {
            return (int)(Provider.ExecuteScalar("sp_CheckLockChamCong", new SqlParameter("intDonViId", intDonViId), new SqlParameter("intThang", intThang),
                new SqlParameter("intNam", intNam)));
        }
        public void UpdateNhatkyvaora(long pk_iNhatKyVaoRaID)
        {

            string sql = "update tbl_NhatKyVaoRa set iDaDoc = 1 where pk_iNhatKyVaoRaID =" + pk_iNhatKyVaoRaID;
            Provider.ExecNoneQuery(sql);

        }
        public DateTime getDateOfCurrentDataByDonViID(long lngDonViID)
        {
            DateTime newchamcong = new DateTime();
            DataTable tbl = Provider.ExecuteDataTableReader_SQL("select top 1 * from tbl_NhatKyVaoRa where iDaDoc = 0 ORDER BY dThoiGian ASC");
            if (tbl != null)
            {
                if (tbl.Rows.Count > 0)
                {
                    newchamcong = (DateTime)tbl.Rows[0]["dThoiGian"];
                }

            }
            return newchamcong;
        }
        public DataTable getListNhanVienByFK_iDonViID(long lngDonViID)
        {

            string sql = @"select * from tbl_NhanVien WHERE 1=1 AND fk_iDonViID in (
	SELECT pk_iDonViID
	FROM dbo.tbl_Donvi
	WHERE sPath LIKE (SELECT sPath FROM dbo.tbl_Donvi WHERE pk_iDonViID = " + lngDonViID + ") + '%') AND Status = 1";
            return Provider.ExecuteDataTableReader_SQL(sql);
        }
        public List<NhatKyVaoRaObject> VtNhatKyVaoRaByNhanVienID(long lngDonViID, DateTime date)
        {

            string sql = "select * from tbl_NhatKyVaoRa WHERE 1=1 AND iDaDoc = 0 AND fk_iDonViID in ('" + lngDonViID + "') AND DATEPART (dd, dThoiGian) = " + date.Day + " AND DATEPART (mm, dThoiGian) = " + date.Month + " AND DATEPART (yyyy, dThoiGian) = " + date.Year + " ORDER BY fk_iNhanVienID ASC, dThoiGian ASC";
            List<NhatKyVaoRaObject> list = new List<NhatKyVaoRaObject>();
            DataTable tbl = Provider.ExecuteDataTableReader_SQL(sql);
            if (tbl != null)
            {
                if (tbl.Rows.Count > 0)
                {
                    foreach (DataRow items in tbl.Rows)
                    {
                        NhatKyVaoRaObject d = new NhatKyVaoRaObject(items);
                        list.Add(d);
                    }
                }
            }
            return list;
        }

        public Dictionary<long, List<NhatKyVaoRaObject>> hmNhatKyVaoRaByNhanVienID(long lngDonViID, DateTime date)
        {
            Dictionary<long, List<NhatKyVaoRaObject>> hmReturn = new Dictionary<long, List<NhatKyVaoRaObject>>();
            string sql = "select * from tbl_NhatKyVaoRa WHERE 1=1 AND iDaDoc = 0 AND fk_iDonViID = " + lngDonViID + " AND DATEPART (dd, dThoiGian) = " + date.Day + " AND DATEPART (mm, dThoiGian) = " + (date.Month) + " AND DATEPART (yyyy, dThoiGian) = " + (date.Year) + " ORDER BY fk_iNhanVienID ASC, dThoiGian ASC";

            DataTable tbl = Provider.ExecuteDataTableReader_SQL(sql);
            List<NhatKyVaoRaObject> vtNhatKyVaoRa = new List<NhatKyVaoRaObject>();
            long intNhanVienIDOld = (long)-1; //Biến tạm chứa mã nhân viên
            long intNhanVienIDCurrent = (long)0; //Biến tạm chứa mã nhân viên
            if (tbl != null && tbl.Rows.Count > 0)
            {
                foreach (DataRow items in tbl.Rows)
                {
                    intNhanVienIDCurrent = (long)items["fk_iNhanVienID"];
                    //Nếu ID nhân viên thay đổi
                    if (!intNhanVienIDCurrent.Equals(intNhanVienIDOld))
                    {
                        if (intNhanVienIDOld != -1)
                        {
                            hmReturn.Add(intNhanVienIDOld, vtNhatKyVaoRa);
                        }
                        vtNhatKyVaoRa = new List<NhatKyVaoRaObject>();
                    }
                    intNhanVienIDOld = intNhanVienIDCurrent;
                    NhatKyVaoRaObject d = new NhatKyVaoRaObject(items);
                    vtNhatKyVaoRa.Add(d);
                }
            }

            return hmReturn;
        }

        public List<NghiPhepObject> VtNghiPhepByNhanVien(long lngDonViID, DateTime date)
        {

            string sql = "SELECT * FROM tbl_Nhanvien INNER JOIN tbl_Donvi ON tbl_Nhanvien.fk_iDonViID = tbl_Donvi.pk_iDonViID INNER JOIN tbl_NghiPhep ON tbl_Nhanvien.pk_iNhanVienID = tbl_NghiPhep.fk_iNhanVienID WHERE (DATEPART ( dd , tbl_NghiPhep.dDenNgay ) >= " + date.Day + " AND DATEPART ( mm , tbl_NghiPhep.dDenNgay ) >= " + date.Month + " AND DATEPART ( yyyy , tbl_NghiPhep.dDenNgay ) >= " + date.Year + ") AND tbl_Donvi.pk_iDonViID = " + lngDonViID;
            List<NghiPhepObject> list = new List<NghiPhepObject>();
            DataTable tbl = Provider.ExecuteDataTableReader_SQL(sql);
            if (tbl != null)
            {
                if (tbl.Rows.Count > 0)
                {
                    foreach (DataRow item in tbl.Rows)
                    {
                        NghiPhepObject d = new NghiPhepObject(item);
                        list.Add(d);
                    }
                }
            }
            return list;
        }
        public Dictionary<long, List<NghiPhepObject>> hmNghiPhepByNhanVien(long lngDonViID, DateTime date)
        {
            Dictionary<long, List<NghiPhepObject>> hmReturn = new Dictionary<long, List<NghiPhepObject>>();
            string sql = "SELECT * FROM tbl_Nhanvien INNER JOIN tbl_Donvi ON tbl_Nhanvien.fk_iDonViID = tbl_Donvi.pk_iDonViID INNER JOIN tbl_NghiPhep ON tbl_Nhanvien.pk_iNhanVienID = tbl_NghiPhep.fk_iNhanVienID WHERE (DATEPART ( dd , tbl_NghiPhep.dDenNgay ) >= " + date.Day + " AND DATEPART ( mm , tbl_NghiPhep.dDenNgay ) >= " + date.Month + " AND DATEPART ( yyyy , tbl_NghiPhep.dDenNgay ) >= " + date.Year + ") AND tbl_Donvi.pk_iDonViID = " + lngDonViID;
            DataTable tbl = Provider.ExecuteDataTableReader_SQL(sql);
            List<NghiPhepObject> lstNghiPhep = null;
            long lngIdOld = (long)-1;
            long lngIdNew = (long)0;
            if (tbl != null)
            {
                if (tbl.Rows.Count > 0)
                {
                    foreach (DataRow item in tbl.Rows)
                    {
                        lngIdNew = (long)item["fk_iNhanVienID"];
                        //Nếu ID nhân viên thay đổi
                        if (!lngIdNew.Equals(lngIdOld))
                        {
                            if (lngIdOld != -1)
                            {
                                hmReturn.Add(lngIdOld, lstNghiPhep);
                            }
                            lstNghiPhep = new List<NghiPhepObject>();
                        }
                        lngIdOld = lngIdNew;
                        NghiPhepObject d = new NghiPhepObject(item);
                        lstNghiPhep.Add(d);
                    }
                }
            }
            return hmReturn;
        }
        public List<CauHinhCaObject> GetvtCauHinhCa(long lngDonViID, int intThu, int intNgay, int intThang, int intNam)
        {

            // string sql = "SELECT * FROM tbl_Nhanvien INNER JOIN tbl_Donvi ON tbl_Nhanvien.fk_iDonViID = tbl_Donvi.pk_iDonViID INNER JOIN tbl_NghiPhep ON tbl_Nhanvien.pk_iNhanVienID = tbl_NghiPhep.fk_iNhanVienID WHERE (DATEPART ( dd , tbl_NghiPhep.dDenNgay ) >= " + date.Date + " AND DATEPART ( mm , tbl_NghiPhep.dDenNgay ) >= " + (date.Month + 1)+" AND DATEPART ( yyyy , tbl_NghiPhep.dDenNgay ) >= " + (date.Year + 1900) + ") AND tbl_Donvi.pk_iDonViID = " + lngDonViID;
            List<CauHinhCaObject> list = new List<CauHinhCaObject>();
            //DataTable tbl = Provider.ExecuteDataTableReader("sp_CauHinhCa_SelectByDate", 
            //    new SqlParameter("lngDonViID", lngDonViID), 
            //    new SqlParameter("intThu", intThang),
            //    new SqlParameter("intNgay", intNam), 
            //    new SqlParameter("intNam", intNam)
            //);
            DataTable tbl = Provider.ExecuteDataTableReader("sp_CauHinhCa_SelectByDateAndOrg",
                new SqlParameter("lngDonViID", lngDonViID),
                new SqlParameter("iThu", intThu),
                new SqlParameter("iNgay", intNgay),
                new SqlParameter("iThang", intThang),
                new SqlParameter("iNam", intNam)
            );

            if (tbl != null)
            {
                if (tbl.Rows.Count > 0)
                {
                    foreach (DataRow item in tbl.Rows)
                    {
                        CauHinhCaObject d = new CauHinhCaObject(item);
                        list.Add(d);
                    }
                }
            }
            return list;
        }
        public void executeUpdate(string sql)
        {

            //  string sql = "update tbl_NhatKyVaoRa set iDaDoc = 1 where pk_iNhatKyVaoRaID =" + pk_iNhatKyVaoRaID;
            Provider.ExecuteNonQuery_SQL(sql);
        }
        public List<CauHinhChamCongObject> getcauHinhChamCongByFK_iDonViID(long lngDonViID)
        {
            List<CauHinhChamCongObject> list = new List<CauHinhChamCongObject>();
            string sql = string.Format("select * from tbl_CauHinhChamCong  where fk_iDonViID = {0} ORDER BY iSoPhut ASC", lngDonViID);
            DataTable tbl = Provider.ExecuteDataTableReader_SQL(sql);
            if (tbl != null)
            {
                if (tbl.Rows.Count > 0)
                {
                    foreach (DataRow item in tbl.Rows)
                    {
                        CauHinhChamCongObject d = new CauHinhChamCongObject(item);
                        list.Add(d);
                    }
                }
            }
            return list;
        }

        public int ChotBangCong(DateTime? tuNgay, DateTime? denNgay, bool isLock)
        {
            return Provider.ExecuteNonQuery("p_QuetThe_ChotCong",
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                new SqlParameter("isLock", isLock)
            ).NumberOfRowAffected;
        }
        public int ChotBangCong_WithEmp(DateTime? tuNgay, DateTime? denNgay, string empID, bool isLock)
        {
            return Provider.ExecuteNonQuery("p_QuetThe_ChotCong_WithEmp",
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                new SqlParameter("empID", empID),
                new SqlParameter("isLock", isLock)
            ).NumberOfRowAffected;
        }
        public int ChotBangCong_WithDept(DateTime? tuNgay, DateTime? denNgay, string maTapThe, bool isLock)
        {
            return Provider.ExecuteNonQuery("p_QuetThe_ChotCong_WithDept",
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                new SqlParameter("maTapThe", maTapThe),
                new SqlParameter("isLock", isLock)
            ).NumberOfRowAffected;
        }
        public int ChotBangCong_WithGroup1(DateTime? tuNgay, DateTime? denNgay, int IdGroup1, bool isLock)
        {
            return Provider.ExecuteNonQuery("p_QuetThe_ChotCong_WithGroup1",
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                new SqlParameter("IdGroup1", IdGroup1),
                new SqlParameter("isLock", isLock)
            ).NumberOfRowAffected;
        }
    }
}
