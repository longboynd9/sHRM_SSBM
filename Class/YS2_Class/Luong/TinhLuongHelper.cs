using iHRM.Common.Code;
using iHRM.Common.DungChung;
using iHRM.Core.Business;
using iHRM.Core.Business.Logic.Luong;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iHRM.Win.ExtClass.Luong
{
    public class TinhLuongHelper
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

        public TinhLuongHelper(dsTinhLuong ds, DateTime tuNgay, DateTime denNgay, string EmployeeID)
        {
            this._ds = ds;
            _soNgayCongTrongThang = Ham.DemNgayCong(tuNgay, denNgay) > 26 ? 26 : Ham.DemNgayCong(tuNgay, denNgay);

            kyLuong_TuNgay = tuNgay;
            kyLuong_DenNgay = denNgay;

            luongMoi = GetLuongMoi(EmployeeID);
            luongCu = GetLuongCu(EmployeeID, luongMoi);
            if (luongCu != null && luongCu.EndDate < tuNgay)
                luongCu = null;

            if (luongMoi == null)
            {
                var kq1 = _ds.p_tinhLuong_GetAllKetQuaQuetThe.FirstOrDefault(i => i.EmployeeID == EmployeeID);
                if (kq1 == null)
                {
                    var db1 = new iHRM.Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);
                    var e = db1.tblEmployees.FirstOrDefault(i => i.EmployeeID == EmployeeID);
                    if (e != null)
                    {
                        _Luong1Ngay = (e.BasicSalary ?? 0 + e.RegularAllowance ?? 0) / _soNgayCongTrongThang;
                    }
                }
                else
                {
                    _Luong1Ngay = (DbHelper.DrGetDouble(kq1, "BasicSalary") + DbHelper.DrGetDouble(kq1, "RegularAllowance")) / _soNgayCongTrongThang;
                }
            }
            else
            {
                _Luong1Ngay = (DbHelper.DrGetDouble(luongMoi, "BasicSalary") + DbHelper.DrGetDouble(luongMoi, "BasicSalary_Ins")) / _soNgayCongTrongThang;
            }
            _LuongCBCu = DbHelper.DrGetDouble(luongCu, "BasicSalary");
            _LuongPCCu = DbHelper.DrGetDouble(luongCu, "BasicSalary_Ins");
            _LuongCBMoi = DbHelper.DrGetDouble(luongMoi, "BasicSalary");
            _LuongPCMoi = DbHelper.DrGetDouble(luongMoi, "BasicSalary_Ins");

        }

        public void Set_KQQT(dsTinhLuong.p_tinhLuong_GetAllKetQuaQuetTheRow kq)
        {
            this._kq = kq;

            _LaLuongCu = (luongCu != null && kq.ngay >= luongCu.BeginDate && kq.ngay <= luongCu.EndDate);

            if (_LaLuongCu)
            {
                _LuongTungNgay = (DbHelper.DrGetDouble(luongCu, "BasicSalary") + DbHelper.DrGetDouble(luongCu, "BasicSalary_Ins")) / _soNgayCongTrongThang;
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

            if (type == 1 && (_kq.tt_nghiPhep > 0 || _kq.tt_leTet > 0 || _kq.tt_chuNhat))
                return 0;

            if (type == 2)
            {
                return _ds.tbDangKyVangMat.Where(i => i.coHuongLuong == 1 && i.idKetQuaQuetThe == _kq.id && i.EmployeeID == _kq.EmployeeID
                  && i.lydo == (int)Enums.eLyDoNghi.NghiPhepNam
              ).Sum(i => TinhCongPhep(i));
            }
            if (type == 5)
                return _ds.tbDangKyVangMat.Where(i => i.coHuongLuong == 1 && i.idKetQuaQuetThe == _kq.id && i.EmployeeID == _kq.EmployeeID
                    && i.lydo != (int)Enums.eLyDoNghi.NghiPhepNam
                ).Sum(i => TinhCongPhep(i));

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
                    if (_kq.caDem != null && _kq.caDem)
                    {
                        return (Math.Round(_kq.kqNgayCong, 2) + (_kq.tt_leTet == 1 ? 1 : 0));
                    }
                    else
                        return 0;
                }
                else
                {
                    if (_kq.caDem != null && _kq.caDem)
                    {
                        return 0;
                    }
                    else
                        return (Math.Round(_kq.kqNgayCong, 2) + (_kq.tt_leTet == 1 ? 1 : 0));
                }
            }
        }
        private double TinhCongPhep(dsTinhLuong.tbDangKyVangMatRow i)
        {
            if (i["denGio"] == DBNull.Value)
                i["denGio"] = new TimeSpan();

            if (i["tuGio"] == DBNull.Value)
                i["tuGio"] = new TimeSpan();

            TimeSpan denGio = new TimeSpan();
            if (i.denGio < i.tuGio)
            {
                denGio = i.denGio.Add(new TimeSpan(24, 0, 0));
            }
            else
            {
                denGio = i.denGio;
            }
            double soTieng = (denGio - i.tuGio).TotalHours;
            if (soTieng < 0)
                soTieng = 0;

            if (soTieng > i.soTiengTinhCa)
                soTieng = i.soTiengTinhCa;

            return Math.Round(soTieng / i.soTiengTinhCa, 2);
        }

        public double TinhTienNgayCong(int type = 0, bool tinhLuongCu = false, bool tinhCaDem = false)
        {
            if (_LaLuongCu != tinhLuongCu)
                return 0;
            if (tinhCaDem)
            {
                if (_kq.caDem != null && _kq.caDem)
                {
                    if (type == 1)
                    {
                        return getTienNgayCongCaDem();
                    }
                    else
                    {
                        double ngayCong = TinhNgayCong(type, tinhLuongCu);
                        if (_kq["heSoLuong"] == DBNull.Value || _kq.heSoLuong == 0)
                            return ngayCong * _LuongTungNgay;
                        return ngayCong * _LuongTungNgay * _kq.heSoLuong / 100;
                    }
                }
                else
                    return 0;
            }
            else
            {
                if (_kq.caDem != null && _kq.caDem)
                {
                    return 0;
                }
                else
                {
                    double ngayCong = TinhNgayCong(type, tinhLuongCu);
                    if (_kq["heSoLuong"] == DBNull.Value || _kq.heSoLuong == 0)
                        return ngayCong * _LuongTungNgay;
                    return ngayCong * _LuongTungNgay * _kq.heSoLuong / 100;
                }
            }
        }
        public double TinhThuongBuaToi(dsTinhLuong ds, dsTinhLuong.tbBangLuongThangRow r, int type = 10, bool tinhLuongCu = false)
        {
            if (_LaLuongCu != tinhLuongCu)
                return 0;
            double tgTinhTangCa = _kq["tgTinhTangCa"] == DBNull.Value ? 0 : _kq.tgTinhTangCa;

            if (_kq.caDem == false && (_kq.tuGio == new TimeSpan(7, 30, 0) || _kq.tuGio == new TimeSpan(8, 0, 0)) && tgTinhTangCa >= 2.5 && tgTinhTangCa <= 3.5)
            {
                if (tinhLuongCu)
                {
                    return 0.5 * (_LuongCBCu / _soNgayCongTrongThang) / 8 * 150 / 100; //fixed / 8
                }
                else
                    return 0.5 * (_LuongCBMoi / _soNgayCongTrongThang) / 8 * 150 / 100; //fixed / 8
            }
            if (_kq.caDem && tgTinhTangCa >= 2)
            {
                if (tinhLuongCu)
                {
                    return 0.5 * (_LuongCBCu / _soNgayCongTrongThang) / 8 * 215 / 100; //fixed / 8
                }
                else
                    return 0.5 * (_LuongCBMoi / _soNgayCongTrongThang) / 8 * 215 / 100; //fixed / 8
            }

            return 0;
        }
        public double TinhGioTangCa(int type = 0, bool tinhLuongCu = false, bool tinhCaDem = false)
        {
            if (_LaLuongCu != tinhLuongCu)
                return 0;

            double tgTinhTangCa = _kq["tgTinhTangCa"] == DBNull.Value ? 0 : _kq.tgTinhTangCa;
            if (tgTinhTangCa == 0 && _kq.tt_leTet == 0)
                return 0;

            if (_kq.tt_nghiPhep > 0)
                return 0;

            if (type == 1 && (_kq.tt_leTet > 0 || _kq.tt_chuNhat))
                return 0;

            if (type == 2 && !_kq.tt_chuNhat) //chu nhat
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
                        return _kq.kqNgayCong / 3 * 8;
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
                    if (_kq.caDem != null && _kq.caDem)
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
                    if (_kq.caDem != null && _kq.caDem)
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
            if (tgTinhTangCa == 1.9)
            {
                tgTinhTangCa = 2;
            }
            if (tgTinhTangCa == 0 && _kq.tt_leTet == 0)
                return 0;

            if (_kq.tt_nghiPhep > 0)
                return 0;

            if (type == 1 && (_kq.tt_leTet > 0 || _kq.tt_chuNhat))
                return 0;

            if (type == 2 && !_kq.tt_chuNhat) //chu nhat
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
                    {
                        if (tinhLuongCu)
                        {
                            return (_LuongCBCu + _LuongPCCu / _soNgayCongTrongThang) / 8 * (_kq.kqNgayCong / 3 * 8 * 300 / 100); //fixed / 8
                        }
                        else
                            return (_LuongCBMoi + _LuongPCMoi / _soNgayCongTrongThang) / 8 * (_kq.kqNgayCong / 3 * 8 * 300 / 100); //fixed / 8
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
                    if (_kq.caDem != null && _kq.caDem)
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
                    if (_kq.caDem != null && _kq.caDem)
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
                            if (type != 2 && type != 3)
                            {
                                if (tinhLuongCu)
                                {
                                    sum += soTieng * (_LuongCBCu / _soNgayCongTrongThang) / 8 * it.heSoLuong / 100; //fixed / 8
                                }
                                else
                                    sum += soTieng * (_LuongCBMoi / _soNgayCongTrongThang) / 8 * it.heSoLuong / 100; //fixed / 8
                            }
                            else // Nếu là ngày chủ nhật or lễ tết
                            {
                                if (tinhLuongCu)
                                {
                                    sum += soTieng * ((_LuongCBCu + _LuongPCCu) / _soNgayCongTrongThang) / 8 * it.heSoLuong / 100; //fixed / 8
                                }
                                else
                                    sum += soTieng * ((_LuongCBMoi + _LuongPCMoi) / _soNgayCongTrongThang) / 8 * it.heSoLuong / 100; //fixed / 8
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
            // 7h30 PM - 10h PM= 100%. 
            // 10h PM -> 3:30 AM: 130%. 
            // 3h30 AM -> 5h30 AM: 215%. 
            // 5h30 -> DenGio = 150%.  
            double total = 0;
            if (!_kq.IskqNgayCongNull() && _kq.kqNgayCong > 0)
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

                for (DateTime i = tgQuetDen.AddHours(0.5); i <= tgQuetVe; )
                {
                    if (i <= _kq.ngay.AddHours(22))
                    {
                        total += _LuongTungNgay / 8 * 0.5; // <= 10h PM :100%. 
                    }
                    else if (i <= _kq.ngay.AddDays(1).AddHours(3.5))
                    {
                        total += _LuongTungNgay / 8 * 0.5 * 130 / 100; // 10h PM -> 3:30 AM: 130%. 
                    }
                    i = i.AddHours(0.5); // Mỗi lần tăng 0.5 thì + 30ph.
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
            // 7h30 PM - 10h PM= 100%. 
            // 10h PM -> 3:30 AM: 130%. 
            // 3h30 AM -> 5h30 AM: 215%. 
            // 5h30 -> DenGio = 150%.  
            double total = 0;
            if (_kq.tgTinhTangCa > 0)
            {
                TimeSpan tgBatDauTinhTC = _kq.tuGio.Add(_kq.denGio);
                if (tgBatDauTinhTC.Days >= 1)
                {
                    tgBatDauTinhTC = tgBatDauTinhTC.Add(new TimeSpan(tgBatDauTinhTC.Days * -1, 0, 0, 0));
                }

                double soGioTangCa = _kq.tgTinhTangCa == 1.9 ? 2 : _kq.tgTinhTangCa;
                for (double tg = 0.5; tg <= soGioTangCa; )
                {
                    tgBatDauTinhTC = tgBatDauTinhTC.Add(new TimeSpan(0, 30, 0)); // Mỗi lần tăng 0.5 thì + 30ph.
                    if (tgBatDauTinhTC <= new TimeSpan(3, 30, 0))
                    {
                        total += _LuongCB1Ngay / 8 * 0.5 * 130 / 100; // 10h PM -> 3:30 AM: 130%. 
                    }
                    else if (tgBatDauTinhTC > new TimeSpan(3, 30, 0) && tgBatDauTinhTC <= new TimeSpan(5, 30, 0))
                    {
                        total += _LuongCB1Ngay / 8 * 0.5 * 215 / 100; // 3h30 AM -> 5h30 AM: 215%. 
                    }
                    else if (tgBatDauTinhTC > new TimeSpan(5, 30, 0) && tgBatDauTinhTC <= new TimeSpan(11, 00, 0))
                    {
                        total += _LuongCB1Ngay / 8 * 0.5 * 150 / 100; //5h30 -> DenGio = 150%.  
                    }
                    tg += 0.5;
                }
                return total;
            }
            else
                return 0; // Nếu k có TangCa thì trả về 0.

        }
        #endregion

        private dsTinhLuong.tblEmpSalaryRow GetLuongMoi(string empID)
        {
            var l = _ds.tblEmpSalary.Where(i => i.EmployeeID == empID &&
                ((i.BeginDate <= kyLuong_TuNgay && i.EndDate >= kyLuong_TuNgay) || (i.BeginDate <= kyLuong_DenNgay.AddDays(-1) && i.EndDate >= kyLuong_DenNgay.AddDays(-1)))
            ).OrderByDescending(i => i.DateChange).FirstOrDefault();
            if (l != null)
            {
                if (l["BasicSalary"] == DBNull.Value) l["BasicSalary"] = 0;
                if (l["BasicSalary_Ins"] == DBNull.Value) l["BasicSalary_Ins"] = 0;
            }
            return l;
        }

        private dsTinhLuong.tblEmpSalaryRow GetLuongCu(string empID, dsTinhLuong.tblEmpSalaryRow luongMoi)
        {
            var l = _ds.tblEmpSalary.Where(i => i.EmployeeID == empID &&
                ((i.BeginDate <= kyLuong_TuNgay && i.EndDate >= kyLuong_TuNgay) || (i.BeginDate <= kyLuong_DenNgay.AddDays(-1) && i.EndDate >= kyLuong_DenNgay.AddDays(-1)))
                && i.id != (luongMoi == null ? new Guid() : luongMoi.id)
            ).OrderByDescending(i => i.DateChange).FirstOrDefault();
            if (l != null)
            {
                if (l["BasicSalary"] == DBNull.Value) l["BasicSalary"] = 0;
                if (l["BasicSalary_Ins"] == DBNull.Value) l["BasicSalary_Ins"] = 0;
            }
            return l;
        }

    }
}