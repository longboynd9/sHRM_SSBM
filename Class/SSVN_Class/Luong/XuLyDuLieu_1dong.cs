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
using System.Diagnostics;
using iHRM.Core.Controller;
using iHRM.Common.Code;

namespace iHRM.Win.ExtClass.Luong
{
    public class XuLyDuLieu_1dong : LogicBase
    {
        TinhLuong logic = new TinhLuong();
        dsTinhLuong ds = new dsTinhLuong();
        public LogicProgress lp = new LogicProgress();

        public w5sysUser UserDoing;
        public XuLyDuLieu_1dong(w5sysUser uLogged)
        {
            UserDoing = uLogged;
        }
        public void doAnalyza(DateTime tuNgay, DateTime denNgay, string empID, string depID, int group1ID, bool chkLamTron)
        {
            TinhLuong logic = new TinhLuong();
            dsTinhLuong ds = new dsTinhLuong();
            int soNgayCongThucTeTrongThang = iHRM.Common.DungChung.Ham.DemNgayCong(tuNgay, denNgay);
            try
            {
                //reg progress...
                lp.SetTitle("Đang lấy dữ liệu..");
                lp.OutMessage("Lấy dữ liệu ----------------------------------------------------------------------------------");

                #region get data
                ds = new dsTinhLuong();
                DateTime cMonth = new DateTime(tuNgay.Year, tuNgay.Month, 1);

                Provider.LoadData(ds, ds.tbCaLam_TinhTangCa.TableName);
                lp.OutMessage("Ca làm việc (tính tăng ca): " + ds.tbCaLam_TinhTangCa.Rows.Count);
                Provider.LoadData(ds, ds.tblRef_Allowance.TableName);
                lp.OutMessage("Phụ cấp Allowance: " + ds.tblRef_Allowance.Rows.Count);
                Provider.LoadData(ds, ds.tblEmpAllowanceFix.TableName);
                lp.OutMessage("Phụ cấp hàng tháng: " + ds.tblEmpAllowanceFix.Rows.Count);

                Provider.LoadDataByProc(ds, ds.tblEmpSalary.TableName, "p_tinhLuong_GetLuongCoBan", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay));
                lp.OutMessage("Lương cơ bản: " + ds.tblEmpSalary.Rows.Count);
                //tuNgay.AddDays(-1) Sinh ngày 17 là k đc nhận thưởng con thơ nữa.
                Provider.LoadDataByProc(ds, ds.tblEmpChild.TableName, "p_tinhLuong_GetChilds", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay));
                lp.OutMessage("Con thơ: " + ds.tblEmpChild.Rows.Count);
                Provider.LoadDataByProc(ds, ds.tbDangKyVangMat.TableName, "p_duLieuQuetThe_GetAllDangKyVangMat_CoThe", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay));
                lp.OutMessage("Đăng ký vắng mặt: " + ds.tbDangKyVangMat.Rows.Count);
                Provider.LoadData(ds, ds.tbBangLuongCalc.TableName);
                lp.OutMessage("Công thức tính lương: " + ds.tbBangLuongCalc.Rows.Count);
                if (!string.IsNullOrWhiteSpace(empID))
                {
                    Provider.LoadDataByProc(ds, ds.tbThamSoTinhLuong.TableName, "p_tinhLuong_GetThamSoTinhLuong_WithEmp", new SqlParameter("thang", cMonth), new SqlParameter("empID", empID));
                    Provider.LoadDataByProc(ds, ds.p_tinhLuong_GetAllKetQuaQuetThe.TableName, "p_tinhLuong_GetAllKetQuaQuetThe_WithEmp", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay), new SqlParameter("empID", empID));
                    Provider.LoadDataByProc(ds, ds.tblEmpAllowanceFix.TableName, "p_tinhLuong_GetPCCD_WithEmp", new SqlParameter("empID", empID));

