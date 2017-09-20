using iHRM.Core.Business.DbObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using iHRM.Core.Business.Logic.Luong;
using iHRM.Core.Business;
using System.Data.SqlClient;
using iHRM.Common.Code;
using System.Web;

namespace iHRM.Core.Controller.Luong
{
    public class InPhieuLuong : LogicBase
    {
        TinhLuong logic = new TinhLuong();
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        #region Get data bảng lương 2 dòng
        public DataTable GetData(DateTime cMonth, int soNC, string empID, int group1ID, string deptID, DateTime tuNgay, DateTime denNgay)
        {
            DataTable dt;
            if (!string.IsNullOrWhiteSpace(empID))
            {
                dt = logic.GetBangLuongByEmp(cMonth, empID, tuNgay, denNgay, soNC);
            }
            else if (group1ID > 0)
            {
                dt = logic.GetBangLuongByGroup1(cMonth, group1ID, tuNgay, denNgay, soNC);
            }
            else
            {
                dt = logic.GetBangLuong(cMonth, tuNgay, denNgay, deptID, soNC);
            }
            string tenCty = db.w5Systems.Where(p => p.Ma == "TitlePhieuLuong").FirstOrDefault().TitleEN;
            var dtData = new DataTable();
            dtData.Columns.AddRange("empoyeeID,tenCongTy,thang,nam,chukyluong,hoten,manv,cmnd,soTK,ngayVao,phongban,luongCu,luongPcCu,luongMoi,luongPcMoi,ngayHdMoi,tongNgayCong,tongNgayCongCu,tienNgayCong,tienNgayCongCu,ngaycong_bt,tienNC_bt,ngaycong_bt_Cu,tienNC_bt_Cu,ngaycong_phep,tienNC_phep,ngaycong_lt,tienNC_lt,tgTangCa_cn,tienTangCa_cn,tongTgTangCa_cn_gio,tongTienTangCa_cn,tgTangCa_lt,tienTangCa_lt,tgTangCa_bt,tienTangCa_bt,tgTangCa_bt_Cu,tienTangCa_bt_Cu,ngaycong_phepNam,tienNC_phepNam,tongThoiGianTangCa_cu,tongThoiGianTangCa_moi,tienTangCa_cu,tienTangCa_moi,luongSP,luongTangCaSP,Calc1,Calc2,Calc3,Calc4,Calc5,Calc6,Calc7,Calc8,Calc9,Calc10,Calc11,Calc12,Calc13,Calc14,Calc15,Calc16,Calc17,Calc18,Calc19,Calc20,tongThuongCalc,PC1,PC2,PC3,PC4,PC5,PC6,PC7,PC8,PC9,PC10,PC11,PC12,PC13,PC14,PC15,PC16,PC17,PC18,PC19,PC20,tongPhuCapKhac,tongLuong,BH105,actualBankTransfer,tongKhauTru,phiCongDoan,tienThuongSL,thuongBuaToi,thuongBuaToi_Cu,thuongLamCa,tongLuongTG,Allowance_Cu,Allowance_Moi,ConTho,isLuongSP,Thuong,LineName,ngayCong_Dem,ngayCong_Dem_Cu,tienNC_Dem,tienNC_Dem_Cu,tgTangCa_Dem,tienTangCa_Dem,tgTangCa_Dem_Cu,tienTangCa_Dem_Cu,PhuCapTrachNhiem,ThueTNCN"
                .Split(',').Select(i => new DataColumn(i)).ToArray()
            );

            foreach (string eID in dt.Select().Select(i => i["empoyeeID"]).Distinct())
            {
                DataRow r = dt.Select("empoyeeID='" + eID + "' AND laBangLuongCu=0").SingleOrDefault();
                DataRow r2 = dt.Select("empoyeeID='" + eID + "' AND laBangLuongCu=1").SingleOrDefault();

                var dr = dtData.NewRow();
                if (cMonth.Month + 1 > 12)
                {
                    dr["thang"] = string.Format("{0:00}", 1);
                    dr["nam"] = (cMonth.Year + 1).ToString();
                }
                else
                {
                    dr["thang"] = string.Format("{0:00}", cMonth.Month + 1);
                    dr["nam"] = cMonth.Year.ToString();
                }
                DateTime d1 = cMonth.AddDays(16);
                dr["tenCongTy"] = tenCty;
                dr["chukyluong"] = string.Format("{0:dd/MM/yyyy} ~ {1:dd/MM/yyyy}", d1, d1.AddMonths(1).AddDays(-1));

                dr["hoten"] = DbHelper.DrGetString(r, "tenNV");
                dr["manv"] = DbHelper.DrGetString(r, "empoyeeID");
                dr["cmnd"] = DbHelper.DrGetString(r, "IDCard");
                dr["soTK"] = DbHelper.DrGetString(r, "BankAccount");
                dr["LineName"] = DbHelper.DrGetString(r, "LineName");
                dr["ngayVao"] = string.Format("{0:dd/MM/yyyy}", DbHelper.DrGetDateTime(r, "ngayVao"));
                dr["phongban"] = DbHelper.DrGetString(r, "DepName");

                dr["luongCu"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r2, "luongCB"));
                dr["luongPcCu"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r2, "luongPC"));
                dr["luongMoi"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "luongCB"));
                dr["luongPcMoi"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "luongPC"));
                dr["ngayHdMoi"] = ""; //string.Format("{0:dd/MM/yyyy}", null); //-------hardcode

                dr["tongNgayCong"] = string.Format("{0:#,0.00}", DbHelper.DrGet(r, "tongNgayCong"));
                dr["tongNgayCongCu"] = string.Format("{0:#,0.00}", DbHelper.DrGet(r2, "tongNgayCong"));
                dr["tienNgayCong"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienNgayCong"));
                dr["tienNgayCongCu"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r2, "tienNgayCong"));

                dr["ngaycong_bt"] = string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "ngaycong_bt"));
                dr["tienNC_bt"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienNC_bt"));
                dr["ngayCong_Dem"] = string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "ngayCong_Dem"));
                dr["tienNC_Dem"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienNC_Dem"));
                dr["ngaycong_bt_Cu"] = string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r2, "ngaycong_bt"));
                dr["tienNC_bt_Cu"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r2, "tienNC_bt"));
                dr["ngayCong_Dem_Cu"] = string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r2, "ngayCong_Dem"));
                dr["tienNC_Dem_Cu"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r2, "tienNC_Dem"));
                dr["ngaycong_phep"] = string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "ngaycong_phep") + DbHelper.DrGetDouble(r2, "ngaycong_phep"));
                dr["tienNC_phep"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienNC_phep") + DbHelper.DrGetDouble(r2, "tienNC_phep"));
                dr["ngaycong_lt"] = string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "ngaycong_lt") + DbHelper.DrGetDouble(r2, "ngaycong_lt"));
                dr["tienNC_lt"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienNC_lt") + DbHelper.DrGetDouble(r2, "tienNC_lt"));

                dr["tgTangCa_cn"] = string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "tgTangCa_cn") + DbHelper.DrGetDouble(r2, "tgTangCa_cn"));
                dr["tienTangCa_cn"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienTangCa_cn") + DbHelper.DrGetDouble(r2, "tienTangCa_cn"));
                dr["tongTgTangCa_cn_gio"] = string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "tongTgTangCa_cn_gio") + DbHelper.DrGetDouble(r2, "tongTgTangCa_cn_gio"));
                dr["tongTienTangCa_cn"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienTangCa_cn") + DbHelper.DrGetDouble(r2, "tienTangCa_cn") + DbHelper.DrGetDouble(r, "tienNC_cn") + DbHelper.DrGetDouble(r2, "tienNC_cn"));
                dr["tgTangCa_lt"] = string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "tgTangCa_lt") + DbHelper.DrGetDouble(r2, "tgTangCa_lt"));
                dr["tienTangCa_lt"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienTangCa_lt") + DbHelper.DrGetDouble(r2, "tienTangCa_lt"));

                dr["tgTangCa_bt"] = string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "tgTangCa_bt"));
                dr["tienTangCa_bt"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienTangCa_bt"));
                dr["tgTangCa_bt_Cu"] = string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r2, "tgTangCa_bt"));
                dr["tienTangCa_bt_Cu"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r2, "tienTangCa_bt"));

                dr["tgTangCa_Dem"] = string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "tgTangCa_Dem"));
                dr["tienTangCa_Dem"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienTangCa_Dem"));
                dr["tgTangCa_Dem_Cu"] = string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r2, "tgTangCa_Dem"));
                dr["tienTangCa_Dem_Cu"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r2, "tienTangCa_Dem"));
                dr["ngaycong_phepNam"] = string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "ngaycong_phepNam") + DbHelper.DrGetDouble(r2, "ngaycong_phepNam"));
                dr["tienNC_phepNam"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienNC_phepNam") + DbHelper.DrGetDouble(r2, "tienNC_phepNam"));

                dr["tongThoiGianTangCa_cu"] = string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r2, "tongThoiGianTangCa"));
                dr["tongThoiGianTangCa_moi"] = string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "tongThoiGianTangCa"));
                dr["tienTangCa_cu"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r2, "tienTangCa"));
                dr["tienTangCa_moi"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienTangCa"));

                dr["luongSP"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "luongSP"));

                //dr["luongTangCaSP"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "luongTangCaSP"));
                //Thưởng bữa tối, làm ca
                dr["thuongBuaToi"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r2, "thuongBuaToi") + DbHelper.DrGetDouble(r, "thuongBuaToi"));
                dr["thuongLamCa"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "thuongLamCa"));
                dr["tienThuongSL"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienThuongSL"));
                dr["Allowance_Moi"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "Allowance"));
                dr["Allowance_Cu"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r2, "Allowance"));
                dr["ConTho"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "ConTho"));
                dr["ThueTNCN"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "ThueTNCN"));

                for (int i = 1; i < 21; i++)
                {
                    dr["PC" + i] = string.Format("{0:#,0}", Math.Abs(DbHelper.DrGetDouble(r, "PC" + i)));
                    dr["Calc" + i] = string.Format("{0:#,0}", Math.Abs(DbHelper.DrGetDouble(r, "Calc" + i)));
                }
                dr["tongThuongCalc"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tongThuongCalc"));
                dr["tongPhuCapKhac"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tongPhuCapKhac"));
                dr["PhuCapTrachNhiem"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "PhuCapTrachNhiem"));
                dr["tongLuongTG"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tongLuongTG"));
                dr["tongLuong"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tongLuong"));
                dr["BH105"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "BH105"));
                dr["phiCongDoan"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "phiCongDoan"));
                dr["isLuongSP"] = DbHelper.DrGetBoolean(r, "isLuongSP");
                //dr["Thuong"] = DbHelper.DrGetBoolean(r, "isLuongSP") == true ? string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tongLuong") 
                //                                                             - DbHelper.DrGetDouble(r, "tongLuongTG") - DbHelper.DrGetDouble(r, "PC3") 
                //                                                             - DbHelper.DrGetDouble(r, "PC4")) : "0";
                dr["actualBankTransfer"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "actualBankTransfer"));
                dr["tongKhauTru"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tongKhauTru")); //du lieu muon dien vao

                dtData.Rows.Add(dr);
            }
            if (dtData.Rows.Count > 0)
            {
                return dtData.Select("", "phongban,LineName,manv").CopyToDataTable();
            }
            else
                return null;

        }
        public DataTable GetDataByLstEmp(DateTime cMonth, int soNC, string strEmpID, DateTime tuNgay, DateTime denNgay)
        {
            DataTable dtData = null;
            foreach (string empID in strEmpID.Split(','))
            {
                if (string.IsNullOrWhiteSpace(empID))
                    continue;

                var dt = GetData(cMonth, soNC, empID, 0, "", tuNgay, denNgay);
                if (dtData == null)
                {
                    dtData = dt;
                }
                else
                {
                    if (dt != null)
                        dtData.ImportRow(dt.Rows[0]);
                }
            }

            return dtData;
        }
        #endregion
        #region Get data bảng lương 1 dòng.
        public DataTable GetData_1dong(DateTime cMonth, int soNC, string empID, int group1ID, string deptID, DateTime tuNgay, DateTime denNgay)
        {
            DataTable dt;
            if (!string.IsNullOrWhiteSpace(empID))
            {
                dt = logic.GetBangLuong_1dong_ByEmp(cMonth, empID, tuNgay, denNgay, soNC);
            }
            else if (group1ID > 0)
            {
                dt = logic.GetBangLuong_1dong_ByGroup1(cMonth, group1ID, tuNgay, denNgay, soNC);
            }
            else
            {
                dt = logic.GetBangLuong_1dong(cMonth, tuNgay, denNgay, deptID, soNC);
            }
            string tenCty = db.w5Systems.Where(p => p.Ma == "TitlePhieuLuong").FirstOrDefault().TitleEN;
            var dtData = new DataTable();
            dtData.Columns.AddRange("empoyeeID,tenCongTy,thang,nam,chukyluong,hoten,manv,cmnd,soTK,ngayVao,phongban,luongCu,luongPcCu,luongMoi,luongPcMoi,ngayHdMoi,tongLuongSP,tongNgayCong,tongNgayCongCu,tienNgayCong,tienNgayCongCu,ngaycong_bt,tienNC_bt,ngaycong_bt_Cu,tienNC_bt_Cu,ngaycong_phep,tienNC_phep,ngaycong_lt,tienNC_lt,tgTangCa_cn,tienTangCa_cn,tongTgTangCa_cn_gio,tongTienTangCa_cn,tgTangCa_lt,tienTangCa_lt,tgTangCa_bt,tienTangCa_bt,tgTangCa_bt_Cu,tienTangCa_bt_Cu,ngaycong_phepNam,tienNC_phepNam,tongThoiGianTangCa_cu,tongThoiGianTangCa_moi,tienTangCa_cu,tienTangCa_moi,luongSP,luongTangCaSP,Calc1,Calc2,Calc3,Calc4,Calc5,Calc6,Calc7,Calc8,Calc9,Calc10,Calc11,Calc12,Calc13,Calc14,Calc15,Calc16,Calc17,Calc18,Calc19,Calc20,tongThuongCalc,PC1,PC2,PC3,PC4,PC5,PC6,PC7,PC8,PC9,PC10,PC11,PC12,PC13,PC14,PC15,PC16,PC17,PC18,PC19,PC20,tongPhuCapKhac,tongLuong,BH105,actualBankTransfer,tongKhauTru,phiCongDoan,tienThuongSL,thuongBuaToi,thuongBuaToi_Cu,thuongLamCa,tongLuongTG,Allowance_Cu,Allowance_Moi,ConTho,isLuongSP,Thuong,LineName,ngayCong_Dem,ngayCong_Dem_Cu,tienNC_Dem,tienNC_Dem_Cu,tgTangCa_Dem,tienTangCa_Dem,tgTangCa_Dem_Cu,tienTangCa_Dem_Cu,PhuCapTrachNhiem,ThueTNCN"
                .Split(',').Select(i => new DataColumn(i)).ToArray()
            );

            foreach (string eID in dt.Select().Select(i => i["empoyeeID"]).Distinct())
            {
                DataRow r = dt.Select("empoyeeID='" + eID + "'").SingleOrDefault();

                var dr = dtData.NewRow();
                if (cMonth.Month + 1 > 12)
                {
                    dr["thang"] = string.Format("{0:00}", 1);
                    dr["nam"] = (cMonth.Year + 1).ToString();
                }
                else
                {
                    dr["thang"] = string.Format("{0:00}", cMonth.Month + 1);
                    dr["nam"] = cMonth.Year.ToString();
                }

                dr["hoten"] = DbHelper.DrGetString(r, "tenNV");
                dr["manv"] = DbHelper.DrGetString(r, "empoyeeID");
                dr["cmnd"] = DbHelper.DrGetString(r, "IDCard");
                dr["ngayVao"] = string.Format("{0:dd/MM/yyyy}", DbHelper.DrGetDateTime(r, "ngayVao"));
                dr["phongban"] = DbHelper.DrGetString(r, "DepName");
                dr["LineName"] = DbHelper.DrGetString(r, "LineName");
                dr["luongSP"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "luongSP"));
                dr["tongLuongSP"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tongLuongSP"));
                dr["tongLuongTG"] = string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tongLuongTG"));

                dr["luongCu"] = (DbHelper.DrGetDouble(r, "luongCB_Cu")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "luongCB_Cu"));
                dr["luongPcCu"] = (DbHelper.DrGetDouble(r, "luongPC_Cu")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "luongPC_Cu"));
                dr["luongMoi"] = (DbHelper.DrGetDouble(r, "luongCB_Moi")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "luongCB_Moi"));
                dr["luongPcMoi"] = (DbHelper.DrGetDouble(r, "luongPC_Moi")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "luongPC_Moi"));
                //dr["ngayHdMoi"] = ""; //string.Format("{0:dd/MM/yyyy}", null); //-------hardcode

                dr["ngaycong_bt"] = (DbHelper.DrGetDouble(r, "ngayCong_bt_Moi")) == 0 ? "-" : string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "ngayCong_bt_Moi"));
                dr["tienNC_bt"] = (DbHelper.DrGetDouble(r, "tienNC_bt_Moi")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienNC_bt_Moi"));
                dr["ngayCong_Dem"] = (DbHelper.DrGetDouble(r, "ngayCong_Dem_Moi")) == 0 ? "-" : string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "ngayCong_Dem_Moi"));
                dr["tienNC_Dem"] = (DbHelper.DrGetDouble(r, "tienNC_Dem_Moi")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienNC_Dem_Moi"));

                dr["ngaycong_bt_Cu"] = (DbHelper.DrGetDouble(r, "ngayCong_bt_Cu")) == 0 ? "-" : string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "ngayCong_bt_Cu"));
                dr["tienNC_bt_Cu"] = (DbHelper.DrGetDouble(r, "tienNC_bt_Cu")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienNC_bt_Cu"));
                dr["ngayCong_Dem_Cu"] = (DbHelper.DrGetDouble(r, "ngayCong_Dem_Cu")) == 0 ? "-" : string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "ngayCong_Dem_Cu"));
                dr["tienNC_Dem_Cu"] = (DbHelper.DrGetDouble(r, "tienNC_Dem_Cu")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienNC_Dem_Cu"));
                dr["ngaycong_phep"] = (DbHelper.DrGetDouble(r, "tongNgayCong_phep_Total")) == 0 ? "-" : string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "tongNgayCong_phep_Total"));
                dr["tienNC_phep"] = (DbHelper.DrGetDouble(r, "tongTienNC_phep_Total")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tongTienNC_phep_Total"));
                dr["ngaycong_phepNam"] = (DbHelper.DrGetDouble(r, "tongNgayCong_phepNam_Total")) == 0 ? "-" : string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "tongNgayCong_phepNam_Total"));
                dr["tienNC_phepNam"] = (DbHelper.DrGetDouble(r, "tongTienNC_phepNam_Total")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tongTienNC_phepNam_Total"));
                dr["ngaycong_lt"] = (DbHelper.DrGetDouble(r, "tongNgayCong_lt_Total")) == 0 ? "-" : string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "tongNgayCong_lt_Total"));
                dr["tienNC_lt"] = (DbHelper.DrGetDouble(r, "tongTienNC_lt_Total")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tongTienNC_lt_Total"));

                //",tgTangCa_Thuong,tienTangCa_Thuong,tgTangCa_Dem,tienTangCa_Dem,tgTangCa_cn,tienTangCa_cn,tongTgTangCa_cn_gio,tongTienTangCa_cn,tgTangCa_lt,tienTangCa_lt",
                dr["tgTangCa_bt"] = (DbHelper.DrGetDouble(r, "tgTangCa_bt_Moi")) == 0 ? "-" : string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "tgTangCa_bt_Moi"));
                dr["tienTangCa_bt"] = (DbHelper.DrGetDouble(r, "tienTangCa_bt_Moi")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienTangCa_bt_Moi"));
                dr["tgTangCa_bt_Cu"] = (DbHelper.DrGetDouble(r, "tgTangCa_bt_Cu")) == 0 ? "-" : string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "tgTangCa_bt_Cu"));
                dr["tienTangCa_bt_Cu"] = (DbHelper.DrGetDouble(r, "tienTangCa_bt_Cu")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienTangCa_bt_Cu"));

                dr["tgTangCa_Dem"] = (DbHelper.DrGetDouble(r, "tgTangCa_Dem_Moi")) == 0 ? "-" : string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "tgTangCa_Dem_Moi"));
                dr["tienTangCa_Dem"] = (DbHelper.DrGetDouble(r, "tienTangCa_Dem_Moi")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienTangCa_Dem_Moi"));
                dr["tgTangCa_Dem_Cu"] = (DbHelper.DrGetDouble(r, "tgTangCa_Dem_Cu")) == 0 ? "-" : string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "tgTangCa_Dem_Cu"));
                dr["tienTangCa_Dem_Cu"] = (DbHelper.DrGetDouble(r, "tienTangCa_Dem_Cu")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienTangCa_Dem_Cu"));

                dr["tongTgTangCa_cn_gio"] = (DbHelper.DrGetDouble(r, "tongTgTangCa_cn_gio")) == 0 ? "-" : string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "tongTgTangCa_cn_gio"));
                dr["tongTienTangCa_cn"] = (DbHelper.DrGetDouble(r, "tongTienTangCa_cn_Total") + DbHelper.DrGetDouble(r, "tongTienNC_cn_Total")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tongTienTangCa_cn_Total") + DbHelper.DrGetDouble(r, "tongTienNC_cn_Total"));
                dr["tgTangCa_lt"] = (DbHelper.DrGetDouble(r, "tongTgTangCa_lt_Total")) == 0 ? "-" : string.Format("{0:#,0.00}", DbHelper.DrGetDouble(r, "tongTgTangCa_lt_Total"));
                dr["tienTangCa_lt"] = (DbHelper.DrGetDouble(r, "tongTienTangCa_lt_Total")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tongTienTangCa_lt_Total"));

                //",Calc1,Calc2,Calc3,Calc4,Calc5,Calc6,Calc7,Calc8,Calc9,Calc10,Calc11,Calc12,Calc13,Calc14,Calc15,Calc16,Calc17,Calc18,Calc19,Calc20,tongThuongCalc,PC1,PC2,PC3,PC4,PC5,PC6,PC7,PC8,PC9,PC10,PC11,PC12,PC13,PC14,PC15,PC16,PC17,PC18,PC19,PC20",
                //",PhuCapTrachNhiem,tienThuongSL,tongLuong,BH105,phiCongDoan,ThueTNCN,tamUngLuong,tongKhauTru,actualBankTransfer"

                dr["thuongBuaToi"] = (DbHelper.DrGetDouble(r, "thuongBuaToi")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "thuongBuaToi"));
                dr["thuongLamCa"] = (DbHelper.DrGetDouble(r, "thuongLamCa")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "thuongLamCa"));
                dr["tienThuongSL"] = (DbHelper.DrGetDouble(r, "tienThuongSL")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienThuongSL"));
                dr["ConTho"] = (DbHelper.DrGetDouble(r, "ConTho")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "ConTho"));
                dr["ThueTNCN"] = (DbHelper.DrGetDouble(r, "ThueTNCN")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "ThueTNCN"));
                dr["PhuCapTrachNhiem"] = (DbHelper.DrGetDouble(r, "PhuCapTrachNhiem")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "PhuCapTrachNhiem"));
                dr["tongLuong"] = (DbHelper.DrGetDouble(r, "tongLuong")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tongLuong"));

                dr["ThueTNCN"] = (DbHelper.DrGetDouble(r, "ThueTNCN")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "ThueTNCN"));

                for (int i = 1; i < 21; i++)
                {
                    dr["PC" + i] = (DbHelper.DrGetDouble(r, "PC" + i)) == 0 ? "-" : string.Format("{0:#,0}", Math.Abs(DbHelper.DrGetDouble(r, "PC" + i)));
                    dr["Calc" + i] = (DbHelper.DrGetDouble(r, "Calc" + i)) == 0 ? "-" : string.Format("{0:#,0}", Math.Abs(DbHelper.DrGetDouble(r, "Calc" + i)));
                }
                dr["BH105"] = (DbHelper.DrGetDouble(r, "tienBHXH") + DbHelper.DrGetDouble(r, "tienBHTN") + DbHelper.DrGetDouble(r, "tienBHYT")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tienBHXH") + DbHelper.DrGetDouble(r, "tienBHTN") + DbHelper.DrGetDouble(r, "tienBHYT"));
                dr["phiCongDoan"] = (DbHelper.DrGetDouble(r, "phiCongDoan")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "phiCongDoan"));
                dr["tongKhauTru"] = (DbHelper.DrGetDouble(r, "tongKhauTru")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "tongKhauTru"));
                //dr["tamUngLuong"] = "-";
                dr["actualBankTransfer"] = (DbHelper.DrGetDouble(r, "actualBankTransfer")) == 0 ? "-" : string.Format("{0:#,0}", DbHelper.DrGetDouble(r, "actualBankTransfer"));

                dtData.Rows.Add(dr);
            }
            if (dtData.Rows.Count > 0)
            {
                return dtData.Select("", "phongban,LineName,manv").CopyToDataTable();
            }
            else
                return null;

        }
        public DataTable GetData_1dong_ByLstEmp(DateTime cMonth, int soNC, string strEmpID, DateTime tuNgay, DateTime denNgay)
        {
            DataTable dtData = null;
            foreach (string empID in strEmpID.Split(','))
            {
                if (string.IsNullOrWhiteSpace(empID))
                    continue;

                var dt = GetData_1dong(cMonth, soNC, empID, 0, "", tuNgay, denNgay);
                if (dtData == null)
                {
                    dtData = dt;
                }
                else
                {
                    if (dt != null)
                        dtData.ImportRow(dt.Rows[0]);
                }
            }

            return dtData;
        }
        #endregion
    }
}
