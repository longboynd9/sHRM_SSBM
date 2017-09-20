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
    public class XuLyDuLieu : LogicBase
    {
        TinhLuong logic = new TinhLuong();
        dsTinhLuong ds = new dsTinhLuong();
        public LogicProgress lp = new LogicProgress();

        public w5sysUser UserDoing;
        public XuLyDuLieu(w5sysUser uLogged)
        {
            UserDoing = uLogged;
        }



        public void doAnalyza(DateTime tuNgay, DateTime denNgay, string empID, string depID, int group1ID, bool chkLamTron)
        {
            TinhLuong logic = new TinhLuong();
            dsTinhLuong ds = new dsTinhLuong();
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

                Provider.LoadDataByProc(ds, ds.tblEmpSalary.TableName, "p_tinhLuong_GetLuongCoBan", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay));
                lp.OutMessage("Lương cơ bản: " + ds.tblEmpSalary.Rows.Count);
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

                    lp.OutMessage(">>> " + Lng.Luong_AnalyzeData.resetBL + " (" + empID + ") " + logic.ResetBangLuong_withEmp(cMonth, empID));
                }
                else if (!string.IsNullOrWhiteSpace(depID))
                {
                    Provider.LoadDataByProc(ds, ds.tbThamSoTinhLuong.TableName, "p_tinhLuong_GetThamSoTinhLuong_WithDept", new SqlParameter("thang", cMonth), new SqlParameter("maTapThe", depID));
                    Provider.LoadDataByProc(ds, ds.p_tinhLuong_GetAllKetQuaQuetThe.TableName, "p_tinhLuong_GetAllKetQuaQuetThe_WithDept", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay), new SqlParameter("maTapThe", depID));
                    Provider.LoadDataByProc(ds, ds.tblEmpAllowanceFix.TableName, "p_tinhLuong_GetPCCD_WithDept", new SqlParameter("maTapThe", depID));

                    lp.OutMessage(">>> " + Lng.Luong_AnalyzeData.resetBL + " (" + depID + ") " + logic.ResetBangLuong_withDep(cMonth, depID));
                }
                else if (group1ID > 0)
                {
                    Provider.LoadDataByProc(ds, ds.tbThamSoTinhLuong.TableName, "p_tinhLuong_GetThamSoTinhLuong_WithGroup1", new SqlParameter("thang", cMonth), new SqlParameter("group1ID", group1ID));
                    Provider.LoadDataByProc(ds, ds.p_tinhLuong_GetAllKetQuaQuetThe.TableName, "p_tinhLuong_GetAllKetQuaQuetThe_WithGroup1", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay), new SqlParameter("group1ID", group1ID));
                    Provider.LoadDataByProc(ds, ds.tblEmpAllowanceFix.TableName, "p_tinhLuong_GetPCCD_WithGroup1", new SqlParameter("group1ID", group1ID));

                    lp.OutMessage(">>> " + Lng.Luong_AnalyzeData.resetBL + " (Group1: " + group1ID + ") " + logic.ResetBangLuong_withGroup1(cMonth, group1ID));
                }
                else
                {
                    Provider.LoadDataByProc(ds, ds.tbThamSoTinhLuong.TableName, "p_tinhLuong_GetThamSoTinhLuong", new SqlParameter("thang", cMonth));
                    Provider.LoadDataByProc(ds, ds.p_tinhLuong_GetAllKetQuaQuetThe.TableName, "p_tinhLuong_GetAllKetQuaQuetThe", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay));
                    Provider.LoadDataByProc(ds, ds.tblEmpAllowanceFix.TableName, "p_tinhLuong_GetPCCD");

                    lp.OutMessage(Lng.Luong_AnalyzeData.resetBL + logic.ResetBangLuong(cMonth));
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

                        var r = ds.tbBangLuongThang.NewtbBangLuongThangRow(); r.laBangLuongCu = false; r.id = Guid.NewGuid();
                        var r2 = ds.tbBangLuongThang.NewtbBangLuongThangRow(); r2.laBangLuongCu = true; r2.id = Guid.NewGuid();
                        var e1 = kqs[0];
                        #region tính lương

                        TinhLuongHelper hp = new TinhLuongHelper(ds, tuNgay, denNgay, e1.EmployeeID);
                        r.thang = r2.thang = cMonth;
                        r.empoyeeID = r2.empoyeeID = eID;

                        if (hp.luongMoi == null && hp.luongCu == null)
                        {
                            hp.luongMoi = ds.tblEmpSalary.Where(i => i.EmployeeID == e1.EmployeeID).OrderByDescending(i => i.DateChange).FirstOrDefault();
                        }
                        r.luongCB = hp.luongMoi == null ? (e1["BasicSalary"] == DBNull.Value ? 0 : e1.BasicSalary) : hp.luongMoi.BasicSalary;
                        r.luongPC = hp.luongMoi == null ? (e1["RegularAllowance"] == DBNull.Value ? 0 : e1.RegularAllowance) : hp.luongMoi.BasicSalary_Ins;

                        r2.luongCB = (hp.luongCu == null) ? 0 : hp.luongCu.BasicSalary;
                        r2.luongPC = (hp.luongCu == null) ? 0 : hp.luongCu.BasicSalary_Ins;


                        r.ngaycong_bt = r.tienNC_bt = r.ngaycong_phep = r.tienNC_phep = r.ngaycong_phepNam = r.tienNC_phepNam = r.ngaycong_lt = r.tienNC_lt = r.ngaycong_cn = r.tienNC_cn = r.tongNgayCong = r.tienNgayCong = 0;
                        r.tgTangCa_bt = r.tienTangCa_bt = r.tgTangCa_cn = r.tienTangCa_cn = r.tgTangCa_lt = r.tienTangCa_lt = r.tongThoiGianTangCa = r.tienTangCa = 0;

                        r2.ngaycong_bt = r2.tienNC_bt = r2.ngaycong_phep = r2.tienNC_phep = r2.ngaycong_phepNam = r2.tienNC_phepNam = r2.ngaycong_lt = r2.tienNC_lt = r2.ngaycong_cn = r2.tienNC_cn = r2.tongNgayCong = r2.tienNgayCong = 0;
                        r2.tgTangCa_bt = r2.tienTangCa_bt = r2.tgTangCa_cn = r2.tienTangCa_cn = r2.tgTangCa_lt = r2.tienTangCa_lt = r2.tongThoiGianTangCa = r2.tienTangCa = 0;

                        r.tongLuongTG = r2.tongLuongTG = 0;
                        r.tongTgTangCa_cn_gio = r2.tongTgTangCa_cn_gio = 0;
                        r.luongSP = r.luongTangCaSP = r.luongSP_tong = 0;


                        for (int i = 1; i < 21; i++)
                        {
                            r["Calc" + i] = 0;
                            r2["Calc" + i] = 0;
                            r["PC" + i] = 0;
                            r2["PC" + i] = 0;
                        }

                        double f;
                        foreach (var kq in kqs)
                        {
                            hp.Set_KQQT(kq);

                            #region tinh ngay cong theo luong moi
                            r.ngaycong_bt += hp.TinhNgayCong(1);
                            r.tienNC_bt += hp.TinhTienNgayCong(1);

                            r.ngaycong_phep += hp.TinhNgayCong(2);
                            r.tienNC_phep += hp.TinhTienNgayCong(2);

                            f = hp.TinhNgayCong(5);
                            r.ngaycong_phepNam += f;
                            r.tienNC_phepNam += hp.TinhTienNgayCong(5);

                            r.ngaycong_lt += hp.TinhNgayCong(3);
                            r.tienNC_lt += hp.TinhTienNgayCong(3);

                            f = hp.TinhNgayCong(4);
                            r.ngaycong_cn += f;
                            r.tongTgTangCa_cn_gio += f * kq.soTiengTinhCa;
                            r.tienNC_cn += hp.TinhTienNgayCong(4);
                            #endregion

                            #region tinh tang ca theo luong moi
                            var f1 = hp.TinhTienTangCa(1);
                            r.tgTangCa_bt += hp.TinhGioTangCa(1);
                            r.tienTangCa_bt += hp.TinhTienTangCa(1);

                            f = hp.TinhGioTangCa(2);
                            r.tgTangCa_cn += f;
                            r.tongTgTangCa_cn_gio += f;
                            r.tienTangCa_cn += hp.TinhTienTangCa(2);

                            r.tgTangCa_lt += hp.TinhGioTangCa(3);
                            r.tienTangCa_lt += hp.TinhTienTangCa(3);
                            #endregion


                            if (hp.luongCu != null)
                            {
                                #region tinh ngay cong theo luong cu
                                r2.ngaycong_bt += hp.TinhNgayCong(1, true);
                                r2.tienNC_bt += hp.TinhTienNgayCong(1, true);

                                r2.ngaycong_phep += hp.TinhNgayCong(2, true);
                                r2.tienNC_phep += hp.TinhTienNgayCong(2, true);

                                r2.ngaycong_phepNam += hp.TinhNgayCong(5, true);
                                r2.tienNC_phepNam += hp.TinhTienNgayCong(5, true);

                                r2.ngaycong_lt += hp.TinhNgayCong(3, true);
                                r2.tienNC_lt += hp.TinhTienNgayCong(3, true);

                                f = hp.TinhNgayCong(4, true);
                                r2.ngaycong_cn += f;
                                r2.tienNC_cn += hp.TinhTienNgayCong(4, true);
                                r2.tongTgTangCa_cn_gio += f * kq.soTiengTinhCa;

                                #endregion

                                #region tinh tang ca theo luong cu
                                r2.tgTangCa_bt += hp.TinhGioTangCa(1, true);
                                r2.tienTangCa_bt += hp.TinhTienTangCa(1, true);

                                f = hp.TinhGioTangCa(2, true);
                                r2.tgTangCa_cn += f;
                                r2.tongTgTangCa_cn_gio += f;
                                r2.tienTangCa_cn += hp.TinhTienTangCa(2, true);

                                r2.tgTangCa_lt += hp.TinhGioTangCa(3, true);
                                r2.tienTangCa_lt += hp.TinhTienTangCa(3, true);

                                #endregion

                            }
                        }
                        #endregion

                        #region rounded money
                        r.tienNC_bt = Math.Round(r.tienNC_bt, 0);
                        r.tienNC_phep = Math.Round(r.tienNC_phep, 0);
                        r.tienNC_phepNam = Math.Round(r.tienNC_phepNam, 0);
                        r.tienNC_lt = Math.Round(r.tienNC_lt, 0);
                        r.tienNC_cn = Math.Round(r.tienNC_cn, 0);
                        r.tienNgayCong = Math.Round(r.tienNgayCong, 0);

                        r.tienTangCa_bt = Math.Round(r.tienTangCa_bt, 0);
                        r.tienTangCa_cn = Math.Round(r.tienTangCa_cn, 0);
                        r.tienTangCa_lt = Math.Round(r.tienTangCa_lt, 0);
                        r.tienTangCa = Math.Round(r.tienTangCa, 0);



                        r2.tienNC_bt = Math.Round(r2.tienNC_bt, 0);
                        r2.tienNC_phep = Math.Round(r2.tienNC_phep, 0);
                        r2.tienNC_phepNam = Math.Round(r2.tienNC_phepNam, 0);
                        r2.tienNC_lt = Math.Round(r2.tienNC_lt, 0);
                        r2.tienNC_cn = Math.Round(r2.tienNC_cn, 0);
                        r2.tienNgayCong = Math.Round(r2.tienNgayCong, 0);

                        r2.tienTangCa_bt = Math.Round(r2.tienTangCa_bt, 0);
                        r2.tienTangCa_cn = Math.Round(r2.tienTangCa_cn, 0);
                        r2.tienTangCa_lt = Math.Round(r2.tienTangCa_lt, 0);
                        r2.tienTangCa = Math.Round(r2.tienTangCa);
                        #endregion

                        #region tinh tong

                        r.tongNgayCong = r.ngaycong_bt + r.ngaycong_phep + r.ngaycong_phepNam + r.ngaycong_lt;
                        r.tienNgayCong = r.tienNC_bt + r.tienNC_phep + r.tienNC_phepNam + r.tienNC_lt;
                        r.tongThoiGianTangCa = r.tgTangCa_bt + r.tgTangCa_lt + r.tongTgTangCa_cn_gio;
                        r.tienTangCa = r.tienTangCa_bt + r.tienTangCa_lt + r.tienTangCa_cn + r.tienNC_cn;

                        r2.tongNgayCong = r2.ngaycong_bt + r2.ngaycong_phep + r2.ngaycong_phepNam + r2.ngaycong_lt;
                        r2.tienNgayCong = r2.tienNC_bt + r2.tienNC_phep + r2.tienNC_phepNam + r2.tienNC_lt;
                        r2.tongThoiGianTangCa = r2.tgTangCa_bt + r2.tgTangCa_lt + r2.tongTgTangCa_cn_gio;
                        r2.tienTangCa = r2.tienTangCa_bt + r2.tienTangCa_lt + r2.tienTangCa_cn + r2.tienNC_cn;

                        #endregion

                        #region tinh thưởng, phụ cấp

                        r.tongPhuCapKhac = r2.tongPhuCapKhac = 0;
                        r.khoanTruKhac = r2.khoanTruKhac = 0;
                        r.tongThuongCalc = r2.tongThuongCalc = 0;
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

                        double ngaycong_rounded = (chkLamTron ? i_Round(r.ngaycong_bt + r2.ngaycong_bt) : r.ngaycong_bt + r2.ngaycong_bt) + (r.ngaycong_lt + r2.ngaycong_lt);
                        // Cũ
                        //double soNgayNghiPhepNam = ds.tbDangKyVangMat.Where(i => i.EmployeeID == e1.EmployeeID && i.lydo == (int)Enums.eLyDoNghi.NghiPhepNam && i.coTinhChuyenCan)
                        //    .Sum(i => TinhNgayCongPhep(i));
                        double soNgayNghiPhepNam = ds.tbDangKyVangMat.Where(i => i.EmployeeID == e1.EmployeeID && i.lydo == (int)Enums.eLyDoNghi.NghiPhepNam)
                                                    .Sum(i => TinhNgayCongPhep(i));
                        //fix ngày nghỉ ko ảnh hưởng tới chuyên cần
                        ngaycong_rounded += ds.tbDangKyVangMat.Where(i => i.EmployeeID == e1.EmployeeID && !i.coTinhChuyenCan).Sum(i => TinhNgayCongPhep(i));

                        double soNgayNghiCheDo = ds.tbDangKyVangMat.Where(i => i.EmployeeID == e1.EmployeeID && (i.lydo == (int)Enums.eLyDoNghi.KetHon || i.lydo == (int)Enums.eLyDoNghi.MaChay) && i.coTinhChuyenCan)
                            .Sum(i => TinhNgayCongPhep(i));

                        foreach (var dr in ds.tbBangLuongCalc)
                        {
                            if (!string.IsNullOrWhiteSpace(dr.expression))
                            {
                                NCalc.Expression exp = new NCalc.Expression(dr.expression);
                                exp.Parameters.Add("thang", r.thang);
                                exp.Parameters.Add("empoyeeID", r.empoyeeID);
                                exp.Parameters.Add("luongCB", r.luongCB);
                                exp.Parameters.Add("luongPC", r.luongPC);
                                exp.Parameters.Add("luongCB_cu", r2.luongCB);
                                exp.Parameters.Add("luongPC_cu", r2.luongPC);
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

                        #endregion

                        #region tinh luong SP
                        r2.luongSP = r2.luongTangCaSP = r2.luongSP_tong = 0;
                        if (pcK == null || pcK.LuongSP == 0)
                        {
                            r.luongSP = r.luongTangCaSP = r.luongSP_tong = 0;
                        }
                        else
                        {
                            r.luongSP = pcK.LuongSP;
                        }
                        #endregion
                        r.luongThoiGian = r.tienNgayCong + r.tienTangCa + (r2.tienNgayCong + r2.tienTangCa);
                        // PC2: Tiền con thơ
                        r.ConTho = (ds.tblEmpChild.Where(p => p.EmployeeID == eID).Count() >= 1 ? 1 : 0) * 50000;
                        r.tongPhuCapKhac += r.tongThuongCalc + r.ConTho;
                        r.tongLuongTG = r.luongThoiGian;
                        if (r.luongSP <= 0 || r.luongSP == null)
                        {
                            r.isLuongSP = false;
                            r.tongLuong = r.luongThoiGian;
                            r.tongLuong += r.tongLuong > 0 ? r.tongPhuCapKhac : 0; //có lương mới đc + phụ cấp
                        }
                        else
                        {
                            r.isLuongSP = true;
                            r.tongLuong = r.luongSP + r.ConTho + Convert.ToDouble(r["Calc1"]) + Convert.ToDouble(r["Calc2"]) + Convert.ToDouble(r["PC3"]) + Convert.ToDouble(r["PC4"]);
                        }
                        r2.tongLuongTG = 0;
                        r2.luongThoiGian = 0;
                        r2.tongLuong = 0;

                        #region khau tru
                        r.BH105 = 0;
                        r.phiCongDoan = 0;
                        r2.BH105 = 0;
                        if (e1["coBH"] != DBNull.Value && e1.coBH)
                        {
                            if (e1["coBH_ngay"] != DBNull.Value && e1.coBH_ngay < denNgay)
                            {
                                r.BH105 = r.luongCB * 10.5 / 100;
                                r.phiCongDoan = r.luongCB / 100;
                            }
                        }
                        r.tongKhauTru = r.BH105 + r.khoanTruKhac + r.phiCongDoan;
                        r2.tongKhauTru = 0;
                        #endregion

                        r.actualBankTransfer = r.tongLuong - (r.tongLuong > 0 ? r.tongKhauTru : 0); //có lương mới trừ
                        r2.actualBankTransfer = 0;

                        r.analyzeDate = r2.analyzeDate = DateTime.Now;
                        r.analyzeBy = r2.analyzeBy = UserDoing.id;

                        ds.tbBangLuongThang.Rows.Add(r);
                        if (hp.luongCu != null)
                            ds.tbBangLuongThang.Rows.Add(r2);
                    }
                    catch (Exception ex)
                    {
                        lp.OutMessage("EmpID " + eID + " ERR: " + ex.Message);
                    }
                    lp.CurrentValue += 1;
                }

                if (ds.tbBangLuongThang.GetChanges() == null)
                {
                    lp.OutMessage("\n>> " + Lng.Luong_AnalyzeData.emptmsg);
                }
                else
                {
                    var rowChanged = ds.tbBangLuongThang.GetChanges().Rows.Count;
                    lp.OutMessage("\n>> Commit data to database...");
                    SqlParameter pa = new SqlParameter("dtBangLuongThang", SqlDbType.Structured);
                    pa.TypeName = "dtBangLuongThang";
                    pa.Value = ds.tbBangLuongThang;
                    Provider.ExecuteNonQuery("p_tinhLuong_updateBangLuongThang", pa);
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
            double h = (i.denGio - i.tuGio).TotalHours;
            if (h > i.soTiengTinhCa)
                return 1;
            return h / i.soTiengTinhCa;
        }
    }
}
