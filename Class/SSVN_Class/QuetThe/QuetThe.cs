using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic.ChamCong;
using iHRM.Core.Controller;

namespace iHRM.Win.ExtClass.QuetThe
{
    public class XuLyDuLieu : LogicBase
    {
        analyze logic = new analyze();
        dsXuLyQuetThe ds = new dsXuLyQuetThe();
        public LogicProgress lp = new LogicProgress();

        public w5sysUser UserDoing;
        public XuLyDuLieu(w5sysUser uLogged)
        {
            UserDoing = uLogged;
        }
        public void doAnalyza(DateTime tuNgay, DateTime denNgay, string empID, string depID, int nhom1ID, bool overideModified)
        {
            try
            {
                var db = new dcDatabaseDataContext(Provider.ConnectionString);

                //reg progress...
                lp.SetTitle("Đang lấy dữ liệu..");
                lp.OutMessage("Lấy dữ liệu ----------------------------------------------------------------------------------");

                #region get data
                //ds.EnforceConstraints = false;
                Provider.LoadData(ds, ds.tbCaLamViec.TableName);
                lp.OutMessage("Ca làm việc: " + ds.tbCaLamViec.Rows.Count);
                Provider.LoadData(ds, ds.tbNgayNghiPhepNam.TableName);
                lp.OutMessage("Ngày nghỉ phép năm: " + ds.tbNgayNghiPhepNam.Rows.Count);
                Provider.LoadDataByProc(ds, ds.tbDangKyVangMat.TableName, "p_duLieuQuetThe_GetAllDangKyVangMat_CoThe", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay));
                lp.OutMessage("Đăng ký vắng mặt: " + ds.tbNgayNghiPhepNam.Rows.Count);

                if (!string.IsNullOrWhiteSpace(empID))
                {
                    Provider.ExecNoneQuery("p_duLieuQuetThe_ResetAndCheck_withEmp", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay), new SqlParameter("empID", empID));
                    Provider.LoadDataByProc(ds, ds.tbKetQuaQuetThe.TableName, "p_duLieuQuetThe_GetAllKetQuaQuetThe_CoThe_withEmp", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay), new SqlParameter("empID", empID));
                    Provider.LoadDataByProc(ds, ds.tbDuLieuQuetThe.TableName, "p_duLieuQuetThe_GetAllDuLieuQuetThe_withEmp", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay.AddDays(1)), new SqlParameter("empID", empID));
                }
                else if (!string.IsNullOrWhiteSpace(depID))
                {
                    Provider.ExecNoneQuery("p_duLieuQuetThe_ResetAndCheck_withDept", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay), new SqlParameter("maTapThe", depID));
                    Provider.LoadDataByProc(ds, ds.tbKetQuaQuetThe.TableName, "p_duLieuQuetThe_GetAllKetQuaQuetThe_CoThe_withDept", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay), new SqlParameter("maTapThe", depID));
                    Provider.LoadDataByProc(ds, ds.tbDuLieuQuetThe.TableName, "p_duLieuQuetThe_GetAllDuLieuQuetThe_withDept", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay.AddDays(1)), new SqlParameter("maTapThe", depID));
                }
                else if (nhom1ID > 0)
                {
                    Provider.ExecNoneQuery("p_duLieuQuetThe_ResetAndCheck_withGroup1", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay), new SqlParameter("maNhom1", nhom1ID));
                    Provider.LoadDataByProc(ds, ds.tbKetQuaQuetThe.TableName, "p_duLieuQuetThe_GetAllKetQuaQuetThe_CoThe_withGroup1", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay), new SqlParameter("maNhom1", nhom1ID));
                    Provider.LoadDataByProc(ds, ds.tbDuLieuQuetThe.TableName, "p_duLieuQuetThe_GetAllDuLieuQuetThe_withGroup1", new SqlParameter("tuNgay", tuNgay.AddDays(1)), new SqlParameter("denNgay", denNgay), new SqlParameter("maNhom1", nhom1ID));
                }
                else
                {
                    Provider.ExecNoneQuery("p_duLieuQuetThe_ResetAndCheck_coThe", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay));
                    Provider.LoadDataByProc(ds, ds.tbKetQuaQuetThe.TableName, "p_duLieuQuetThe_GetAllKetQuaQuetThe_CoThe", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay));
                    Provider.LoadDataByProc(ds, ds.tbDuLieuQuetThe.TableName, "p_duLieuQuetThe_GetAllDuLieuQuetThe", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay.AddDays(1)));
                }

                lp.OutMessage(Lng.QuetThe_AnalyzeData.msg_kqqt + ds.tbKetQuaQuetThe.Count);
                lp.OutMessage("Dữ liệu quẹt thẻ: " + ds.tbDuLieuQuetThe.Count);

                #endregion

                //tính theo dòng kết quả quẹt thẻ
                Provider.ExecNoneQuery("p_chamcong_setLeftDateForKetQuaQuetThe", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay));
                string s = "";
                lp.MaxValue = ds.tbKetQuaQuetThe.Rows.Count;
                lp.CurrentValue = 0;
                foreach (dsXuLyQuetThe.tbKetQuaQuetTheRow dr in ds.tbKetQuaQuetThe.Rows)
                {
                    s = CheckQT(dr, overideModified);
                    if (s != "")
                        lp.OutMessage("\n>> " + s);
                    lp.CurrentValue += 1;
                }

                if (ds.tbKetQuaQuetThe.GetChanges() == null)
                {
                    lp.OutMessage("\n>> " + Lng.QuetThe_AnalyzeData.msg_1);
                }
                else
                {
                    var rowChanged = ds.tbKetQuaQuetThe.GetChanges().Rows.Count;
                    lp.OutMessage("\n>> Commit data to database...");
                    Provider.UpdateData(ds, ds.tbKetQuaQuetThe.TableName);
                    lp.OutMessage("\n>> " + Lng.QuetThe_AnalyzeData.msg_2 + rowChanged + ") " + Lng.QuetThe_AnalyzeData.msg_3);
                }

                #region save log xử lý dữ liệu
                tbl_logXuLyDuLieu save_log = new tbl_logXuLyDuLieu();
                save_log.id = Guid.NewGuid();
                save_log.ngaytu = tuNgay;
                save_log.ngayden = denNgay;
                save_log.isXuLyDLGoc = overideModified;
                save_log.ngayhientai = DateTime.Now;
                save_log.loginID = UserDoing.loginID;
                save_log.caption = UserDoing.caption;
                if (empID != "")
                {
                    save_log.employeeID = empID;
                }
                else if (depID.ToString() != "")
                {
                    save_log.idPhongBan = depID.ToString();
                    save_log.tenPhongBan = depID;
                }
                else if (nhom1ID > 0)
                {
                    save_log.idNhom = nhom1ID.ToString();
                    save_log.tenNhom = nhom1ID.ToString();
                }
                else
                {
                    save_log.idPhongBan = "All Company";
                    save_log.tenPhongBan = "Toàn bộ công ty";
                }

                db.tbl_logXuLyDuLieus.InsertOnSubmit(save_log);
                db.SubmitChanges();
                #endregion

                lp.OutMessage("\nXử lý hoàn thành!");
            }
            catch (Exception ex)
            {
                lp.OutMessage(ex.Message);
            }
        }

        public string CheckQT(dsXuLyQuetThe.tbKetQuaQuetTheRow kq, bool overideModified)
        {
            //set mặc định dayOfNghiCoLuong = 0.
            kq.daysOfNghiCoLuong = 0;
            try
            {
                kq.tt_leTet = 0;
                if (!kq.IsEmp_LeftDateNull())
                {

                    if (kq.ngay >= kq.Emp_LeftDate.Date)
                    {
                        return string.Format("Ngày {0:dd/MM/yyyy} nhân viên {1} đã nghỉ làm từ ngày {2:dd/MM/yyyy}", kq.ngay, kq.EmployeeID, kq.Emp_LeftDate);
                    }
                }

                var calam = ds.tbCaLamViec.SingleOrDefault(i => i.id == kq.idCaLam);
                if (calam == null)
                    return string.Format("Ngày {0:dd/MM/yyyy} nhân viên {1} chưa có dữ liệu ca làm", kq.ngay, kq.EmployeeID);
                var vm = ds.tbDangKyVangMat.FirstOrDefault(i => i.idKetQuaQuetThe == kq.id);

                kq.tgDiMuon = kq.tgVeSom = 0;
                kq.tgTinhTangCa = 0;

                kq.tt_chuNhat = kq.ngay.DayOfWeek == DayOfWeek.Sunday;

                TimeSpan calam_tuGio_4check = calam.tuGio, calam_denGio_4check = calam.tuGio.Add(calam.denGio);
                if (vm != null)
                {
                    if (vm.nghiCaNgay == 1) //nghỉ sáng
                    {
                        calam_tuGio_4check = calam.caChieu_tuGio;
                        if (vm.coHuongLuong == 1)
                        {
                            kq.daysOfNghiCoLuong = 0.5;
                        }
                    }
                    else if (vm.nghiCaNgay == 2) //nghỉ chiều
                    {
                        calam_denGio_4check = calam.caSang_denGio;
                        if (vm.coHuongLuong == 1)
                        {
                            kq.daysOfNghiCoLuong = 0.5;
                        }
                    }
                    else if (vm.nghiCaNgay == 3) //nghỉ cả ngày
                    {
                        if (vm.coHuongLuong == 1)
                        {
                            kq.daysOfNghiCoLuong = 1;
                        }
                    }
                }
                #region Nếu là ca đêm
                if (calam.caDem)
                {
                    #region check vào
                    DateTime tgQuetVao = kq.ngay.Add(calam.tuGio);
                    DateTime tgQuetTruoc_Vao = tgQuetVao.AddMinutes(-1 * calam.tgQuetTruoc_Vao);
                    DateTime tgQuetSau_Vao = tgQuetVao.AddMinutes(calam.tgQuetSau_Vao);

                    var dr = ds.tbDuLieuQuetThe
                        .Where(i => i.thoigian >= tgQuetTruoc_Vao && i.thoigian <= tgQuetSau_Vao && i.maNV == kq.EmployeeID)
                        .OrderBy(i => i.thoigian)
                        .FirstOrDefault();

                    if (dr == null && vm != null && vm.nghiCaNgay == 1) //nghỉ sáng => check h vào tư ca chiều
                    {
                        tgQuetVao = kq.ngay.Add(calam.caChieu_tuGio);
                        tgQuetTruoc_Vao = tgQuetVao.AddMinutes(-1 * calam.tgQuetTruoc_Vao);
                        tgQuetSau_Vao = tgQuetVao.AddMinutes(calam.tgQuetSau_Vao);

                        dr = ds.tbDuLieuQuetThe
                            .Where(i => i.thoigian >= tgQuetTruoc_Vao && i.thoigian <= tgQuetSau_Vao && i.maNV == kq.EmployeeID)
                            .OrderBy(i => i.thoigian)
                            .FirstOrDefault();
                    }

                    if (dr == null) //ko co quyet tay luc den trong khoang tg cho phep
                    {
                        kq["tgQuetDen_old"] = DBNull.Value;
                    }
                    else
                    {
                        kq.tgQuetDen_old = dr.thoigian.TimeOfDay;
                    }

                    if (overideModified || kq.IstgQuetDenNull() || kq.IsmodifyDateNull() || kq.IsmodifyByNull())
                        kq["tgQuetDen"] = kq["tgQuetDen_old"];

                    if (kq["tgQuetDen"] != DBNull.Value)
                    {
                        kq.tgDiMuon = (int)(kq.tgQuetDen - calam_tuGio_4check).TotalMinutes;
                        #region tính tg đi muộn dựa vào tgQuetDen
                        if (vm != null && vm.nghiCaNgay == 1) // Nếu nghỉ sáng 
                        {
                            if (calam.caChieu_tuGio > calam.tuGio) // Nếu caChieu_tuGio là tối (<24)
                            {
                                if (kq.tgQuetDen > calam.tuGio) // Nếu đến lúc tối
                                {
                                    kq.tgDiMuon = (int)(kq.tgQuetDen - calam.caChieu_tuGio).TotalMinutes;
                                }
                                else// Nếu đến lúc đêm
                                {
                                    kq.tgDiMuon = (int)(kq.tgQuetDen.Add(new TimeSpan(24, 0, 0)) - calam.caChieu_tuGio).TotalMinutes;
                                }
                            }
                            else // Nếu caChieu_tuGio là đêm
                            {
                                if (kq.tgQuetDen > calam.tuGio) // Nếu đến lúc tối
                                {
                                    kq.tgDiMuon = (int)(kq.tgQuetDen - calam.caChieu_tuGio.Add(new TimeSpan(24, 0, 0))).TotalMinutes;
                                }
                                else // Nếu đến lúc đêm
                                {
                                    kq.tgDiMuon = (int)(kq.tgQuetDen - calam.caChieu_tuGio).TotalMinutes;
                                }
                            }
                        }
                        else if (vm != null && vm.nghiCaNgay == 3) // Nếu xin nghỉ cả ngày
                        {
                        }
                        else // Trường hợp không đăng ký vắng mặt or nghỉ đêm.
                        {
                            if (kq.tgQuetDen > calam.tuGio) // Nếu đến lúc tối . calam.TuGio là đúng.
                            {
                                kq.tgDiMuon = (int)(kq.tgQuetDen - calam.tuGio).TotalMinutes;
                            }
                            else // Nếu đến lúc đêm hoặc sáng hsau.
                            {
                                kq.tgDiMuon = (int)(kq.tgQuetDen - calam.tuGio).TotalMinutes;
                            }
                        }
                        #endregion
                    }
                    #endregion
                    #region check ra
                    DateTime tgQuetRa = kq.ngay.Add(calam.tuGio).Add(calam.denGio);
                    DateTime tgQuetTruoc_Ra = tgQuetRa.AddMinutes(-1 * calam.tgQuetTruoc_Ra);
                    DateTime tgQuetSau_Ra = tgQuetRa.AddMinutes(calam.tgQuetSau_Ra);

                    var dr2 = ds.tbDuLieuQuetThe
                        .Where(i => i.thoigian >= tgQuetTruoc_Ra && i.thoigian <= tgQuetSau_Ra && i.maNV == kq.EmployeeID)
                        .OrderByDescending(i => i.thoigian)
                        .FirstOrDefault();
                    if (dr2 == null && vm != null && vm.nghiCaNgay == 2) //nghỉ chiều => check h vào tư ca sáng
                    {
                        tgQuetRa = kq.ngay.Add(calam.tuGio).Add(calam.caSang_denGio);
                        tgQuetTruoc_Ra = tgQuetRa.AddMinutes(-1 * calam.tgQuetTruoc_Ra);
                        tgQuetSau_Ra = tgQuetRa.AddMinutes(calam.tgQuetSau_Ra);

                        dr2 = ds.tbDuLieuQuetThe
                            .Where(i => i.thoigian >= tgQuetTruoc_Ra && i.thoigian <= tgQuetSau_Ra && i.maNV == kq.EmployeeID)
                            .OrderByDescending(i => i.thoigian)
                            .FirstOrDefault();
                    }

                    if (dr2 == null) //ko co quet tay luc ve trong khoang tg cho phep
                    {
                        kq["tgQuetVe_old"] = DBNull.Value;
                    }
                    else
                    {
                        kq.tgQuetVe_old = dr2.thoigian.TimeOfDay;
                    }

                    if (overideModified || kq.IstgQuetVeNull() || kq.IsmodifyDateNull() || kq.IsmodifyByNull())
                        kq["tgQuetVe"] = kq["tgQuetVe_old"];

                    if (kq["tgQuetVe"] != DBNull.Value)
                    {
                        #region tính tg về sớm dựa vào tgQuetVe

                        if (vm != null && vm.nghiCaNgay == 2) // Nếu nghỉ đêm lấy casang_DenGio check đi muộn
                        {
                            if (calam.caSang_denGio > calam.tuGio) // Nếu casang_denGio là tối (<24)
                            {
                                if (kq.tgQuetVe > calam.tuGio) // Nếu về lúc tối
                                {
                                    kq.tgVeSom = (int)(calam.caSang_denGio - kq.tgQuetVe).TotalMinutes;
                                }
                                else// Nếu về lúc đêm
                                {
                                    kq.tgVeSom = (int)(calam.caSang_denGio - kq.tgQuetVe.Add(new TimeSpan(24, 0, 0))).TotalMinutes;
                                }
                            }
                            else // Nếu casang_denGio là đêm
                            {
                                if (kq.tgQuetVe > calam.tuGio) // Nếu về lúc tối
                                {
                                    kq.tgVeSom = (int)(calam.caSang_denGio.Add(new TimeSpan(24, 0, 0)) - kq.tgQuetVe).TotalMinutes;
                                }
                                else // Nếu về lúc đêm
                                {
                                    kq.tgVeSom = (int)(calam.caSang_denGio - kq.tgQuetVe).TotalMinutes;
                                }
                            }

                        }
                        else if (vm != null && vm.nghiCaNgay == 3) // Nếu xin nghỉ cả ngày
                        {

                        }
                        else // Trường hợp không đăng ký vắng mặt or nghỉ sáng.
                        {
                            if (kq.tgQuetVe > calam.tuGio) // Nếu về lúc tối . calam.TuGio là đúng.
                            {
                                kq.tgVeSom = (int)(calam_denGio_4check - kq.tgQuetVe).TotalMinutes;
                            }
                            else // Nếu về lúc đêm hoặc sáng hsau.
                            {
                                kq.tgVeSom = (int)((new TimeSpan(0, calam_denGio_4check.Hours, calam_denGio_4check.Minutes, calam_denGio_4check.Seconds)) - kq.tgQuetVe).TotalMinutes;
                            }

                        }
                        #endregion

                        if (kq.tgVeSom <= -28)
                        {
                            if (vm != null && (vm.nghiCaNgay == 2 || vm.nghiCaNgay == 3)) //nếu xin nghỉ chiều or nghỉ cả ngày => tăng ca = 0
                            {
                                kq.tgTinhTangCa = 0;
                            }
                            else
                            {
                                kq.tgTinhTangCa = Math.Round(-1.0 * kq.tgVeSom / 60, 2);
                                #region tinh giờ tăng ca
                                float ext = (float)(kq.tgTinhTangCa - (int)kq.tgTinhTangCa);
                                kq.tgTinhTangCa = (int)kq.tgTinhTangCa;
                                if (ext >= 0.46 && ext <= 0.96)
                                    kq.tgTinhTangCa += 0.5;
                                else if (ext > 0.96)
                                    kq.tgTinhTangCa += 1;
                                kq.tgTinhTangCa -= calam.soTiengTangCaTrachNhiem;
                                if (kq.tgTinhTangCa <= 0)
                                    kq.tgTinhTangCa = 0;
                                kq.tgTinhTangCa = Math.Min(kq.tgTinhTangCa, calam.soTiengTinhTangCa);
                                #endregion
                            }
                        }
                    }
                    #endregion
                    kq.kqNgayCong = 0;
                    kq.status = 1;
                    kq.tt_coQuetTay = kq.tt_leTet = kq.tt_nghiPhep = kq.tt_diMuonVeSom = kq.tt_ok = 0;
                    kq.tt_nghiPhep_Alias = "";

                    #region check có đi làm (quẹt tay) hay ko
                    kq.tt_coQuetTay = (kq["tgQuetDen"] != DBNull.Value ? 1 : 0) + (kq["tgQuetVe"] != DBNull.Value ? 2 : 0);

                    #endregion
                    bool laNgayPhepNam = false;
                    #region check lễ tết
                    if (vm != null && vm.lydo == 15)
                    {
                        laNgayPhepNam = false;
                    }
                    else
                    {
                        laNgayPhepNam = (ds.tbNgayNghiPhepNam.FirstOrDefault(i =>
                                                            i.ngay == kq.ngay.Day && i.thang == kq.ngay.Month &&
                                                            (i["nam"] == DBNull.Value || i.nam == 0 || i.nam == kq.ngay.Year)) != null);
                    }
                    kq.tt_leTet = laNgayPhepNam ? 1 : 0;
                    #endregion

                    #region check nghỉ phép
                    if (vm != null)
                    {
                        kq.tt_nghiPhep_Alias = "NP";
                        kq.tt_nghiPhep = vm.nghiCaNgay;
                        if (vm["lydo"] != DBNull.Value && Enums.LyDoNghi_CodeAlias.ContainsKey(vm.lydo))
                            kq.tt_nghiPhep_Alias = Enums.LyDoNghi_CodeAlias[vm.lydo];
                    }
                    if (kq.tt_coQuetTay == 0 && !laNgayPhepNam)
                    {
                        if (vm == null)
                        {
                            kq.tt_nghiPhep_Alias = "KP";
                            kq.tt_nghiPhep = 3;
                        }
                        kq.tgTinhTangCa = 0;
                    }
                    #endregion

                    #region check di muon ve som

                    if (kq.tt_coQuetTay == 3)
                    {
                        kq.tt_ok = 1;
                        if (vm == null)
                            kq.kqNgayCong = 1;
                        else if (vm.nghiCaNgay == 1 || vm.nghiCaNgay == 2)
                            kq.kqNgayCong = 0.5;
                        else if (vm.nghiCaNgay == 3)
                            kq.kqNgayCong = 0;

                        if (kq.tgDiMuon > 0)
                        {
                            kq.tt_diMuonVeSom = 1;
                            kq.kqNgayCong -= ((double)kq.tgDiMuon / (calam.soTiengTinhCa * 60));
                        }
                        if (kq.tgVeSom > 0)
                        {
                            kq.tt_diMuonVeSom += 2;
                            kq.kqNgayCong -= ((double)kq.tgVeSom / (calam.soTiengTinhCa * 60));
                        }
                        kq.kqNgayCong = Math.Max(kq.kqNgayCong, 0);
                        if (kq.kqNgayCong == 0)
                        {
                            kq.tgTinhTangCa = 0;
                        }
                    }

                    #endregion

                    #region check error
                    kq.tt_error = 0;
                    if (vm != null && kq.tt_coQuetTay == 3)
                    {
                        if ((kq.tgQuetDen <= vm.tuGio && vm.tuGio < kq.tgQuetVe) || (kq.tgQuetDen < vm.denGio && vm.denGio <= kq.tgQuetVe))
                        {
                            kq.tt_error = 1;
                            //kq.kqNgayCong = 0;
                        }
                    }

                    #endregion

                    kq.statePushServer = "edited";
                    kq.analyzeDate = DateTime.Now;
                    kq.analyzeBy = UserDoing.id;
                    return "";
                }
                #endregion
                #region Nếu là ca ngày
                else // Nếu là ca ngày, sáng, chiều, hành chính.
                {
                    #region check vào
                    DateTime tgQuetVao = kq.ngay.Add(calam.tuGio);
                    DateTime tgQuetTruoc_Vao = tgQuetVao.AddMinutes(-1 * calam.tgQuetTruoc_Vao);
                    DateTime tgQuetSau_Vao = tgQuetVao.AddMinutes(calam.tgQuetSau_Vao);

                    var dr = ds.tbDuLieuQuetThe
                        .Where(i => i.thoigian >= tgQuetTruoc_Vao && i.thoigian <= tgQuetSau_Vao && i.maNV == kq.EmployeeID)
                        .OrderBy(i => i.thoigian)
                        .FirstOrDefault();

                    if (dr == null && vm != null && vm.nghiCaNgay == 1) //nghỉ sáng => check h vào tư ca chiều
                    {
                        tgQuetVao = kq.ngay.Add(calam.caChieu_tuGio);
                        tgQuetTruoc_Vao = tgQuetVao.AddMinutes(-1 * calam.tgQuetTruoc_Vao);
                        tgQuetSau_Vao = tgQuetVao.AddMinutes(calam.tgQuetSau_Vao);

                        dr = ds.tbDuLieuQuetThe
                            .Where(i => i.thoigian >= tgQuetTruoc_Vao && i.thoigian <= tgQuetSau_Vao && i.maNV == kq.EmployeeID)
                            .OrderBy(i => i.thoigian)
                            .FirstOrDefault();
                    }

                    if (dr == null) //ko co quyet tay luc den trong khoang tg cho phep
                    {
                        kq["tgQuetDen_old"] = DBNull.Value;
                    }
                    else
                    {
                        kq.tgQuetDen_old = dr.thoigian.TimeOfDay;
                    }

                    if (overideModified || kq.IstgQuetDenNull())
                        kq["tgQuetDen"] = kq["tgQuetDen_old"];

                    if (kq["tgQuetDen"] != DBNull.Value)
                    {
                        kq.tgDiMuon = (int)(kq.tgQuetDen - calam_tuGio_4check).TotalMinutes;

                        if (kq.tgQuetDen > calam.caSang_denGio) //kiểm tra muộn qua h nghỉ trưa thì trừ
                            kq.tgDiMuon -= (int)(Math.Min(kq.tgQuetDen.TotalMinutes, calam.caChieu_tuGio.TotalMinutes) - calam.caSang_denGio.TotalMinutes);
                    }

                    #endregion

                    #region check ra
                    DateTime tgQuetRa = kq.ngay.Add(calam.tuGio).Add(calam.denGio);
                    DateTime tgQuetTruoc_Ra = tgQuetRa.AddMinutes(-1 * calam.tgQuetTruoc_Ra);
                    DateTime tgQuetSau_Ra = tgQuetRa.AddMinutes(calam.tgQuetSau_Ra);

                    var dr2 = ds.tbDuLieuQuetThe
                        .Where(i => i.thoigian >= tgQuetTruoc_Ra && i.thoigian <= tgQuetSau_Ra && i.maNV == kq.EmployeeID)
                        .OrderByDescending(i => i.thoigian)
                        .FirstOrDefault();

                    if (dr2 == null && vm != null && vm.nghiCaNgay == 2) //nghỉ chiều => check h vào tư ca sáng
                    {
                        tgQuetRa = kq.ngay.Add(calam.tuGio).Add(calam.caSang_denGio);
                        tgQuetTruoc_Ra = tgQuetRa.AddMinutes(-1 * calam.tgQuetTruoc_Ra);
                        tgQuetSau_Ra = tgQuetRa.AddMinutes(calam.tgQuetSau_Ra);

                        dr2 = ds.tbDuLieuQuetThe
                            .Where(i => i.thoigian >= tgQuetTruoc_Ra && i.thoigian <= tgQuetSau_Ra && i.maNV == kq.EmployeeID)
                            .OrderByDescending(i => i.thoigian)
                            .FirstOrDefault();
                    }

                    if (dr2 == null) //ko co quyet tay luc ve trong khoang tg cho phep
                    {
                        kq["tgQuetVe_old"] = DBNull.Value;
                    }
                    else
                    {
                        kq.tgQuetVe_old = dr2.thoigian.TimeOfDay;
                    }

                    if (overideModified || kq.IstgQuetVeNull())
                        kq["tgQuetVe"] = kq["tgQuetVe_old"];

                    if (kq["tgQuetVe"] != DBNull.Value)
                    {
                        kq.tgVeSom = (int)(calam_denGio_4check - kq.tgQuetVe).TotalMinutes;
                        if (vm != null && vm.nghiCaNgay == 2) //nếu nghỉ chiều lấy h ca sáng tính về sớm
                            kq.tgVeSom = (int)(calam.caSang_denGio - kq.tgQuetVe).TotalMinutes;

                        if (kq.tgQuetVe < calam.caChieu_tuGio) //kiểm tra sớm trước h nghỉ trưa thì trừ
                            kq.tgVeSom -= (int)(calam.caChieu_tuGio.TotalMinutes - Math.Max(kq.tgQuetVe.TotalMinutes, calam.caSang_denGio.TotalMinutes));

                        if (kq.tgVeSom <= -28)
                        {
                            if (vm != null && vm.nghiCaNgay == 2) //nếu xin nghỉ chiều => tăng ca = 0
                            {
                                kq.tgTinhTangCa = 0;
                            }
                            else
                            {
                                kq.tgTinhTangCa = Math.Round(-1.0 * kq.tgVeSom / 60, 2);
                                float ext = (float)(kq.tgTinhTangCa - (int)kq.tgTinhTangCa);
                                kq.tgTinhTangCa = (int)kq.tgTinhTangCa;
                                if (ext >= 0.46 && ext <= 0.96)
                                    kq.tgTinhTangCa += 0.5;
                                else if (ext > 0.96)
                                    kq.tgTinhTangCa += 1;

                                kq.tgTinhTangCa -= calam.soTiengTangCaTrachNhiem;

                                if (kq.tgTinhTangCa <= 0)
                                    kq.tgTinhTangCa = 0;
                            }
                        }
                    }
                    kq.tgTinhTangCa = Math.Min(kq.tgTinhTangCa, calam.soTiengTinhTangCa);
                    #endregion

                    kq.kqNgayCong = 0;
                    kq.status = 1;
                    kq.tt_coQuetTay = kq.tt_leTet = kq.tt_nghiPhep = kq.tt_diMuonVeSom = kq.tt_ok = 0;
                    kq.tt_nghiPhep_Alias = "";

                    #region check có đi làm (quẹt tay) hay ko
                    kq.tt_coQuetTay = (kq["tgQuetDen"] != DBNull.Value ? 1 : 0) + (kq["tgQuetVe"] != DBNull.Value ? 2 : 0);

                    #endregion
                    bool laNgayPhepNam = false;
                    #region check lễ tết
                    if (vm != null && vm.lydo == 15)
                    {
                        laNgayPhepNam = false;
                    }
                    else
                    {
                        laNgayPhepNam = (ds.tbNgayNghiPhepNam.FirstOrDefault(i =>
                                                            i.ngay == kq.ngay.Day && i.thang == kq.ngay.Month &&
                                                            (i["nam"] == DBNull.Value || i.nam == 0 || i.nam == kq.ngay.Year)) != null);
                    }
                    kq.tt_leTet = laNgayPhepNam ? 1 : 0;
                    #endregion

                    #region check nghỉ phép
                    if (vm != null)
                    {
                        kq.tt_nghiPhep_Alias = "NP";
                        kq.tt_nghiPhep = vm.nghiCaNgay;
                        if (vm["lydo"] != DBNull.Value && Enums.LyDoNghi_CodeAlias.ContainsKey(vm.lydo))
                            kq.tt_nghiPhep_Alias = Enums.LyDoNghi_CodeAlias[vm.lydo];
                    }
                    if (kq.tt_coQuetTay == 0 && !laNgayPhepNam)
                    {
                        if (vm == null)
                        {
                            kq.tt_nghiPhep_Alias = "KP";
                            kq.tt_nghiPhep = 3;
                        }
                        kq.tgTinhTangCa = 0;
                    }
                    #endregion

                    #region check di muon ve som

                    if (kq.tt_coQuetTay == 3)
                    {
                        kq.tt_ok = 1;
                        if (vm == null)
                            kq.kqNgayCong = 1;
                        else if (vm.nghiCaNgay == 1 || vm.nghiCaNgay == 2)
                            kq.kqNgayCong = 0.5;
                        else if (vm.nghiCaNgay == 3)
                            kq.kqNgayCong = 0;

                        if (kq.tgDiMuon > 0)
                        {
                            kq.tt_diMuonVeSom = 1;
                            kq.kqNgayCong -= ((double)kq.tgDiMuon / (calam.soTiengTinhCa * 60));
                        }
                        if (kq.tgVeSom > 0)
                        {
                            kq.tt_diMuonVeSom += 2;
                            kq.kqNgayCong -= ((double)kq.tgVeSom / (calam.soTiengTinhCa * 60));
                        }
                        kq.kqNgayCong = Math.Max(kq.kqNgayCong, 0);
                        if (kq.kqNgayCong == 0)
                        {
                            kq.tgTinhTangCa = 0;
                        }
                    }

                    #endregion

                    #region check error
                    kq.tt_error = 0;
                    if (vm != null && kq.tt_coQuetTay == 3)
                    {
                        if ((kq.tgQuetDen <= vm.tuGio && vm.tuGio < kq.tgQuetVe) || (kq.tgQuetDen < vm.denGio && vm.denGio <= kq.tgQuetVe))
                        {
                            kq.tt_error = 1;
                        }
                    }

                    #endregion

                    kq.statePushServer = "edited";
                    kq.analyzeDate = DateTime.Now;
                    kq.analyzeBy = UserDoing.id;
                    return "";
                }
                #endregion
            }
            catch (Exception ex)
            {
                return string.Format("Emp [{0}] Date {1:dd/MM/yyyy} Analyze fail: {2}", kq.EmployeeID, kq.ngay, ex.Message);
            }
        }

        private double getMinutesBetween(TimeSpan gio1, TimeSpan gio2)
        {
            double Minutes = 0;
            if (gio1.Days >= 1)
                gio1 = new TimeSpan(0, gio1.Hours, gio1.Minutes, gio1.Seconds);
            if (gio2.Days >= 1)
                gio2 = new TimeSpan(0, gio2.Hours, gio2.Minutes, gio2.Seconds);
            if (gio1 > gio2)
            {
                gio2 = gio2.Add(new TimeSpan(24, 0, 0));
            }
            Minutes = (gio2 - gio1).TotalMinutes;
            return Minutes;
        }
    }

    public static class QuetThe
    {
        public static int SetTimeQT(Guid idKqQT, TimeSpan tgQuetDen, TimeSpan tgQuetVe, bool OnlyNoData = false, bool force = false, iHRM.Core.Business.DbObject.w5sysUser userLoginin = null)
        {
            #region reg
            var db = new Core.Business.DbObject.dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
            var kq = db.tbKetQuaQuetThes.SingleOrDefault(i => i.id == idKqQT);
            if (kq.isLocked == true && (userLoginin == null || !userLoginin.isAdmin))
                return 0;

            var vm = kq.tbDangKyVangMats.FirstOrDefault();

            if (!force && vm != null)
                return 0;

            if (OnlyNoData)
            {
                if (kq.tgQuetDen != null)
                    tgQuetDen = kq.tgQuetDen.Value;
                if (kq.tgQuetVe != null)
                    tgQuetVe = kq.tgQuetVe.Value;
            }

            if (kq.ngay != null)
                kq.tt_chuNhat = kq.ngay.Value.DayOfWeek == DayOfWeek.Sunday;

            var calam = kq.tbCaLamViec;
            if (calam == null)
                return 0;

            #endregion
            TimeSpan calam_tuGio_4check = calam.tuGio, calam_denGio_4check = calam.tuGio.Add(calam.denGio);

            if (vm != null)
            {
                if (vm.nghiCaNgay == 1) //nghỉ sáng
                {
                    calam_tuGio_4check = calam.caChieu_tuGio ?? new TimeSpan();
                    if (vm.coHuongLuong == 1)
                    {
                        kq.daysOfNghiCoLuong = 0.5;
                    }
                }
                else if (vm.nghiCaNgay == 2) //nghỉ chiều
                {
                    calam_denGio_4check = calam.caSang_denGio ?? new TimeSpan();
                    if (vm.coHuongLuong == 1)
                    {
                        kq.daysOfNghiCoLuong = 0.5;
                    }
                }
                else if (vm.nghiCaNgay == 3) //nghỉ cả ngày
                {
                    if (vm.coHuongLuong == 1)
                    {
                        kq.daysOfNghiCoLuong = 1;
                    }
                }
            }

            #region Nếu là ca đêm
            if (calam.caDem != null && calam.caDem.Value)
            {
                #region check time quẹt đên và về

                if (tgQuetDen.TotalSeconds == 0)
                {
                    kq.tgQuetDen = null;
                    kq.tgDiMuon = 0;
                }
                else
                {
                    kq.tgQuetDen = tgQuetDen;
                    #region tính tg đi muộn dựa vào tgQuetDen
                    if (vm != null && vm.nghiCaNgay == 1) // Nếu nghỉ sáng 
                    {
                        if (calam.caChieu_tuGio > calam.tuGio) // Nếu caChieu_tuGio là tối (<24)
                        {
                            if (kq.tgQuetDen > calam.tuGio) // Nếu đến lúc tối
                            {
                                kq.tgDiMuon = (int)(kq.tgQuetDen.Value - calam.caChieu_tuGio.Value).TotalMinutes;
                            }
                            else// Nếu đến lúc đêm
                            {
                                kq.tgDiMuon = (int)(kq.tgQuetDen.Value.Add(new TimeSpan(24, 0, 0)) - calam.caChieu_tuGio.Value).TotalMinutes;
                            }
                        }
                        else // Nếu caChieu_tuGio là đêm
                        {
                            if (kq.tgQuetDen > calam.tuGio) // Nếu về lúc tối
                            {
                                kq.tgDiMuon = (int)(kq.tgQuetDen.Value - calam.caChieu_tuGio.Value.Add(new TimeSpan(24, 0, 0))).TotalMinutes;
                            }
                            else // Nếu về lúc đêm
                            {
                                kq.tgDiMuon = (int)(kq.tgQuetDen.Value - calam.caChieu_tuGio.Value).TotalMinutes;
                            }
                        }
                    }
                    else if (vm != null && vm.nghiCaNgay == 3) // Nếu xin nghỉ cả ngày
                    {
                    }
                    else // Trường hợp không đăng ký vắng mặt or nghỉ đêm.
                    {
                        if (kq.tgQuetDen.Value > calam.tuGio) // Nếu về lúc tối . calam.TuGio là đúng.
                        {
                            kq.tgDiMuon = (int)(kq.tgQuetDen.Value - calam.tuGio).TotalMinutes;
                        }
                        else // Nếu về lúc đêm hoặc sáng hsau.
                        {
                            kq.tgDiMuon = (int)(kq.tgQuetDen.Value - (new TimeSpan(0, calam.tuGio.Hours, calam.tuGio.Minutes, calam.tuGio.Seconds))).TotalMinutes;
                        }
                    }
                    #endregion
                }

                if (tgQuetVe.TotalSeconds == 0)
                {
                    kq.tgQuetVe = null;
                    kq.tgVeSom = 0;
                }
                else
                {
                    kq.tgQuetVe = tgQuetVe;
                    kq.tgVeSom = (int)(calam_denGio_4check - tgQuetVe).TotalMinutes;

                    #region tính tg về sớm dựa vào tgQuetVe

                    if (vm != null && vm.nghiCaNgay == 2) // Nếu nghỉ đêm lấy casang_DenGio check đi muộn
                    {
                        if (calam.caSang_denGio > calam.tuGio) // Nếu casang_denGio là tối (<24)
                        {
                            if (kq.tgQuetVe > calam.tuGio) // Nếu về lúc tối
                            {
                                kq.tgVeSom = (int)(calam.caSang_denGio.Value - kq.tgQuetVe.Value).TotalMinutes;
                            }
                            else// Nếu về lúc đêm
                            {
                                kq.tgVeSom = (int)(calam.caSang_denGio.Value - kq.tgQuetVe.Value.Add(new TimeSpan(24, 0, 0))).TotalMinutes;
                            }
                        }
                        else // Nếu casang_denGio là đêm
                        {
                            if (kq.tgQuetVe > calam.tuGio) // Nếu về lúc tối
                            {
                                kq.tgVeSom = (int)(calam.caSang_denGio.Value.Add(new TimeSpan(24, 0, 0)) - kq.tgQuetVe.Value).TotalMinutes;
                            }
                            else // Nếu về lúc đêm
                            {
                                kq.tgVeSom = (int)(calam.caSang_denGio.Value - kq.tgQuetVe.Value).TotalMinutes;
                            }
                        }
                    }
                    else if (vm != null && vm.nghiCaNgay == 3) // Nếu xin nghỉ cả ngày
                    {
                    }
                    else // Trường hợp không đăng ký vắng mặt or nghỉ sáng.
                    {
                        if (kq.tgQuetVe.Value > calam.tuGio) // Nếu về lúc tối . calam.TuGio là đúng.
                        {
                            kq.tgVeSom = (int)(calam_denGio_4check - kq.tgQuetVe.Value).TotalMinutes;
                        }
                        else // Nếu về lúc đêm hoặc sáng hsau.
                        {
                            kq.tgVeSom = (int)((new TimeSpan(0, calam_denGio_4check.Hours, calam_denGio_4check.Minutes, calam_denGio_4check.Seconds)) - kq.tgQuetVe.Value).TotalMinutes;
                        }
                    }
                    #endregion

                    if (kq.tgVeSom <= -28)
                    {
                        if (vm != null && (vm.nghiCaNgay == 2 || vm.nghiCaNgay == 3)) //nếu xin nghỉ chiều => tăng ca = 0
                        {
                            kq.tgTinhTangCa = 0;
                        }
                        else
                        {
                            kq.tgTinhTangCa = Math.Round(-1.0 * (kq.tgVeSom ?? 0) / 60, 2);

                            #region tinh giờ tăng ca

                            float ext = (float)(kq.tgTinhTangCa - (int)kq.tgTinhTangCa);
                            kq.tgTinhTangCa = (int)kq.tgTinhTangCa;
                            if (ext >= 0.46 && ext <= 0.96)
                                kq.tgTinhTangCa += 0.5;
                            else if (ext > 0.96)
                                kq.tgTinhTangCa += 1;
                            kq.tgTinhTangCa -= calam.soTiengTangCaTrachNhiem;
                            if (kq.tgTinhTangCa <= 0)
                                kq.tgTinhTangCa = 0;
                            kq.tgTinhTangCa = Math.Min(kq.tgTinhTangCa.Value, calam.soTiengTinhTangCa);
                            #endregion
                        }
                    }
                    else
                    {
                        kq.tgTinhTangCa = 0;
                    }
                }
                #endregion

                //--------------------------------------------------------------------------------------------------------------------------------
                kq.kqNgayCong = 0;
                kq.status = 1;
                kq.tt_coQuetTay = kq.tt_leTet = kq.tt_nghiPhep = kq.tt_diMuonVeSom = kq.tt_ok = 0;
                kq.tt_nghiPhep_Alias = "";

                #region check có đi làm (quẹt tay) hay ko
                kq.tt_coQuetTay = (kq.tgQuetDen != null ? 1 : 0) + (kq.tgQuetVe != null ? 2 : 0);

                #endregion
                bool laNgayPhepNam = false;
                #region check lễ tết
                if (vm != null && vm.lydo == 15)
                {
                    laNgayPhepNam = false;
                }
                else
                {
                    laNgayPhepNam = (db.tbNgayNghiPhepNams.FirstOrDefault(i =>
                                                        i.ngay.Value == kq.ngay.Value.Day && i.thang == kq.ngay.Value.Month &&
                                                        (i.nam == null || i.nam == 0 || i.nam == kq.ngay.Value.Year)) != null);
                }
                kq.tt_leTet = laNgayPhepNam ? 1 : 0;
                #endregion

                #region check nghỉ phép
                if (vm != null)
                {
                    kq.tt_nghiPhep_Alias = "NP";
                    kq.tt_nghiPhep = vm.nghiCaNgay.Value;
                    if (vm.lydo != null && Enums.LyDoNghi_CodeAlias.ContainsKey(vm.lydo.Value))
                        kq.tt_nghiPhep_Alias = Enums.LyDoNghi_CodeAlias[vm.lydo.Value];
                }
                if (kq.tt_coQuetTay == 0 && !laNgayPhepNam)
                {
                    if (vm == null)
                    {
                        kq.tt_nghiPhep_Alias = "KP";
                        kq.tt_nghiPhep = 3;
                    }
                    kq.tgTinhTangCa = 0;
                }
                #endregion

                #region check di muon ve som

                if (kq.tt_coQuetTay == 3)
                {
                    kq.tt_ok = 1;
                    if (vm == null)
                        kq.kqNgayCong = 1;
                    else if (vm.nghiCaNgay == 1 || vm.nghiCaNgay == 2)
                        kq.kqNgayCong = 0.5;
                    else if (vm.nghiCaNgay == 3)
                        kq.kqNgayCong = 0;

                    if (kq.tgDiMuon > 0)
                    {
                        kq.tt_diMuonVeSom = 1;
                        kq.kqNgayCong -= ((double)kq.tgDiMuon / (calam.soTiengTinhCa * 60));
                    }
                    if (kq.tgVeSom > 0)
                    {
                        kq.tt_diMuonVeSom += 2;
                        kq.kqNgayCong -= ((double)kq.tgVeSom / (calam.soTiengTinhCa * 60));
                    }

                    kq.kqNgayCong = Math.Max(kq.kqNgayCong ?? 0, 0);
                    if (kq.kqNgayCong == 0)
                    {
                        kq.tgTinhTangCa = 0;
                    }
                }
                #endregion
                #region check error
                kq.tt_error = 0;
                if (vm != null && kq.tt_coQuetTay == 3)
                {
                    if ((kq.tgQuetDen <= vm.tuGio && vm.tuGio < kq.tgQuetVe) || (kq.tgQuetDen < vm.denGio && vm.denGio <= kq.tgQuetVe))
                    {
                        kq.tt_error = 1;
                        //kq.kqNgayCong = 0;
                    }
                }
                #endregion
                kq.modifyDate = DateTime.Now;
                kq.modifyBy = userLoginin == null ? null : (long?)userLoginin.id;
                kq.statePushServer = "edited";
                db.SubmitChanges();
                return 1;
            }
            #endregion
            #region Nếu là ca ngày
            else
            {
                #region check time quẹt đên và về

                if (tgQuetDen.TotalSeconds == 0)
                {
                    kq.tgQuetDen = null;
                    kq.tgDiMuon = 0;
                }
                else
                {
                    kq.tgQuetDen = tgQuetDen;
                    kq.tgDiMuon = (int)(tgQuetDen - calam_tuGio_4check).TotalMinutes;

                    if (kq.tgQuetDen > calam.caSang_denGio) //kiểm tra muộn qua h nghỉ trưa thì trừ
                        kq.tgDiMuon -= (int)(Math.Min(kq.tgQuetDen.Value.TotalMinutes, calam.caChieu_tuGio.Value.TotalMinutes) - calam.caSang_denGio.Value.TotalMinutes);
                }

                if (tgQuetVe.TotalSeconds == 0)
                {
                    kq.tgQuetVe = null;
                    kq.tgVeSom = 0;
                }
                else
                {
                    kq.tgQuetVe = tgQuetVe;
                    kq.tgVeSom = (int)(calam_denGio_4check - tgQuetVe).TotalMinutes;

                    if (kq.tgQuetVe < calam.caChieu_tuGio) //kiểm tra sớm trước h nghỉ trưa thì trừ
                        kq.tgVeSom -= (int)(calam.caChieu_tuGio.Value.TotalMinutes - Math.Max(kq.tgQuetVe.Value.TotalMinutes, calam.caSang_denGio.Value.TotalMinutes));

                    if (kq.tgVeSom <= -28)
                    {
                        if (vm != null && (vm.nghiCaNgay == 2 || vm.nghiCaNgay == 3)) //nếu xin nghỉ chiều => tăng ca = 0
                        {
                            kq.tgTinhTangCa = 0;
                        }
                        else
                        {
                            kq.tgTinhTangCa = Math.Round(-1.0 * (kq.tgVeSom ?? 0) / 60, 2);
                            float ext = (float)(kq.tgTinhTangCa - (int)kq.tgTinhTangCa);
                            kq.tgTinhTangCa = (int)kq.tgTinhTangCa;
                            if (ext >= 0.46 && ext <= 0.96)
                                kq.tgTinhTangCa += 0.5;
                            else if (ext > 0.96)
                                kq.tgTinhTangCa += 1;
                            kq.tgTinhTangCa -= calam.soTiengTangCaTrachNhiem;
                            if (kq.tgTinhTangCa <= 0)
                                kq.tgTinhTangCa = 0;
                        }
                    }
                    else
                    {
                        kq.tgTinhTangCa = 0;
                    }
                }
                kq.tgTinhTangCa = Math.Min(kq.tgTinhTangCa.Value, calam.soTiengTinhTangCa);
                #endregion
                //--------------------------------------------------------------------------------------------------------------------------------
                kq.kqNgayCong = 0;
                kq.status = 1;
                kq.tt_coQuetTay = kq.tt_leTet = kq.tt_nghiPhep = kq.tt_diMuonVeSom = kq.tt_ok = 0;
                kq.tt_nghiPhep_Alias = "";

                #region check có đi làm (quẹt tay) hay ko
                kq.tt_coQuetTay = (kq.tgQuetDen != null ? 1 : 0) + (kq.tgQuetVe != null ? 2 : 0);
                #endregion
                #region check lễ tết
                bool laNgayPhepNam = false;
                if (vm != null && vm.lydo == 15)
                {
                    laNgayPhepNam = false;
                }
                else
                {
                    laNgayPhepNam = db.tbNgayNghiPhepNams.FirstOrDefault(i => i.ngay == kq.ngay.Value.Day && i.thang == kq.ngay.Value.Month &&
                        (i.nam == null || i.nam == 0 || i.nam == kq.ngay.Value.Year)) != null;
                }
                kq.tt_leTet = laNgayPhepNam ? 1 : 0;
                #endregion

                #region check nghỉ phép
                if (vm != null)
                {
                    kq.tt_nghiPhep_Alias = "NP";
                    kq.tt_nghiPhep = vm.nghiCaNgay.Value;
                    if (vm.lydo != null && Enums.LyDoNghi_CodeAlias.ContainsKey(vm.lydo.Value))
                        kq.tt_nghiPhep_Alias = Enums.LyDoNghi_CodeAlias[vm.lydo.Value];
                }
                if (kq.tt_coQuetTay == 0 && !laNgayPhepNam)
                {
                    if (vm == null)
                    {
                        kq.tt_nghiPhep_Alias = "KP";
                        kq.tt_nghiPhep = 3;
                    }
                    kq.tgTinhTangCa = 0;
                }
                #endregion

                #region check di muon ve som

                if (kq.tt_coQuetTay == 3)
                {
                    kq.tt_ok = 1;
                    if (vm == null)
                        kq.kqNgayCong = 1;
                    else if (vm.nghiCaNgay == 1 || vm.nghiCaNgay == 2)
                        kq.kqNgayCong = 0.5;
                    else if (vm.nghiCaNgay == 3)
                        kq.kqNgayCong = 0;

                    if (kq.tgDiMuon > 0)
                    {
                        kq.tt_diMuonVeSom = 1;
                        kq.kqNgayCong -= ((double)kq.tgDiMuon / (calam.soTiengTinhCa * 60));
                    }
                    if (kq.tgVeSom > 0)
                    {
                        kq.tt_diMuonVeSom += 2;
                        kq.kqNgayCong -= ((double)kq.tgVeSom / (calam.soTiengTinhCa * 60));
                    }

                    kq.kqNgayCong = Math.Max(kq.kqNgayCong ?? 0, 0);
                }

                #endregion

                #region check error
                kq.tt_error = 0;
                if (vm != null && kq.tt_coQuetTay == 3)
                {
                    if ((kq.tgQuetDen <= vm.tuGio && vm.tuGio < kq.tgQuetVe) || (kq.tgQuetDen < vm.denGio && vm.denGio <= kq.tgQuetVe))
                    {
                        kq.tt_error = 1;
                        //kq.kqNgayCong = 0;
                    }
                }

                #endregion

                kq.modifyDate = DateTime.Now;
                kq.modifyBy = userLoginin == null ? null : (long?)userLoginin.id;
                kq.statePushServer = "edited";
                db.SubmitChanges();
                return 1;
            }
            #endregion
        }

    }
}
