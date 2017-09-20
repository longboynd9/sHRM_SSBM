using iHRM.Common.Code;
using iHRM.Common.DungChung;
using iHRM.Core;
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
    public class TinhLuongHelper_1dong
    {
        //dùng chung
        dsTinhLuong _ds = null;
        public int _soNgayCongTrongThang = 26;
        public DateTime kyLuong_TuNgay, kyLuong_DenNgay;

        //dùng riêng
        dsTinhLuong.p_tinhLuong_GetAllKetQuaQuetTheRow _kq;
        List<dsTinhLuong.tbCaLam_TinhTangCaRow> lstTinhTC;
        public double _Luong1Ngay;
        public double _LuongTungNgay;
        public bool _LaLuongCu;

        public dsTinhLuong.tblEmpSalaryRow luongMoi;
        public dsTinhLuong.tblEmpSalaryRow luongCu;

        public TinhLuongHelper_1dong(dsTinhLuong ds, DateTime tuNgay, DateTime denNgay, string EmployeeID)
        {
            this._ds = ds;
            _soNgayCongTrongThang = Ham.DemNgayCong(tuNgay, denNgay);
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
                        _Luong1Ngay = (e.BasicSalary ?? 0) / 26;
                    }
                }
                else
                {
                    _Luong1Ngay = DbHelper.DrGetDouble(kq1, "BasicSalary") / 26;
                }
            }
            else
            {
                _Luong1Ngay = DbHelper.DrGetDouble(luongMoi, "BasicSalary") / 26;
            }

        }

        public void Set_KQQT(dsTinhLuong.p_tinhLuong_GetAllKetQuaQuetTheRow kq)
        {
            this._kq = kq;

            _LaLuongCu = (luongCu != null && kq.ngay >= luongCu.BeginDate && kq.ngay <= luongCu.EndDate);

            if (_LaLuongCu)
            {
                _LuongTungNgay = DbHelper.DrGetDouble(luongCu, "BasicSalary") / 26;
            }
            else
            {
                _LuongTungNgay = _Luong1Ngay;
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
                return _ds.tbDangKyVangMat.Where(i => i.coHuongLuong == 1 && i.idKetQuaQuetThe == _kq.id && i.EmployeeID == _kq.EmployeeID
                    && i.lydo == (int)Enums.eLyDoNghi.NghiPhepNam
                ).Sum(i => TinhCongPhep(i));

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

            //return (_kq["kqNgayCong"] == DBNull.Value ? 0 : Math.Round(_kq.kqNgayCong, 2)) + (_kq.tt_leTet == 1 ? 1 : 0);
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
                    return getTienNgayCongCaDem();
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
                            return _LuongTungNgay / 8 * (_kq.kqNgayCong / 3 * 8 * 300 / 100); //fixed / 8
                        }
                        else
                            return _LuongTungNgay / 8 * (_kq.kqNgayCong / 3 * 8 * 300 / 100); //fixed / 8
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
                            if (tinhLuongCu)
                            {
                                sum += soTieng * _LuongTungNgay / 8 * it.heSoLuong / 100; //fixed / 8
                            }
                            else
                                sum += soTieng * _LuongTungNgay / 8 * it.heSoLuong / 100; //fixed / 8
                            tgTinhTangCa -= soTieng;
                            if (tgTinhTangCa <= 0)
                                break;
                        }
                        return sum;
                    }
                }

            }
        }
        private double getTienNgayCongCaDem()
        {
            // 7h30 PM - 10h PM= 100%. 
            // 10h PM -> 3:30 AM: 130%. 
            // 3h30 AM -> 5h30 AM: 215%. 
            // 5h30 -> DenGio = 150%.  
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

                if (_kq.tgDiMuon > 0)
                {
                    int minutes = tgQuetDen.Minute > 30 ? tgQuetDen.Minute - 30 : tgQuetDen.Minute;
                    if (tgQuetDen < _kq.ngay.AddHours(10))
                    {
                        total += _LuongTungNgay / 8 * minutes / 60;
                    }
                    else if (tgQuetDen <= _kq.ngay.AddDays(1).AddHours(3.5))
                    {
                        total += _LuongTungNgay / 8 * minutes / 60 * 130 / 100;
                    }
                    tgQuetDen.AddMinutes(minutes * -1);
                }
                if (_kq.tgVeSom > 0)
                {
                    int minutes = tgQuetVe.Minute > 30 ? tgQuetVe.Minute - 30 : tgQuetVe.Minute;
                    if (tgQuetVe < _kq.ngay.AddHours(10))
                    {
                        total += _LuongTungNgay / 8 * minutes / 60;
                    }
                    else if (tgQuetVe <= _kq.ngay.AddDays(1).AddHours(3.5))
                    {
                        total += _LuongTungNgay / 8 * minutes / 60 * 130 / 100;
                    }
                    tgQuetVe.AddMinutes(minutes * -1);
                }

                for (DateTime i = tgQuetDen.AddHours(0.5); i <= tgQuetVe; )
                {
                    if (i <= _kq.ngay.AddHours(10.5))
                    {
                        total += _LuongTungNgay / 8 * 0.5; // <= 10h PM :100%. 
                    }
                    else if (i <= _kq.ngay.AddDays(1).AddHours(3.5))
                    {
                        total += _LuongTungNgay / 8 * 0.5 * 130 / 100; // 10h PM -> 3:30 AM: 130%. 
                    }
                    i = tgQuetDen.AddHours(0.5); // Mỗi lần tăng 0.5 thì + 30ph.
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
                TimeSpan tgBatDauTinhTC = _kq.denGio;
                double soGioTangCa = _kq.tgTinhTangCa;
                for (double tg = 0.5; tg <= soGioTangCa; )
                {
                    tgBatDauTinhTC.Add(new TimeSpan(0, 30, 0)); // Mỗi lần tăng 0.5 thì + 30ph.
                    if (tgBatDauTinhTC <= new TimeSpan(3, 30, 0))
                    {
                        total += _LuongTungNgay / 8 * 0.5 * 130 / 100; // 10h PM -> 3:30 AM: 130%. 
                    }
                    else if (tgBatDauTinhTC > new TimeSpan(3, 30, 0) && tgBatDauTinhTC <= new TimeSpan(5, 30, 0))
                    {
                        total += _LuongTungNgay / 8 * 0.5 * 215 / 100; // 3h30 AM -> 5h30 AM: 215%. 
                    }
                    else if (tgBatDauTinhTC > new TimeSpan(5, 30, 0) && tgBatDauTinhTC <= new TimeSpan(11, 00, 0))
                    {
                        total += _LuongTungNgay / 8 * 0.5 * 150 / 100; //5h30 -> DenGio = 150%.  
                    }
                    tg += 0.5;
                }
                return total;
            }
            else
                return 0; // Nếu k có TangCa thì trả về 0.

        }

        void CalcLstTinhCaLam()
        {
            lstTinhTC = _ds.tbCaLam_TinhTangCa.Where(i => i.idCaLamViec == _kq.idCaLam).OrderBy(i => i.idx).ToList();
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