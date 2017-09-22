using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic.Luong;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iHRM.Win.ExtClass.Luong
{
    public class TinhLuongHelper_1dong
    {
        //dùng chung
        dsTinhLuong _ds = null;
        public int _soNgayCongTrongThang = 26;
        public DateTime kyLuong_TuNgay, kyLuong_DenNgay;

        //dùng riêng
        dsTinhLuong.p_tinhLuong_GetAllKetQuaQuetTheRow _kq;
        Guid? idCaLam_4lstTinhTC = null;
        List<dsTinhLuong.tbCaLam_TinhTangCaRow> lstTinhTC;
        public double _Luong1Ngay;
        public double _LuongTungNgay;
        public bool _LaLuongCu;
        public double _LuongCBCu, _LuongCBMoi, _LuongPCCu, _LuongPCMoi, _LuongCB1Ngay;

        public dsTinhLuong.tblEmpSalaryRow luongMoi;
        public dsTinhLuong.tblEmpSalaryRow luongCu;
        public TinhLuongHelper_1dong(dsTinhLuong ds, DateTime tuNgay, DateTime denNgay, string EmployeeID)
        {
            this._ds = ds;
            _soNgayCongTrongThang = Common.DungChung.Ham.DemNgayCong(tuNgay, denNgay) > 26 ? 26 : Common.DungChung.Ham.DemNgayCong(tuNgay, denNgay);

            kyLuong_TuNgay = tuNgay;
            kyLuong_DenNgay = denNgay;

            luongMoi = GetLuongMoi(EmployeeID);
            luongCu = GetLuongCu(EmployeeID, luongMoi);
            //if (luongCu != null && luongCu.EndDate < tuNgay)
            //    luongCu = null;

            if (luongMoi == null)
            {
                var kq1 = _ds.p_tinhLuong_GetAllKetQuaQuetThe.FirstOrDefault(i => i.EmployeeID == EmployeeID);
                if (kq1 == null)
                {
                    var db1 = new iHRM.Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);
                    var e = db1.tblEmployees.FirstOrDefault(i => i.EmployeeID == EmployeeID);
                    if (e != null)
                    {
                        _Luong1Ngay = (e.BasicSalary + e.RegularAllowance ?? 0) / _soNgayCongTrongThang;
                    }
                }
                else
                {
                    _Luong1Ngay = (DbHelper.DrGetDouble(kq1, "BasicSalary")) / _soNgayCongTrongThang;
                }
            }
            else
            {
                _Luong1Ngay = (DbHelper.DrGetDouble(luongMoi, "BasicSalary") ) / _soNgayCongTrongThang;
            }
            _LuongCBCu = DbHelper.DrGetDouble(luongCu, "BasicSalary");
            _LuongPCCu = DbHelper.DrGetDouble(luongCu, "BasicSalary_Ins");
            _LuongCBMoi = DbHelper.DrGetDouble(luongMoi, "BasicSalary");
            _LuongPCMoi = DbHelper.DrGetDouble(luongMoi, "BasicSalary_Ins");

        }

        public void Set_KQQT(dsTinhLuong.p_tinhLuong_GetAllKetQuaQuetTheRow kq)
        {
            this._kq = kq;
            this._kq.kqNgayCong = this._kq.IskqNgayCongNull() ? 0 : _kq.kqNgayCong;

            _kq.heSoLuong = _kq.IsheSoLuongNull() ? 100 : _kq.heSoLuong;
            _LaLuongCu = (luongCu != null && kq.ngay < luongMoi.DateChange);

            if (_LaLuongCu)
            {
                _LuongTungNgay = (DbHelper.DrGetDouble(luongCu, "BasicSalary")) / _soNgayCongTrongThang;
                _LuongCBCu = DbHelper.DrGetDouble(luongCu, "BasicSalary");
                _LuongPCCu = DbHelper.DrGetDouble(luongCu, "BasicSalary_Ins");
                _LuongCB1Ngay = _LuongCBCu / _soNgayCongTrongThang;
            }
            else
            {
                _LuongTungNgay = _Luong1Ngay;
                _LuongCB1Ngay = _LuongCBMoi / _soNgayCongTrongThang;
                _LuongCBMoi = DbHelper.DrGetDouble(luongMoi, "BasicSalary");
                _LuongPCMoi = DbHelper.DrGetDouble(luongMoi, "BasicSalary_Ins");
            }

            if (_kq["tt_chuNhat"] == DBNull.Value)
                _kq.tt_chuNhat = false;
        }

        #region tinh tien helper
        public double TinhNgayCong(int type = 0, bool tinhLuongCu = false, bool tinhCaDem = false)
        {
            if (_LaLuongCu != tinhLuongCu)
                return 0;

            if (type == 1 && (_kq.tt_nghiPhep == 3 || _kq.tt_leTet > 0 || _kq.tt_chuNhat))
                return 0;

            // Nghỉ phép năm
            if (type == 2)
            {
                double sophep = (!_kq.IsdaysOfNghiCoLuongNull() && !_kq.Istt_nghiPhep_AliasNull() && _kq.tt_nghiPhep_Alias == iHRM.Common.Code.Enums.LyDoNghi_CodeAlias.Where(p => p.Key == (int)Enums.eLyDoNghi.NghiPhepNam).First().Value) ? _kq.daysOfNghiCoLuong : 0;
                return sophep;
            }
            //Nghỉ chế độ, nghỉ có hưởng lương
            if (type == 5)
            {
                double sophep = (!_kq.IsdaysOfNghiCoLuongNull() && !_kq.Istt_nghiPhep_AliasNull() && _kq.tt_nghiPhep_Alias != iHRM.Common.Code.Enums.LyDoNghi_CodeAlias.Where(p => p.Key == (int)Enums.eLyDoNghi.NghiPhepNam).First().Value) ? _kq.daysOfNghiCoLuong : 0;
                return sophep;
            }

            if (type == 3) // Lễ tết
            {
                if (_kq.tt_leTet == 0)
                {
                    return 0;
                }
                else
                {
                    return _kq.tt_leTet == 1 ? 1 : 0;
                }
            }
            if (type == 4 && !_kq.tt_chuNhat)
                return 0;
            if (_kq["kqNgayCong"] == DBNull.Value)
            {
                return 0;
            }
            else
            {
                if (tinhCaDem)
                {
                    if (_kq.caDem)
                    {
                        return (Math.Round(_kq.kqNgayCong, 2));
                    }
                    else
                        return 0;
                }
                else
                {
                    if (_kq.caDem)
                    {
                        return 0;
                    }
                    else
                        return (Math.Round(_kq.kqNgayCong, 2));
                }
            }
        }
        public double TinhTienNgayCong(int type = 0, bool tinhLuongCu = false, bool tinhCaDem = false)
        {
            if (_LaLuongCu != tinhLuongCu)
                return 0;
            if (tinhCaDem)
            {
                if (_kq.caDem)
                {
                    if (type == 1)
                    {
                        return getTienNgayCongCaDem();
                    }
                    else
                    {
                        double ngayCong = TinhNgayCong(type, tinhLuongCu);
                        if (_kq.tt_leTet == 1)
                        {
                            return ngayCong * _LuongTungNgay;
                        }
                        else
                        {
                            return ngayCong * _LuongTungNgay * _kq.heSoLuong / 100;
                        }
                    }
                }
                else
                    return 0;
            }
            else
            {
                if (_kq.caDem)
                {
                    return 0;
                }
                else
                {
                    double ngayCong = TinhNgayCong(type, tinhLuongCu);
                    if (_kq.tt_leTet == 1)
                    {
                        return ngayCong * _LuongTungNgay;
                    }
                    else
                    {
                        return ngayCong * _LuongTungNgay * _kq.heSoLuong / 100;
                    }
                }
            }
        }
        public double TinhGioTangCa(int type = 0, bool tinhLuongCu = false, bool tinhCaDem = false)
        {
            if (_LaLuongCu != tinhLuongCu)
                return 0;

            double tgTinhTangCa = _kq["tgTinhTangCa"] == DBNull.Value ? 0 : _kq.tgTinhTangCa;
            if (tgTinhTangCa == 0 && _kq.tt_leTet == 0)
                return 0;

            if (_kq.tt_nghiPhep >= 2)
                return 0;

            if (type == 1 && (_kq.tt_leTet > 0 || _kq.tt_chuNhat))
                return 0;

            if (type == 4 && !_kq.tt_chuNhat) //chu nhat
                return 0;

            if (type == 3) //le tet
            {

                if (_kq.tt_leTet == 0)
                {
                    return 0;
                }
                else
                {
                    if (_kq.kqNgayCong > 0)
                        return _kq.kqNgayCong * 8;
                    else
                        return 0;
                }
            }
            CalcLstTinhCaLam();
            if (lstTinhTC == null || lstTinhTC.Count == 0)
            {
                //return tgTinhTangCa;
                return 0;
            }
            else
            {
                double sum = 0;
                foreach (var it in lstTinhTC)
                {
                    double soTieng = (tgTinhTangCa > it.thoiGian.TotalHours ? it.thoiGian.TotalHours : tgTinhTangCa);
                    sum += soTieng;
                    tgTinhTangCa -= soTieng;
                    if (tgTinhTangCa <= 0)
                        break;
                }
                sum = Math.Round(sum, 2);
                if (tinhCaDem)
                {
                    if (_kq.caDem)
                    {
                        return sum;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    if (_kq.caDem)
                    {
                        return 0;
                    }
                    else
                    {
                        return sum;
                    }
                }

            }
        }
        public double TinhTienTangCa(int type = 0, bool tinhLuongCu = false, bool tinhCaDem = false)
        {
            if (_LaLuongCu != tinhLuongCu)
                return 0;

            double tgTinhTangCa = _kq["tgTinhTangCa"] == DBNull.Value ? 0 : _kq.tgTinhTangCa;
            if (tgTinhTangCa == 0 && _kq.tt_leTet == 0)
                return 0;

            if (_kq.tt_nghiPhep >= 2) // 2: nghỉ chiều, 3: nghỉ cả ngày -> k có tăng ca
                return 0;

            if (type == 1 && (_kq.tt_leTet > 0 || _kq.tt_chuNhat))
                return 0;

            if (type == 4 && !_kq.tt_chuNhat) //chu nhat
                return 0;

            if (type == 3) //le tet
            {
                if (tinhCaDem != _kq.caDem)
                {
                    return 0;
                }
                if (_kq.tt_leTet == 0)
                {
                    return 0;
                }
                else
                {
                    if (_kq.kqNgayCong > 0)
                    {
                        if (tinhLuongCu)
                        {
                            return (_LuongCBCu / _soNgayCongTrongThang) * _kq.kqNgayCong * _kq.heSoLuong / 100;

                        }
                        else
                            return (_LuongCBMoi / _soNgayCongTrongThang) * _kq.kqNgayCong * _kq.heSoLuong / 100;
                    }
                    else
                        return 0;

                }
            }

            CalcLstTinhCaLam();
            if (lstTinhTC == null || lstTinhTC.Count == 0)
            {
                //return tgTinhTangCa * (luong1Ngay / kq.soTiengTinhCa);
                return 0;
            }
            else
            {
                if (tinhCaDem)
                {
                    if (_kq.caDem)
                    {
                        return getTienTangCaCaDem();
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    if (_kq.caDem)
                    {
                        return 0;
                    }
                    else
                    {
                        double sum = 0;
                        foreach (var it in lstTinhTC)
                        {
                            double soTieng = (tgTinhTangCa > it.thoiGian.TotalHours ? it.thoiGian.TotalHours : tgTinhTangCa);
                            //sum += soTieng * (_LuongTungNgay / _kq.soTiengTinhCa) * it.heSoLuong / 100; //tinh theo giờ ca
                            int heso = it.heSoLuong;
                            if (type != 2 && type != 3)
                            {
                                if (tinhLuongCu)
                                    sum += soTieng * (_LuongCBCu / _soNgayCongTrongThang) / 8 * heso / 100; //fixed / 8
                                else
                                    sum += soTieng * (_LuongCBMoi / _soNgayCongTrongThang) / 8 * heso / 100; //fixed / 8
                            }
                            else // Nếu là ngày chủ nhật or lễ tết
                            {
                                if (tinhLuongCu)
                                    sum += soTieng * (_LuongCBCu / _soNgayCongTrongThang) / 8 * _kq.heSoLuong / 100; //fixed / 8
                                else
                                    sum += soTieng * (_LuongCBMoi / _soNgayCongTrongThang) / 8 * _kq.heSoLuong / 100; //fixed / 8
                            }

                            tgTinhTangCa -= soTieng;
                            if (tgTinhTangCa <= 0)
                                break;
                        }
                        return sum;
                    }
                }

            }
        }

        void CalcLstTinhCaLam()
        {
            if (idCaLam_4lstTinhTC == null || idCaLam_4lstTinhTC != _kq.idCaLam)
                lstTinhTC = _ds.tbCaLam_TinhTangCa.Where(i => i.idCaLamViec == _kq.idCaLam).OrderBy(i => i.idx).ToList();
        }
        private double getTienNgayCongCaDem()
        {
            //          YS2
            // 7h30 PM - 10h PM= 100%. 
            // 10h PM -> 3:30 AM: 130%. 
            // 3h30 AM -> 6h AM: 215%. 
            // 6h -> DenGio = 150%. 
            //          YSS
            // 8h PM - 10h PM= 100%. 
            // 10h PM -> 4h AM: 130%. 
            // 4h AM -> 6h AM: 215%. 
            // 6h -> DenGio = 150%. 
            double total = 0;
            if (_kq.kqNgayCong > 0)
            {
                DateTime tgQuetDen = _kq.ngay.AddHours(_kq.tuGio.TotalHours);
                DateTime tgQuetVe = _kq.ngay.AddHours(_kq.tuGio.TotalHours);
                if (_kq.tuGio < _kq.tgQuetDen) // Nếu quẹt đến muộn.
                {
                    tgQuetDen = _kq.ngay.AddHours(_kq.tgQuetDen.TotalHours);
                }
                if (_kq.tgQuetVe < _kq.tgQuetDen) // Đến lúc tối < 24h và Về lúc sáng hôm sau
                {
                    tgQuetVe = _kq.ngay.AddDays(1).AddHours(_kq.tgQuetVe.TotalHours);
                }
                else if (_kq.tgQuetVe >= new TimeSpan(18, 0, 0))// Về và đến cùng 1 ngày .Cùng buổi tối .
                {
                    tgQuetVe = _kq.ngay.AddHours(_kq.tgQuetVe.TotalHours);
                }
                DateTime tgBatDauTinhTangCa = _kq.ngay.AddHours(_kq.tuGio.TotalHours).AddHours(_kq.denGio.TotalHours);
                if (tgQuetVe >= tgBatDauTinhTangCa) // Gán giờ để tính tiền ngày công.
                {
                    tgQuetVe = tgBatDauTinhTangCa;
                }
                if (_kq.ngay.DayOfWeek == DayOfWeek.Sunday) // Nếu là ca đêm chủ nhật. Đây là của YSS. YS2 chưa fix.Chỉ fix lại là 4h -> 3h30
                {
                    if (_kq.tgDiMuon > 0)
                    {
                        int minutes = (60 - tgQuetDen.Minute) > 30 ? 30 - tgQuetDen.Minute : tgQuetDen.Minute;
                        if (tgQuetDen < _kq.ngay.AddHours(22))
                        {
                            total += _LuongTungNgay / 8 * minutes / 60 * 200 / 100;
                        }
                        else if (tgQuetDen <= _kq.ngay.AddDays(1).AddHours(3.5))
                        {
                            total += _LuongTungNgay / 8 * minutes / 60 * 270 / 100;
                        }

                        tgQuetDen = tgQuetDen.AddMinutes(minutes);
                    }
                    if (_kq.tgVeSom > 0)
                    {
                        int minutes = tgQuetVe.Minute > 30 ? tgQuetVe.Minute - 30 : tgQuetVe.Minute;
                        if (tgQuetVe < _kq.ngay.AddHours(22))
                        {
                            total += _LuongTungNgay / 8 * minutes / 60 * 200 / 100;
                        }
                        else if (tgQuetVe <= _kq.ngay.AddDays(1).AddHours(3.5))
                        {
                            total += _LuongTungNgay / 8 * minutes / 60 * 270 / 100;
                        }
                        tgQuetVe = tgQuetVe.AddMinutes(minutes * -1);
                    }

                    //Trước khi tính tiền: Cho seconds = 0 vì vs các trường hợp quẹt vào 08:00:47 sẽ bị tính sai nếu so sánh 04:00
                    tgQuetVe = tgQuetVe.AddSeconds(-1 * tgQuetVe.Second);
                    tgQuetDen = tgQuetDen.AddSeconds(-1 * tgQuetDen.Second);
                    for (DateTime i = tgQuetDen.AddHours(0.5); i <= tgQuetVe;)
                    {
                        if (i <= _kq.ngay.AddHours(22))
                        {
                            total += _LuongTungNgay / 8 * 0.5 * 200 / 100; // <= 10h PM :100%. 
                        }
                        else if (i <= _kq.ngay.AddDays(1).AddHours(3.5))
                        {
                            total += _LuongTungNgay / 8 * 0.5 * 270 / 100; // 10h PM -> 3:30 AM: 270%. 
                        }
                        else if (i <= _kq.ngay.AddDays(1).AddHours(6))
                        {
                            total += _LuongTungNgay / 8 * 0.5 * 200 / 100; // 3h30 AM -> 6:00 AM: 200%. 
                        }
                        else if (i > _kq.ngay.AddDays(1).AddHours(6))
                        {
                            total += _LuongTungNgay / 8 * 0.5 * 150 / 100;
                        }

                        i = i.AddHours(0.5); // Mỗi lần tăng 0.5 thì + 30ph.
                    }
                }
                else // Nếu là ca đêm ngày thường
                {
                    if (_kq.tgDiMuon > 0)
                    {
                        int minutes = tgQuetDen.Minute > 30 ? 60 - tgQuetDen.Minute : 30 - tgQuetDen.Minute;
                        if (tgQuetDen < _kq.ngay.AddHours(22))
                        {
                            total += _LuongTungNgay / 8 * minutes / 60;
                        }
                        else if (tgQuetDen <= _kq.ngay.AddDays(1).AddHours(3.5))
                        {
                            total += _LuongTungNgay / 8 * minutes / 60 * 130 / 100;
                        }
                        tgQuetDen = tgQuetDen.AddMinutes(minutes);
                    }
                    if (_kq.tgVeSom > 0)
                    {
                        int minutes = tgQuetVe.Minute > 30 ? tgQuetVe.Minute - 30 : tgQuetVe.Minute;
                        if (tgQuetVe < _kq.ngay.AddHours(22))
                        {
                            total += _LuongTungNgay / 8 * minutes / 60;
                        }
                        else if (tgQuetVe <= _kq.ngay.AddDays(1).AddHours(3.5))
                        {
                            total += _LuongTungNgay / 8 * minutes / 60 * 130 / 100;
                        }
                        tgQuetVe = tgQuetVe.AddMinutes(minutes * -1);
                    }
                    //Trước khi tính tiền: Cho seconds = 0 vì vs các trường hợp quẹt vào 08:00:47 sẽ bị tính sai nếu so sánh 04:00
                    tgQuetVe = tgQuetVe.AddSeconds(-1 * tgQuetVe.Second);
                    tgQuetDen = tgQuetDen.AddSeconds(-1 * tgQuetDen.Second);

                    for (DateTime i = tgQuetDen.AddHours(0.5); i <= tgQuetVe;)
                    {
                        if (i <= _kq.ngay.AddHours(22))
                        {
                            total += _LuongTungNgay / 8 * 0.5; // <= 10h PM :100%. 
                        }
                        else if (i <= _kq.ngay.AddDays(1).AddHours(3.5))
                        {
                            total += _LuongTungNgay / 8 * 0.5 * 130 / 100; // 10h PM -> 3h30 AM: 130%. 
                        }
                        else if (i <= _kq.ngay.AddDays(1).AddHours(6))
                        {
                            total += _LuongTungNgay / 8 * 0.5 * 215 / 100; // 3h30 AM -> 6h AM: 215%. 
                        }
                        else if (i > _kq.ngay.AddDays(1).AddHours(6))
                        {
                            total += _LuongTungNgay / 8 * 0.5 * 150 / 100;
                        }
                        i = i.AddHours(0.5); // Mỗi lần tăng 0.5 thì + 30ph.
                    }
                }
            }
            else
            {
                return 0;
            }
            return total;
        }
        private double getTienTangCaCaDem()
        {
            //          YS2
            // 7h30 PM - 10h PM= 100%. 
            // 10h PM -> 3:30 AM: 130%. 
            // 3h30 AM -> 6h AM: 215%. 
            // 6h -> DenGio = 150%. 
            //          YSS
            // 8h PM - 10h PM= 100%. 
            // 10h PM -> 4h AM: 130%. 
            // 4h AM -> 6h AM: 215%. 
            // 6h -> DenGio = 150%. 
            double total = 0;
            if (_kq.tgTinhTangCa > 0)
            {
                TimeSpan tgBatDauTinhTC = _kq.tuGio.Add(_kq.denGio);
                if (tgBatDauTinhTC.Days >= 1)
                {
                    tgBatDauTinhTC = tgBatDauTinhTC.Add(new TimeSpan(tgBatDauTinhTC.Days * -1, 0, 0, 0));
                }

                double soGioTangCa = _kq.tgTinhTangCa;
                if (_kq.ngay.DayOfWeek == DayOfWeek.Sunday) // Nếu là chủ nhật
                {
                    for (double tg = 0.5; tg <= soGioTangCa;)
                    {
                        tgBatDauTinhTC = tgBatDauTinhTC.Add(new TimeSpan(0, 30, 0)); // Mỗi lần tăng 0.5 thì + 30ph.
                        if (tgBatDauTinhTC <= new TimeSpan(3, 30, 0))
                        {
                            total += _LuongTungNgay / 8 * 0.5 * 270 / 100; // 10h PM -> 4:00 AM: 270%. 
                        }
                        else if (tgBatDauTinhTC <= new TimeSpan(6, 0, 0))
                        {
                            total += _LuongTungNgay / 8 * 0.5 * 200 / 100; // 4h AM -> 6h AM: 200%. 
                        }
                        else if (tgBatDauTinhTC <= new TimeSpan(11, 00, 0))
                        {
                            total += _LuongTungNgay / 8 * 0.5 * 150 / 100; //6h AM -> DenGio = 150%.  
                        }
                        tg += 0.5;
                    }
                }
                else // Nếu là ngày thường
                {
                    for (double tg = 0.5; tg <= soGioTangCa;)
                    {
                        tgBatDauTinhTC = tgBatDauTinhTC.Add(new TimeSpan(0, 30, 0)); // Mỗi lần tăng 0.5 thì + 30ph.
                        if (tgBatDauTinhTC <= new TimeSpan(3, 30, 0))
                        {
                            total += _LuongCB1Ngay / 8 * 0.5 * 130 / 100; // 10h PM -> 3h30 AM: 130%. 
                        }
                        else if (tgBatDauTinhTC <= new TimeSpan(6, 0, 0))
                        {
                            total += _LuongCB1Ngay / 8 * 0.5 * 215 / 100; // 3h30 AM -> 6h AM: 215%. 
                        }
                        else if (tgBatDauTinhTC <= new TimeSpan(11, 00, 0))
                        {
                            total += _LuongCB1Ngay / 8 * 0.5 * 150 / 100; //6h AM -> DenGio: 150%.  
                        }
                        tg += 0.5;
                    }
                }
                return total;
            }
            else
                return 0; // Nếu k có TangCa thì trả về 0.

        }
        #endregion

        /// <summary>
        /// đếm số ngày công (trừ chủ nhật)
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static int DemNgayCong(DateTime startDate, DateTime endDate)
        {
            int c = 0;
            while (startDate < endDate)
            {
                if (startDate.DayOfWeek != DayOfWeek.Sunday)
                    c += 1;

                startDate = startDate.AddDays(1);
            }
            return c;
        }
        private dsTinhLuong.tblEmpSalaryRow GetLuongMoi(string empID)
        {
            var rs = _ds.tblEmpSalary.Where(p => p.EmployeeID == empID && p.BeginDate <= kyLuong_DenNgay);
            if (rs.Count() > 0)
            {
                var l = rs.OrderByDescending(p => p.BeginDate).First();
                if (l["BasicSalary"] == DBNull.Value) l["BasicSalary"] = 0;
                if (l["BasicSalary_Ins"] == DBNull.Value) l["BasicSalary_Ins"] = 0;
                return l;
            }
            else
            {
                return null;
            }
        }

        private dsTinhLuong.tblEmpSalaryRow GetLuongCu(string empID, dsTinhLuong.tblEmpSalaryRow luongMoi)
        {
            var rs = _ds.tblEmpSalary.Where(p => p.EmployeeID == empID && p.EndDate >= kyLuong_TuNgay && p.EndDate < kyLuong_DenNgay && p.id != luongMoi.id); // lương cũ thì phải < EndDate
            if (rs.Count() >= 1)
            {
                var l = rs.OrderByDescending(p => p.BeginDate).First();
                if (l["BasicSalary"] == DBNull.Value) l["BasicSalary"] = 0;
                if (l["BasicSalary_Ins"] == DBNull.Value) l["BasicSalary_Ins"] = 0;
                return l;
            }
            else
                return null;
        }

    }
}