                    lp.OutMessage(">>> " + Lng.Luong_AnalyzeData.resetBL + " (" + empID + ") " + logic.ResetBangLuong_1dong_withEmp(cMonth, empID));
                }
                else if (!string.IsNullOrWhiteSpace(depID))
                {
                    Provider.LoadDataByProc(ds, ds.tbThamSoTinhLuong.TableName, "p_tinhLuong_GetThamSoTinhLuong_WithDept", new SqlParameter("thang", cMonth), new SqlParameter("maTapThe", depID));
                    Provider.LoadDataByProc(ds, ds.p_tinhLuong_GetAllKetQuaQuetThe.TableName, "p_tinhLuong_GetAllKetQuaQuetThe_WithDept", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay), new SqlParameter("maTapThe", depID));
                    Provider.LoadDataByProc(ds, ds.tblEmpAllowanceFix.TableName, "p_tinhLuong_GetPCCD_WithDept", new SqlParameter("maTapThe", depID));

                    lp.OutMessage(">>> " + Lng.Luong_AnalyzeData.resetBL + " (" + depID + ") " + logic.ResetBangLuong_1dong_withDep(cMonth, depID));
                }
                else if (group1ID > 0)
                {
                    Provider.LoadDataByProc(ds, ds.tbThamSoTinhLuong.TableName, "p_tinhLuong_GetThamSoTinhLuong_WithGroup1", new SqlParameter("thang", cMonth), new SqlParameter("group1ID", group1ID));
                    Provider.LoadDataByProc(ds, ds.p_tinhLuong_GetAllKetQuaQuetThe.TableName, "p_tinhLuong_GetAllKetQuaQuetThe_WithGroup1", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay), new SqlParameter("group1ID", group1ID));
                    Provider.LoadDataByProc(ds, ds.tblEmpAllowanceFix.TableName, "p_tinhLuong_GetPCCD_WithGroup1", new SqlParameter("group1ID", group1ID));

                    lp.OutMessage(">>> " + Lng.Luong_AnalyzeData.resetBL + " (Group1: " + group1ID + ") " + logic.ResetBangLuong_1dong_withGroup1(cMonth, group1ID));
                }
                else
                {
                    Provider.LoadDataByProc(ds, ds.tbThamSoTinhLuong.TableName, "p_tinhLuong_GetThamSoTinhLuong", new SqlParameter("thang", cMonth));
                    Provider.LoadDataByProc(ds, ds.p_tinhLuong_GetAllKetQuaQuetThe.TableName, "p_tinhLuong_GetAllKetQuaQuetThe", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay));
                    Provider.LoadDataByProc(ds, ds.tblEmpAllowanceFix.TableName, "p_tinhLuong_GetPCCD");

                    lp.OutMessage(Lng.Luong_AnalyzeData.resetBL + logic.ResetBangLuong_1dong(cMonth));
                }

                lp.OutMessage("Tham số tính lương: " + ds.tbThamSoTinhLuong.Rows.Count);
                lp.OutMessage(Lng.Luong_AnalyzeData.ketquaCC + ds.p_tinhLuong_GetAllKetQuaQuetThe.Rows.Count);
                lp.OutMessage("Phụ cấp cố định: " + ds.tblEmpAllowanceFix.Rows.Count);
                #endregion

                var lstEmp = ds.p_tinhLuong_GetAllKetQuaQuetThe.Select(i => i.EmployeeID).Distinct();
                lp.MaxValue = lstEmp.Count();
                lp.CurrentValue = 0;
                foreach (string eID in lstEmp)
                {

                    try
                    {
                        var kqs = ds.p_tinhLuong_GetAllKetQuaQuetThe.Where(i => i.EmployeeID == eID).ToList();

                        var r = ds.tbBangLuongThang_1dong.NewtbBangLuongThang_1dongRow(); r.id = Guid.NewGuid();
                        var e1 = kqs[0];
                        #region tính lương

                        TinhLuongHelper_1dong hp = new TinhLuongHelper_1dong(ds, tuNgay, denNgay, e1.EmployeeID);

                        r.thang = cMonth;
                        r.empoyeeID = eID;

                        if (hp.luongMoi == null && hp.luongCu == null)
                        {
                            hp.luongMoi = ds.tblEmpSalary.Where(i => i.EmployeeID == e1.EmployeeID).OrderByDescending(i => i.DateChange).FirstOrDefault();
                        }
                        r.luongCB_Moi = hp.luongMoi == null ? (e1["BasicSalary"] == DBNull.Value ? 0 : e1.BasicSalary) : hp.luongMoi.BasicSalary;
                        r.luongPC_Moi = hp.luongMoi == null ? (e1["RegularAllowance"] == DBNull.Value ? 0 : e1.RegularAllowance) : hp.luongMoi.BasicSalary_Ins;

                        r.luongCB_Cu = (hp.luongCu == null) ? 0 : hp.luongCu.BasicSalary;
                        r.luongPC_Cu = (hp.luongCu == null) ? 0 : hp.luongCu.BasicSalary_Ins;
                        // Gán 0 cho ngày công:
                        r.ngayCong_bt_Cu = r.ngayCong_Dem_Cu = r.ngayCong_ChoViec_Cu = r.ngayCong_phep_Cu = r.ngayCong_phepNam_Cu = r.ngayCong_lt_Cu = r.ngayCong_cn_Cu = r.tongNgayCong_Cu = 0;
                        r.ngayCong_bt_Moi = r.ngayCong_Dem_Moi = r.ngayCong_ChoViec_Moi = r.ngayCong_phep_Moi = r.ngayCong_phepNam_Moi = r.ngayCong_lt_Moi = r.ngayCong_cn_Moi = r.tongNgayCong_Moi = 0;
                        r.tongNgayCong_bt_Total = r.tongNgayCong_Dem_Total = r.tongNgayCong_ChoViec_Total = r.tongNgayCong_phep_Total = r.tongNgayCong_phepNam_Total = r.tongNgayCong_lt_Total = r.tongNgayCong_cn_Total = r.tongNgayCong_Total = 0;
                        r.tienNC_bt_Cu = r.tienNC_Dem_Cu = r.tienNC_ChoViec_Cu = r.tienNC_phep_Cu = r.tienNC_phepNam_Cu = r.tienNC_lt_Cu = r.tienNC_cn_Cu = r.tongTienNgayCong_Cu = 0;
                        r.tienNC_bt_Moi = r.tienNC_Dem_Moi = r.tienNC_ChoViec_Moi = r.tienNC_phep_Moi = r.tienNC_phepNam_Moi = r.tienNC_lt_Moi = r.tienNC_cn_Moi = r.tongTienNgayCong_Moi = 0;
                        r.tongTienNC_bt_Total = r.tongTienNC_Dem_Total = r.tongTienNC_ChoViec_Total = r.tongTienNC_phep_Total = r.tongTienNC_phepNam_Total = r.tongTienNC_lt_Total = r.tongTienNC_cn_Total = r.tongTienNgayCong_Total = 0;
                        // Gán 0 cho giờ tăng ca:
                        r.tgTangCa_bt_Cu = r.tgTangCa_Dem_Cu = r.tgTangCa_cn_Cu = r.tgTangCa_lt_Cu = r.tongTgTangCa_Cu = 0;
                        r.tgTangCa_bt_Moi = r.tgTangCa_Dem_Moi = r.tgTangCa_cn_Moi = r.tgTangCa_lt_Moi = r.tongTgTangCa_Moi = 0;
                        r.tongTgTangCa_bt_Total = r.tongTgTangCa_Dem_Total = r.tongTgTangCa_cn_Total = r.tongTgTangCa_lt_Total = r.tongTgTangCa_Total = 0;
                        r.tienTangCa_bt_Cu = r.tienTangCa_Dem_Cu = r.tienTangCa_cn_Cu = r.tienTangCa_lt_Cu = r.tongTienTangCa_Cu = r.tienTangCa_bt_Moi = r.tienTangCa_Dem_Moi = r.tienTangCa_cn_Moi = r.tienTangCa_lt_Moi = 0;
                        r.tongTienTangCa_Moi = r.tongTienTangCa_bt_Total = r.tongTienTangCa_Dem_Total = r.tongTienTangCa_cn_Total = r.tongTienTangCa_lt_Total = r.tongTienTangCa_Total = 0;
                        // Gán 0 cho các khoản khác
                        r.tongPhuCapKhac = r.tongLuong = r.tienBHXH = r.tienBHTN = r.tienBHYT = r.khoanTruKhac = r.tamUngLuong = r.tongKhauTru = r.actualBankTransfer = r.luongSP = r.luongTangCaSP = r.luongSP_tong = r.luongThoiGian = r.tongTgTangCa_cn_gio = r.phiCongDoan = r.tienThuongSL = r.tongLuongTG = r.ConTho = r.PhuCapTrachNhiem = r.LuongThucNhanTinhThue = r.ThueTNCN = 0;
                        r.thuongBuaToi = r.thuongLamCa = 0;
                        r.SoNguoiPhuThuoc = 0;
                        for (int i = 1; i < 21; i++)
                        {
                            r["Calc" + i] = 0;
                            r["PC" + i] = 0;
                        }

                        double f;
                        foreach (var kq in kqs)
                        {

                            hp.Set_KQQT(kq);
                            #region tinh ngay cong theo luong moi
                            r.ngayCong_bt_Moi += hp.TinhNgayCong(1);
                            r.tienNC_bt_Moi += hp.TinhTienNgayCong(1);

                            r.ngayCong_Dem_Moi += hp.TinhNgayCong(1, tinhCaDem: true);

                            var a = hp.TinhTienNgayCong(1, tinhCaDem: true);
                            r.tienNC_Dem_Moi += hp.TinhTienNgayCong(1, tinhCaDem: true);
                            //Phép năm
                            r.ngayCong_phep_Moi += hp.TinhNgayCong(5);
                            r.tienNC_phep_Moi += hp.TinhTienNgayCong(5);
                            r.tienNC_phep_Moi += hp.TinhTienNgayCong(5, tinhCaDem: true);
                            // các loại nghỉ khác có hưởng lương.
                            f = hp.TinhNgayCong(2);
                            r.ngayCong_phepNam_Moi += f;
                            r.tienNC_phepNam_Moi += hp.TinhTienNgayCong(2);
                            r.tienNC_phepNam_Moi += hp.TinhTienNgayCong(2, tinhCaDem: true);

                            r.ngayCong_lt_Moi += hp.TinhNgayCong(3);
                            r.tienNC_lt_Moi += hp.TinhTienNgayCong(3);
                            r.tienNC_lt_Moi += hp.TinhTienNgayCong(3, tinhCaDem: true);
                            // Tính chủ nhật sẽ đc tính vào tăng ca.
                            r.ngayCong_cn_Moi += hp.TinhNgayCong(4);
                            r.tienNC_cn_Moi += hp.TinhTienNgayCong(4);
                            r.tienNC_cn_Moi += hp.TinhTienNgayCong(4, tinhCaDem: true);
                            #endregion

                            #region tinh tang ca theo luong moi
                            var f1 = hp.TinhTienTangCa(1);
                            r.tgTangCa_bt_Moi += hp.TinhGioTangCa(1);
                            r.tienTangCa_bt_Moi += hp.TinhTienTangCa(1);

                            r.tgTangCa_Dem_Moi += hp.TinhGioTangCa(1, tinhCaDem: true);
                            r.tienTangCa_Dem_Moi += hp.TinhTienTangCa(1, tinhCaDem: true);

                            // Tính chủ nhật sẽ đc tính vào tăng ca.
                            r.tgTangCa_cn_Moi += hp.TinhGioTangCa(4);
                            r.tienTangCa_cn_Moi += hp.TinhTienTangCa(4);
                            r.tienTangCa_cn_Moi += hp.TinhTienTangCa(4, tinhCaDem: true);

                            r.tgTangCa_lt_Moi += hp.TinhGioTangCa(3);
                            r.tienTangCa_lt_Moi += hp.TinhTienTangCa(3);
                            r.tienTangCa_lt_Moi += hp.TinhTienTangCa(3, tinhCaDem: true);
                            #endregion

                            if (hp.luongCu != null)
                            {
                                #region tinh ngay cong theo luong cu
                                r.ngayCong_bt_Cu += hp.TinhNgayCong(1, true);
                                r.tienNC_bt_Cu += hp.TinhTienNgayCong(1, true);

                                r.ngayCong_Dem_Cu += hp.TinhNgayCong(1, true, tinhCaDem: true);
                                r.tienNC_Dem_Cu += hp.TinhTienNgayCong(1, true, tinhCaDem: true);

                                r.ngayCong_phep_Cu += hp.TinhNgayCong(5, true);
                                r.tienNC_phep_Cu += hp.TinhTienNgayCong(5, true);
                                r.tienNC_phep_Cu += hp.TinhTienNgayCong(5, true, tinhCaDem: true);

                                r.ngayCong_phepNam_Cu += hp.TinhNgayCong(2, true);
                                r.tienNC_phepNam_Cu += hp.TinhTienNgayCong(2, true);
                                r.tienNC_phepNam_Cu += hp.TinhTienNgayCong(2, true, tinhCaDem: true);

                                r.ngayCong_lt_Cu += hp.TinhNgayCong(3, true);
                                r.tienNC_lt_Cu += hp.TinhTienNgayCong(3, true);
                                r.tienNC_lt_Cu += hp.TinhTienNgayCong(3, true, tinhCaDem: true);

                                // Tính chủ nhật sẽ đc tính vào tăng ca.
                                r.ngayCong_cn_Cu += hp.TinhNgayCong(4, true);
                                r.tienNC_cn_Cu += hp.TinhTienNgayCong(4, true);
                                r.tienNC_cn_Cu += hp.TinhTienNgayCong(4, true, tinhCaDem: true);
                                #endregion

                                #region tinh tang ca theo luong cu
                                r.tgTangCa_bt_Cu += hp.TinhGioTangCa(1, true);
                                r.tienTangCa_bt_Cu += hp.TinhTienTangCa(1, true);

                                r.tgTangCa_Dem_Cu += hp.TinhGioTangCa(1, true, tinhCaDem: true);
                                r.tienTangCa_Dem_Cu += hp.TinhTienTangCa(1, true, tinhCaDem: true);

                                // Tính chủ nhật sẽ đc tính vào tăng ca.
                                r.tgTangCa_cn_Cu += hp.TinhGioTangCa(4, true);
                                r.tienTangCa_cn_Cu += hp.TinhTienTangCa(4, true);
                                r.tienTangCa_cn_Cu += hp.TinhTienTangCa(4, true, tinhCaDem: true);


                                r.tgTangCa_lt_Cu += hp.TinhGioTangCa(3, true);
                                r.tienTangCa_lt_Cu += hp.TinhTienTangCa(3, true, tinhCaDem: true);
                                #endregion
                            }
                        }
                        #endregion

                        #region rounded money
                        r.tienNC_bt_Moi = Math.Round(r.tienNC_bt_Moi, 0);
                        r.tienNC_phep_Moi = Math.Round(r.tienNC_phep_Moi, 0);
                        r.tienNC_phepNam_Moi = Math.Round(r.tienNC_phepNam_Moi, 0);
                        r.tienNC_lt_Moi = Math.Round(r.tienNC_lt_Moi, 0);
                        r.tienNC_cn_Moi = Math.Round(r.tienNC_cn_Moi, 0);

                        r.tienTangCa_bt_Moi = Math.Round(r.tienTangCa_bt_Moi, 0);
                        r.tienTangCa_cn_Moi = Math.Round(r.tienTangCa_cn_Moi, 0);
                        r.tienTangCa_lt_Moi = Math.Round(r.tienTangCa_lt_Moi, 0);


                        r.tienNC_bt_Cu = Math.Round(r.tienNC_bt_Cu, 0);
                        r.tienNC_phep_Cu = Math.Round(r.tienNC_phep_Cu, 0);
                        r.tienNC_phepNam_Cu = Math.Round(r.tienNC_phepNam_Cu, 0);
                        r.tienNC_lt_Cu = Math.Round(r.tienNC_lt_Cu, 0);
                        r.tienNC_cn_Cu = Math.Round(r.tienNC_cn_Cu, 0);

                        r.tienTangCa_bt_Cu = Math.Round(r.tienTangCa_bt_Cu, 0);
                        r.tienTangCa_cn_Cu = Math.Round(r.tienTangCa_cn_Cu, 0);
                        r.tienTangCa_lt_Cu = Math.Round(r.tienTangCa_lt_Cu, 0);
                        #endregion

                        #region tinh tong
                        // Ngày công:
                        // ---------- Công----------
                        r.tongNgayCong_Moi = r.ngayCong_bt_Moi + r.ngayCong_ChoViec_Moi + r.ngayCong_phep_Moi + r.ngayCong_phepNam_Moi + r.ngayCong_lt_Moi + r.ngayCong_Dem_Moi;
                        r.tongNgayCong_Cu = r.ngayCong_bt_Cu + r.ngayCong_ChoViec_Cu + r.ngayCong_phep_Cu + r.ngayCong_phepNam_Cu + r.ngayCong_lt_Cu + r.ngayCong_Dem_Cu;

                        r.tongNgayCong_bt_Total = r.ngayCong_bt_Moi + r.ngayCong_bt_Cu;
                        r.tongNgayCong_Dem_Total = r.ngayCong_Dem_Moi + r.ngayCong_Dem_Cu;
                        r.tongNgayCong_phep_Total = r.ngayCong_phep_Moi + r.ngayCong_phep_Cu;
                        r.tongNgayCong_phepNam_Total = r.ngayCong_phepNam_Moi + r.ngayCong_phepNam_Cu;
                        r.tongNgayCong_ChoViec_Total = r.ngayCong_ChoViec_Moi + r.ngayCong_ChoViec_Cu;
                        r.tongNgayCong_lt_Total = r.ngayCong_lt_Moi + r.ngayCong_lt_Cu;

                        r.tongNgayCong_Total = r.tongNgayCong_Moi + r.tongNgayCong_Cu;
                        // ------------Lương ngày công-------
                        r.tongTienNgayCong_Moi = r.tienNC_bt_Moi + r.tienNC_ChoViec_Moi + r.tienNC_phep_Moi + r.tienNC_phepNam_Moi + r.tienNC_lt_Moi + r.tienNC_Dem_Moi;
                        r.tongTienNgayCong_Cu = r.tienNC_bt_Cu + r.tienNC_ChoViec_Cu + r.tienNC_phep_Cu + r.tienNC_phepNam_Cu + r.tienNC_lt_Cu + r.tienNC_Dem_Cu;

                        r.tongTienNC_bt_Total = r.tienNC_bt_Moi + r.tienNC_bt_Cu;
                        r.tongTienNC_Dem_Total = r.tienNC_Dem_Moi + r.tienNC_Dem_Cu;
                        r.tongTienNC_phep_Total = r.tienNC_phep_Moi + r.tienNC_phep_Cu;
                        r.tongTienNC_phepNam_Total = r.tienNC_phepNam_Moi + r.tienNC_phepNam_Cu;
                        r.tongTienNC_ChoViec_Total = r.tienNC_ChoViec_Moi + r.tienNC_ChoViec_Cu;
                        r.tongTienNC_lt_Total = r.tienNC_lt_Moi + r.tienNC_lt_Cu;

                        r.tongTienNgayCong_Total = r.tongTienNgayCong_Moi + r.tongTienNgayCong_Cu;
                        // Tăng ca:
                        //-------------Thời gian tăng ca--------------
                        // Chủ nhật thì tính vào tăng ca: tg làm chủ nhật = Ngày công * 8 + tgTinhTangCa
                        r.tongNgayCong_cn_Total = r.ngayCong_cn_Moi + r.ngayCong_cn_Cu;


                        r.tongTgTangCa_Moi = r.tgTangCa_bt_Moi + r.tgTangCa_Dem_Moi + r.tgTangCa_cn_Moi + r.tgTangCa_lt_Moi;
                        r.tongTgTangCa_Cu = r.tgTangCa_bt_Cu + r.tgTangCa_Dem_Cu + r.tgTangCa_cn_Cu + r.tgTangCa_lt_Cu;

                        r.tongTgTangCa_bt_Total = r.tgTangCa_bt_Moi + r.tgTangCa_bt_Cu;
                        r.tongTgTangCa_Dem_Total = r.tgTangCa_Dem_Moi + r.tgTangCa_Dem_Cu;
                        r.tongTgTangCa_lt_Total = r.tgTangCa_lt_Moi + r.tgTangCa_lt_Cu;
                        r.tongTgTangCa_cn_Total = r.tgTangCa_cn_Moi + r.tgTangCa_cn_Cu;

                        r.tongTgTangCa_cn_gio = r.tongNgayCong_cn_Total * 8 + r.tongTgTangCa_cn_Total;
                        r.tongTgTangCa_Total = r.tongTgTangCa_Moi + r.tongTgTangCa_Cu + r.tongTgTangCa_cn_gio;
                        //-------------Lương tăng ca--------------
                        // Chủ nhật thì tính vào tăng ca: tiền làm chủ nhật = tiền Ngày công * 8 + tiền tăng ca
                        r.tongTienNC_cn_Total = r.tienNC_cn_Moi + r.tienNC_cn_Cu;
                        r.tongTienTangCa_cn_Total = r.tienTangCa_cn_Moi + r.tienTangCa_cn_Cu;


                        r.tongTienTangCa_Moi = r.tienTangCa_bt_Moi + r.tienTangCa_Dem_Moi + r.tienNC_cn_Moi + r.tienTangCa_cn_Moi + r.tienTangCa_lt_Moi;
                        r.tongTienTangCa_Cu = r.tienTangCa_bt_Cu + r.tienTangCa_Dem_Cu + r.tienNC_cn_Cu + r.tienTangCa_cn_Cu + r.tienTangCa_lt_Cu;

                        r.tongTienTangCa_bt_Total = r.tienTangCa_bt_Moi + r.tienTangCa_bt_Cu;
                        r.tongTienTangCa_Dem_Total = r.tienTangCa_Dem_Moi + r.tienTangCa_Dem_Cu;
                        r.tongTienTangCa_lt_Total = r.tienTangCa_lt_Moi + r.tienTangCa_lt_Cu;

                        r.tongTienTangCa_Total = r.tongTienTangCa_Moi + r.tongTienTangCa_Cu;
                        #endregion

                        #region tinh thưởng, phụ cấp

                        r.tongPhuCapKhac = 0;
                        r.khoanTruKhac = 0;
                        r.tongThuongCalc = 0;
                        var pcK = ds.tbThamSoTinhLuong.Where(i => i.employeeID == r.empoyeeID &&
                            (i["thang"] == DBNull.Value || i.thang == new DateTime(tuNgay.Year, tuNgay.Month, 1))
                        ).FirstOrDefault();

                        for (int i = 1; i < 21; i++)
                        {
                            r["PC" + i] = DbHelper.DrGetDouble(pcK, "PC" + i);
                            if ((double)r["PC" + i] > 0 || i == 3)
                            {
                                if (i == 3) //PC3: Khoản thưởng khác. + Thêm phụ cấp hàng tháng.
                                {
                                    var a = ds.tblEmpAllowanceFix.Where(p => p.EmployeeID == eID).Sum(p => p.Amount);
                                    r["PC3"] = Convert.ToDouble(r["PC3"]) + a;
                                }
                                r.tongPhuCapKhac += (double)r["PC" + i];
                            }
                            else
                                r.khoanTruKhac += (-1.0) * (double)r["PC" + i];
                        }

                        double ngaycong_rounded = (chkLamTron ? i_Round(r.ngayCong_bt_Moi + r.ngayCong_bt_Cu + r.ngayCong_Dem_Moi + r.ngayCong_Dem_Cu) : (r.ngayCong_bt_Moi + r.ngayCong_bt_Cu + r.ngayCong_Dem_Moi + r.ngayCong_Dem_Cu)) + (r.ngayCong_lt_Moi + r.ngayCong_lt_Cu);
                        // Cũ
                        var abc = ds.tbDangKyVangMat.Where(i => i.EmployeeID == e1.EmployeeID && i.lydo == (int)Enums.eLyDoNghi.NghiPhepNam);
                        double soNgayNghiPhepNam = abc
                            .Sum(p => (p.nghiCaNgay == 3 ? 1 : 0.5));
                        //fix ngày nghỉ ko ảnh hưởng tới chuyên cần
                        ngaycong_rounded += ds.tbDangKyVangMat.Where(i => i.EmployeeID == e1.EmployeeID && !i.coTinhChuyenCan && i.lydo != (int)Enums.eLyDoNghi.NghiPhepNam).Sum(p => (p.nghiCaNgay == 3 ? 1 : 0.5));

                        double soNgayNghiCheDo = ds.tbDangKyVangMat.Where(i => i.EmployeeID == e1.EmployeeID && (i.lydo == (int)Enums.eLyDoNghi.KetHon || i.lydo == (int)Enums.eLyDoNghi.MaChay) && i.coTinhChuyenCan)
                            .Sum(p => (p.nghiCaNgay == 3 ? 1 : 0.5));
                        hp._soNgayCongTrongThang = soNgayCongThucTeTrongThang;
                        foreach (var dr in ds.tbBangLuongCalc)
                        {
                            if (!string.IsNullOrWhiteSpace(dr.expression))
                            {
                                NCalc.Expression exp = new NCalc.Expression(dr.expression);
                                exp.Parameters.Add("thang", r.thang);
                                exp.Parameters.Add("empoyeeID", r.empoyeeID);
                                exp.Parameters.Add("luongCB", r.luongCB_Moi);
                                exp.Parameters.Add("luongPC", r.luongPC_Moi);
                                exp.Parameters.Add("luongCB_cu", r.luongCB_Cu);
                                exp.Parameters.Add("luongPC_cu", r.luongPC_Cu);
                                exp.Parameters.Add("soNgayCongTrongThang", hp._soNgayCongTrongThang);
                                exp.Parameters.Add("soNgayNghiPhepNam", soNgayNghiPhepNam);
                                exp.Parameters.Add("ngaycong_rounded", ngaycong_rounded);
                                exp.Parameters.Add("soNgayNghiCheDo", soNgayNghiCheDo);
                                //for (int i = 1; i < 21; i++)
                                //    exp.Parameters.Add("PC" + i, r["PC" + i]);
                                for (int i = 1; i < 11; i++)
                                    exp.Parameters.Add("DataCalc" + i, DbHelper.DrGetDouble(pcK, "DataCalc" + i));

                                if (!exp.HasErrors())
                                {
                                    if (r.Table.Columns.Contains(dr.fieldName))
                                        r[dr.fieldName] = exp.Evaluate();
                                    else
                                        lp.OutMessage("EmpID " + eID + " ERR: Công thức tính lương: định nghĩa sai tên trường " + dr.fieldName);
                                }
                                r.tongThuongCalc += Convert.ToDouble(r[dr.fieldName]);
                            }
                        }
                        hp._soNgayCongTrongThang = soNgayCongThucTeTrongThang > 26 ? 26 : soNgayCongThucTeTrongThang;
                        // Tiền con thơ.
                        r.ConTho = ds.tblEmpChild.Where(p => p.EmployeeID == eID).Count() * 50000;

                        //Khoản thưởng giới thiệu.
                        double soTienGioiThieu = ds.tbGioiThieuCongNhan.Where(p => p.EmployeeID == eID && p.Date != null && p.Date >= tuNgay && p.Date <= denNgay).Sum(p => p.Sotien);
                        r["PC4"] = (double)r["PC4"] + soTienGioiThieu;

                        double Phucap = 0;
                        if (r.ngayCong_bt_Moi + r.ngayCong_lt_Moi + r.ngayCong_Dem_Moi > 13)
                        {
                            Phucap = r.luongPC_Moi;
                        }
                        else
                        {
                            var phucapMoi = r.luongPC_Moi / hp._soNgayCongTrongThang * (r.ngayCong_bt_Moi + r.ngayCong_lt_Moi + r.ngayCong_Dem_Moi + r.ngayCong_phepNam_Moi);
                            var phucapCu = r.luongPC_Cu / hp._soNgayCongTrongThang * (r.ngayCong_bt_Cu + r.ngayCong_lt_Cu + r.ngayCong_Dem_Cu + r.ngayCong_phepNam_Cu);
                            Phucap = phucapCu + phucapMoi;
                        }
                        r.PhuCapTrachNhiem = Phucap;
                        #endregion

                        //PCS + AL + Paid leave + Public holiday
                        #region tinh luong SP
                        if (pcK != null && pcK.LuongSP > 0)
                        {
                            r.luongSP = pcK.LuongSP;
                        }
                        #endregion
                        r.luongThoiGian = r.tongTienNgayCong_Total + r.tongTienTangCa_Total;
                        r.tongLuongTG = r.luongThoiGian;
                        r.tongLuongSP = r.luongSP;
                        r.tongPhuCapKhac += r.tongThuongCalc + r.ConTho;
                        // Calc1: chuyên cần
                        if (r.luongSP <= 0)
                        {
                            r.isLuongSP = false;
                            r.tongLuong = r.luongThoiGian;
                            r.tongLuong += r.tongLuong > 0 ? (r.tongPhuCapKhac + r.PhuCapTrachNhiem) : 0; //có lương mới đc + phụ cấp
                        }
                        else
                        {
                            r.isLuongSP = true;
                            r.tongLuong = r.tongTienNC_lt_Total + r.tongTienNC_phepNam_Total + r.tongTienNC_phep_Total;
                            r.tongLuong += r.luongSP + r.luongPC_Moi + r.ConTho + Convert.ToDouble(r["Calc1"]) + Convert.ToDouble(r["Calc2"]) + Convert.ToDouble(r["PC3"]) + Convert.ToDouble(r["PC4"]);
                        }
                        #region khau tru
                        r.ThueTNCN = r.tienBHXH = r.tienBHYT = r.tienBHTN = 0;
                        r.phiCongDoan = 0;
                        r.tienBH105 = 0;
                        if (e1["coBH"] != DBNull.Value && e1.coBH)
                        {
                            if (e1["coBH_ngay"] != DBNull.Value && e1.coBH_ngay < denNgay)
                            {
                                r.tienBHXH = (r.luongCB_Moi + r.luongPC_Moi) * 8 / 100;
                                r.tienBHYT = (r.luongCB_Moi + r.luongPC_Moi) * 1.5 / 100;
                                r.tienBHTN = (r.luongCB_Moi + r.luongPC_Moi) * 1 / 100;
                                r.tienBH105 = r.tienBHXH + r.tienBHYT + r.tienBHTN;
                                r.phiCongDoan = 0;
                            }
                        }
                        r.tongKhauTru = r.tienBHXH + r.tienBHYT + r.tienBHTN + r.khoanTruKhac + r.phiCongDoan;
                        #endregion
                        int soNguoiPhuThuoc = (int)Provider.ExecSqlScalar(string.Format("select isnull(SoNguoiPhuThuoc,0) from tblEmployee where employeeID ='{0}'", eID));
                        r.SoNguoiPhuThuoc = soNguoiPhuThuoc;
                        r.LuongThucNhanTinhThue = r.tongLuong - (r.tongLuong > 0 ? r.tongKhauTru : 0); //có lương mới trừ
                                                                                                       // Nếu thực nhận tính thuế < 9tr. Không phải tính.
                        if (r.LuongThucNhanTinhThue > 9000000)
                        {
                            r.ThueTNCN = TinhThueTNCN(r.LuongThucNhanTinhThue, r.SoNguoiPhuThuoc);
                        }

                        r.tongKhauTru += r.ThueTNCN;
                        r.actualBankTransfer = r.tongLuong - (r.tongLuong > 0 ? r.tongKhauTru : 0);//có lương mới trừ

                        r.analyzeDate = DateTime.Now;
                        r.analyzeBy = UserDoing.id;
                        r.statePushServer = "edit";
                        ds.tbBangLuongThang_1dong.Rows.Add(r);
                    }
                    catch (Exception ex)
                    {
                        lp.OutMessage("EmpID " + eID + " ERR: " + ex.Message);
                    }
                    lp.CurrentValue += 1;
                }

                if (ds.tbBangLuongThang_1dong.GetChanges() == null)
                {
                    lp.OutMessage("\n>> " + Lng.Luong_AnalyzeData.emptmsg);
                }
                else
                {
                    var rowChanged = ds.tbBangLuongThang_1dong.GetChanges().Rows.Count;
                    lp.OutMessage("\n>> Commit data to database...");
                    SqlParameter pa = new SqlParameter("dtBangLuongThang_1dong", SqlDbType.Structured);
                    pa.TypeName = "dtBangLuongThang_1dong";
                    pa.Value = ds.tbBangLuongThang_1dong;
                    Provider.ExecuteNonQuery("p_tinhLuong_updateBangLuongThang_1dong", pa);
                    //Provider.UpdateData(ds, ds.tbBangLuongThang.TableName);
                    lp.OutMessage("\n>> " + Lng.Luong_AnalyzeData.msg_1 + "(" + rowChanged + ") bản ghi");
                }
                lp.OutMessage(Lng.Luong_AnalyzeData.msg_2);
            }
            catch (Exception ex)
            {
                lp.OutMessage(ex.Message);
            }
        }
        private double i_Round(double v)
        {
            double d = v - (int)v;
            return (int)v + (d < 0.75 ? (d >= 0.25 ? 0.5 : 0) : 1);
        }

        private double TinhNgayCongPhep(dsTinhLuong.tbDangKyVangMatRow i)
        {
            double h = 0;
            if (i.denGio < i.tuGio)
            {
                h = (i.denGio.Add(new TimeSpan(24, 0, 0)) - i.tuGio).TotalHours;
            }
            else
                h = (i.denGio - i.tuGio).TotalHours;
            if (h > i.soTiengTinhCa)
                return 1;
            return h / i.soTiengTinhCa;
        }
        private double TinhThueTNCN(double LuongThucNhanTinhThue, int soNguoiPhuThuoc)
        {
            double totalTNCN = 0;
            // Trừ đi giảm trừ gia cảnh: 3tr6 / 1 người.
            double thunhapTinhThue = LuongThucNhanTinhThue - 9000000 - (3600000 * soNguoiPhuThuoc);
            //Tính thuế theo cách 2.
            if (thunhapTinhThue <= 5000000) //<= 5tr
            {
                totalTNCN = thunhapTinhThue * 5 / 100;
            }
            else if (thunhapTinhThue <= 10000000) // <= 10tr
            {
                totalTNCN = thunhapTinhThue * 10 / 100 - 250000;
            }
            else if (thunhapTinhThue <= 18000000) // <= 18tr
            {
                totalTNCN = thunhapTinhThue * 15 / 100 - 750000;
            }
            else if (thunhapTinhThue <= 32000000) // <= 32tr
            {
                totalTNCN = thunhapTinhThue * 20 / 100 - 1650000;
            }
            else if (thunhapTinhThue <= 52000000) // <= 52tr
            {
                totalTNCN = thunhapTinhThue * 25 / 100 - 3250000;
            }
            else if (thunhapTinhThue <= 80000000) // <= 80tr
            {
                totalTNCN = thunhapTinhThue * 30 / 100 - 5850000;
            }
            else
            {
                totalTNCN = thunhapTinhThue * 35 / 100 - 9850000;
            }
            return totalTNCN > 0 ? totalTNCN : 0;
        }
    }
}
