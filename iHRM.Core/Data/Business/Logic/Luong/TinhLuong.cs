using iHRM.Common.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iHRM.Core.Business.Logic.Luong
{
    public class TinhLuong
    {
        public Base.ExecuteResult ImportAllowance(DateTime? thang, DataTable dtAllowance)
        {
            var pa = new SqlParameter("dtAllowance", SqlDbType.Structured);
            pa.TypeName = "dtAllowance4Import";
            pa.Value = dtAllowance;

            return Provider.ExecuteNonQuery("p_tinhluong_ImportAllowance",
                new SqlParameter("thang", thang),
                pa
            );
        }
        public Base.ExecuteResult ImportAllowance_WithDep(string depID, DateTime? thang, DataTable dtAllowance)
        {
            var pa = new SqlParameter("dtAllowance", SqlDbType.Structured);
            pa.TypeName = "dtAllowance4Import";
            pa.Value = dtAllowance;

            return Provider.ExecuteNonQuery("p_tinhluong_ImportAllowance_WithDep",
                new SqlParameter("depID", depID),
                new SqlParameter("thang", thang),
                pa
            );
        }
        public Base.ExecuteResult ImportAllowance_WithGroup1(int group1ID, DateTime? thang, DataTable dtAllowance)
        {
            var pa = new SqlParameter("dtAllowance", SqlDbType.Structured);
            pa.TypeName = "dtAllowance4Import";
            pa.Value = dtAllowance;

            return Provider.ExecuteNonQuery("p_tinhluong_ImportAllowance_WithGroup1",
                new SqlParameter("group1ID", group1ID),
                new SqlParameter("thang", thang),
                pa
            );
        }

        public Base.ExecuteResult ImportDataCalc(DateTime thang, DataTable dtDataCalc)
        {
            var pa = new SqlParameter("dtDataCalc", SqlDbType.Structured);
            pa.TypeName = "dtDataCalc4Import";
            pa.Value = dtDataCalc;

            return Provider.ExecuteNonQuery("p_tinhLuong_ImportDataCalc",
                new SqlParameter("thang", thang),
                pa
            );
        }

        public Base.ExecuteResult ImportLuongSp(DateTime thang, DataTable dtLuongSP)
        {
            var pa = new SqlParameter("dtLuongSP", SqlDbType.Structured);
            pa.TypeName = "dtLuongSP4Import";
            pa.Value = dtLuongSP;

            return Provider.ExecuteNonQuery("p_tinhluong_ImportLuongSP",
                new SqlParameter("thang", thang),
                pa
            );
        }
        public Base.ExecuteResult ImportLuongSp_WithDep(string depID, DateTime thang, double LuongSP)
        {
            return Provider.ExecuteNonQuery("p_tinhluong_ImportLuongSP_WithDep",
                new SqlParameter("depID", depID),
                new SqlParameter("thang", thang),
                new SqlParameter("LuongSP", LuongSP)
            );
        }
        public DataTable GetTsTinhLuong(DateTime? thang)
        {
            //lấy dữ liệu cho việc xuất excel
            return Provider.ExecuteDataTableReader("[p_TinhLuong_GetTsTinhLuong]",
                new SqlParameter("thang", thang)
            );
        }

        #region Bảng lương 2 dòng
        public int ResetBangLuong(DateTime? thang)
        {
            return Provider.ExecNoneQuery("p_tinhLuong_ResetBangLuong",
                new SqlParameter("thang", thang)
            );
        }
        public int ResetBangLuong_withDep(DateTime? thang, string maTapThe)
        {
            return Provider.ExecNoneQuery("p_tinhLuong_ResetBangLuong_withDep",
                new SqlParameter("thang", thang),
                new SqlParameter("maTapThe", maTapThe)
            );
        }
        public int ResetBangLuong_withEmp(DateTime? thang, string empID)
        {
            return Provider.ExecNoneQuery("p_tinhLuong_ResetBangLuong_withEmp",
                new SqlParameter("thang", thang),
                new SqlParameter("empID", empID)
            );
        }
        public int ResetBangLuong_withGroup1(DateTime? thang, int group1ID)
        {
            return Provider.ExecNoneQuery("p_tinhLuong_ResetBangLuong_withGroup1",
                new SqlParameter("thang", thang),
                new SqlParameter("group1ID", group1ID)
            );
        }

        public DataTable GetBangLuong(DateTime? thang, DateTime tuNgay, DateTime denNgay, string depID = null, int songaycongthang = 0)
        {
            return Provider.ExecuteDataTableReader("p_tinhLuong_GetBangLuong",
                new SqlParameter("thang", thang),
                new SqlParameter("depID", depID),
                new SqlParameter("songaycongthang", songaycongthang),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
        }
        public DataTable GetBangLuong_strEmpID(DateTime? thang, DateTime tuNgay, DateTime denNgay, string strEmpID = "", int songaycongthang = 0)
        {
            return Provider.ExecuteDataTableReader("p_tinhLuong_GetBangLuong_strEmpID",
                new SqlParameter("thang", thang),
                new SqlParameter("strEmpID", strEmpID),
                new SqlParameter("songaycongthang", songaycongthang),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
        }
        public DataTable GetBangLuongByEmp(DateTime? thang, string empID, DateTime tuNgay, DateTime denNgay, int songaycongthang = 0)
        {
            return Provider.ExecuteDataTableReader("p_tinhLuong_GetBangLuongByEmp",
                new SqlParameter("thang", thang),
                new SqlParameter("empID", empID),
                new SqlParameter("songaycongthang", songaycongthang),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
        }
        public DataTable GetBangLuongByGroup1(DateTime? thang, int idGroup, DateTime tuNgay, DateTime denNgay, int songaycongthang = 0)
        {
            return Provider.ExecuteDataTableReader("p_tinhLuong_GetBangLuongByGroup1",
                new SqlParameter("thang", thang),
                new SqlParameter("idGroup", idGroup),
                new SqlParameter("songaycongthang", songaycongthang),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
        }
        public DataRow GetBangLuongByID(Guid id)
        {
            return Provider.ExecuteDataRow("p_tinhLuong_GetBangLuongByID",
                new SqlParameter("id", id)
            );
        }

        public DataTable GetBangLuongChiTiet(DateTime? thang, string depID, DateTime tuNgay, DateTime denNgay, int songaycongthang = 0)
        {
            //lấy dữ liệu cho việc xuất excel
            return Provider.ExecuteDataTableReader("p_tinhLuong_GetBangLuongChiTiet",
                new SqlParameter("thang", thang),
                new SqlParameter("depID", depID),
                new SqlParameter("songaycongthang", songaycongthang),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
        }
        public DataTable GetBangLuongChiTiet_WithEmp(DateTime? thang, string empID, DateTime tuNgay, DateTime denNgay, int songaycongthang = 0)
        {
            //lấy dữ liệu cho việc xuất excel
            return Provider.ExecuteDataTableReader("p_tinhLuong_GetBangLuongChiTiet_WithEmp",
                new SqlParameter("thang", thang),
                new SqlParameter("empID", empID),
                new SqlParameter("songaycongthang", songaycongthang),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
        }
        public DataTable GetBangLuongChiTiet_WithGroup1(DateTime? thang, int groupID, DateTime tuNgay, DateTime denNgay, int songaycongthang = 0)
        {
            //lấy dữ liệu cho việc xuất excel
            return Provider.ExecuteDataTableReader("p_tinhLuong_GetBangLuongChiTiet_WithGroup1",
                new SqlParameter("thang", thang),
                new SqlParameter("groupID", groupID),
                new SqlParameter("songaycongthang", songaycongthang),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
        }
        #endregion
        #region Bảng lương 1 dòng
        public int ResetBangLuong_1dong(DateTime? thang)
        {
            return Provider.ExecNoneQuery("p_tinhLuong_ResetBangLuong_1dong",
                new SqlParameter("thang", thang)
            );
        }
        public int ResetBangLuong_1dong_withDep(DateTime? thang, string maTapThe)
        {
            return Provider.ExecNoneQuery("p_tinhLuong_ResetBangLuong_1dong_withDep",
                new SqlParameter("thang", thang),
                new SqlParameter("maTapThe", maTapThe)
            );
        }
        public int ResetBangLuong_1dong_withEmp(DateTime? thang, string empID)
        {
            return Provider.ExecNoneQuery("p_tinhLuong_ResetBangLuong_1dong_withEmp",
                new SqlParameter("thang", thang),
                new SqlParameter("empID", empID)
            );
        }
        public int ResetBangLuong_1dong_withGroup1(DateTime? thang, int group1ID)
        {
            return Provider.ExecNoneQuery("p_tinhLuong_ResetBangLuong_1dong_withGroup1",
                new SqlParameter("thang", thang),
                new SqlParameter("group1ID", group1ID)
            );
        }

        public DataTable GetBangLuong_1dong(DateTime? thang, DateTime tuNgay, DateTime denNgay, string depID = null, int songaycongthang = 0)
        {
            return Provider.ExecuteDataTableReader("p_tinhLuong_GetBangLuong_1dong",
                new SqlParameter("thang", thang),
                new SqlParameter("depID", depID),
                new SqlParameter("songaycongthang", songaycongthang),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
        }
        public DataTable GetBangLuong_1dong_strEmpID(DateTime? thang, DateTime tuNgay, DateTime denNgay, string strEmpID = "", int songaycongthang = 0)
        {
            return Provider.ExecuteDataTableReader("p_tinhLuong_GetBangLuong_1dong_strEmpID",
                new SqlParameter("thang", thang),
                new SqlParameter("strEmpID", strEmpID),
                new SqlParameter("songaycongthang", songaycongthang),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
        }
        public DataTable GetBangLuong_1dong_ByEmp(DateTime? thang, string empID, DateTime tuNgay, DateTime denNgay, int songaycongthang = 0)
        {
            return Provider.ExecuteDataTableReader("p_tinhLuong_GetBangLuong_1dong_ByEmp",
                new SqlParameter("thang", thang),
                new SqlParameter("empID", empID),
                new SqlParameter("songaycongthang", songaycongthang),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
        }
        public DataTable GetBangLuong_1dong_ByGroup1(DateTime? thang, int idGroup, DateTime tuNgay, DateTime denNgay, int songaycongthang = 0)
        {
            return Provider.ExecuteDataTableReader("p_tinhLuong_GetBangLuong_1dong_ByGroup1",
                new SqlParameter("thang", thang),
                new SqlParameter("idGroup", idGroup),
                new SqlParameter("songaycongthang", songaycongthang),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
        }
        public DataRow GetBangLuong_1dong_ByID(Guid id)
        {
            return Provider.ExecuteDataRow("p_tinhLuong_GetBangLuong_1dong_ByID",
                new SqlParameter("id", id)
            );
        }

        public DataTable GetBangLuongChiTiet_1dong(DateTime? thang, string depID, DateTime tuNgay, DateTime denNgay, int songaycongthang = 0)
        {
            //lấy dữ liệu cho việc xuất excel
            return Provider.ExecuteDataTableReader("p_tinhLuong_GetBangLuongChiTiet_1dong",
                new SqlParameter("thang", thang),
                new SqlParameter("depID", depID),
                new SqlParameter("songaycongthang", songaycongthang),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
        }
        public DataTable GetBangLuongChiTiet_1dong_WithEmp(DateTime? thang, string empID, DateTime tuNgay, DateTime denNgay, int songaycongthang = 0)
        {
            //lấy dữ liệu cho việc xuất excel
            return Provider.ExecuteDataTableReader("p_tinhLuong_GetBangLuongChiTiet_1dong_WithEmp",
                new SqlParameter("thang", thang),
                new SqlParameter("empID", empID),
                new SqlParameter("songaycongthang", songaycongthang),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
        }
        public DataTable GetBangLuongChiTiet_1dong_WithGroup1(DateTime? thang, int groupID, DateTime tuNgay, DateTime denNgay, int songaycongthang = 0)
        {
            //lấy dữ liệu cho việc xuất excel
            return Provider.ExecuteDataTableReader("p_tinhLuong_GetBangLuongChiTiet_1dong_WithGroup1",
                new SqlParameter("thang", thang),
                new SqlParameter("groupID", groupID),
                new SqlParameter("songaycongthang", songaycongthang),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
        }
        #endregion
        public DataTable GetAllKetQuaQuetThe(DateTime tuNgay, DateTime denNgay, string empID = null)
        {
            return Provider.ExecuteDataTableReader("p_tinhLuong_GetAllKetQuaQuetThe",
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                new SqlParameter("empID", empID)
            );
        }

        public int UpdateApprovedStt(Guid? id, int? approved)
        {
            return Provider.ExecNoneQuery("p_tinhLuong_UpdateApprovedStt",
                new SqlParameter("id", id),
                new SqlParameter("approved", approved)
            );
        }






        public int InsertPcCoDinh(string empID, double pc_XangXe, double pc_ConTho)
        {
            return Provider.ExecNoneQuery("p_tbPhuCapCoDinh_InsertOrUpdate",
                new SqlParameter("empID", empID),
                new SqlParameter("pc_XangXe", pc_XangXe),
                new SqlParameter("pc_ConTho", pc_ConTho)
            );
        }

        public int InsertPcCoDinh_ByDept(string depID, double pc_XangXe, double pc_ConTho)
        {
            return Provider.ExecNoneQuery("p_tbPhuCapCoDinh_InsertByDep",
                new SqlParameter("depID", depID),
                new SqlParameter("pc_XangXe", pc_XangXe),
                new SqlParameter("pc_ConTho", pc_ConTho)
            );
        }


        public int InsertCoHh_withDep(string depID, DateTime? dateStart)
        {
            return Provider.ExecNoneQuery("p_tinhluong_InsertCoHh_withDep",
                new SqlParameter("depID", depID),
                new SqlParameter("DateStart", dateStart)
            );
        }
        public int InsertCoHh_withGroup1(int groupID, DateTime? dateStart)
        {
            return Provider.ExecNoneQuery("p_tinhluong_InsertCoHh_withGroup1",
                new SqlParameter("groupID", groupID),
                new SqlParameter("DateStart", dateStart)
            );
        }







        public int ChotBangLuong(DateTime? thang, bool isLock)
        {
            return Provider.ExecuteNonQuery("p_tinhLuong_ChotBangLuong",
                new SqlParameter("thang", thang),
                new SqlParameter("isLock", isLock)
            ).NumberOfRowAffected;
        }
        public int ChotBangLuong_WithEmp(DateTime? thang, string empID, bool isLock)
        {
            return Provider.ExecuteNonQuery("p_tinhLuong_ChotBangLuong_WithEmp",
                new SqlParameter("thang", thang),
                new SqlParameter("empID", empID),
                new SqlParameter("isLock", isLock)
            ).NumberOfRowAffected;
        }
        public int ChotBangLuong_WithDept(DateTime? thang, string maTapThe, bool isLock)
        {
            return Provider.ExecuteNonQuery("p_tinhLuong_ChotBangLuong_WithDept",
                new SqlParameter("thang", thang),
                new SqlParameter("maTapThe", maTapThe),
                new SqlParameter("isLock", isLock)
            ).NumberOfRowAffected;
        }
        public int ChotBangLuong_WithGroup1(DateTime? thang, int IdGroup1, bool isLock)
        {
            return Provider.ExecuteNonQuery("p_tinhLuong_ChotBangLuong_WithGroup1",
                new SqlParameter("thang", thang),
                new SqlParameter("IdGroup1", IdGroup1),
                new SqlParameter("isLock", isLock)
            ).NumberOfRowAffected;
        }
    }
}