using iHRM.Core.Business.DbObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHRM.Core.Controller.QuetThe
{
    public class DkVangMat : LogicBase
    {
        Business.Logic.ChamCong.calam logic = new Business.Logic.ChamCong.calam();

        public LogicResult DkCaNhan(string empID, DateTime tuNgay, DateTime denNgay, int caXinNghi, int lyDo, string ghiChu, int coHuongLuong, bool coTinhChuyenCan = true)
        {
            LogicResult lr = new LogicResult();
            try
            {
                var db = new dcDatabaseDataContext(Business.Provider.ConnectionString);
                var nv = db.tblEmployees.SingleOrDefault(p => p.EmployeeID == empID);
                if (nv == null)
                {
                    lr.msg = string.Format("Mã nhân viên không đúng! ({0})", empID);
                    lr.status = LogicResultStatus.fail;
                    return lr;
                }

                int day = Convert.ToInt32((denNgay - tuNgay).TotalDays);
                int totalRecord = 0;
                string message = "";

                //check phép năm
                if (lyDo == 4)
                {
                    var lst = db.tbKetQuaQuetThes.Where(i => i.EmployeeID == nv.EmployeeID && i.ngay >= tuNgay && i.ngay <= denNgay).ToList();
                    //.Sum(i => (h >= (i.tbCaLamViec == null ? 8 : i.tbCaLamViec.soTiengTinhCa)) ? 1 : (h / (i.tbCaLamViec == null ? 8 : i.tbCaLamViec.soTiengTinhCa)));
                    double c1 = (lst.Count * (caXinNghi == 3 ? 1 : 0.5));

                    if (nv.AnnualLeave < c1 || nv.AnnualLeave == null)
                    {
                        lr.msg = string.Format("Nhân viên [{2}], Không đủ phép năm!<br />Phép năm hiện tại: {0}, Phép đăng ký: {1}", nv.AnnualLeave, c1, nv.EmployeeID);
                        lr.status = LogicResultStatus.fail;
                        return lr;
                    }
                }

                //đăng ký từng ngày
                for (int i = 0; i <= day; i++)
                {
                    DateTime ngay = tuNgay.AddDays(i);

                    var ketQuaQT = db.tbKetQuaQuetThes.SingleOrDefault(p => p.EmployeeID == empID && p.ngay == ngay);
                    if (ketQuaQT != null) // Nếu đã đăng ký ca làm
                    {
                        var ret = logic.DangKyVangMat2(empID,
                            ngay,
                            caXinNghi,
                            lyDo,
                            ghiChu,
                            coHuongLuong,
                            coTinhChuyenCan: coTinhChuyenCan
                        );
                        totalRecord += ret.ReturnValue;
                        message += ret.Message;
                    }
                    else
                    {
                        message += string.Format("\nNgày {0:dd/MM/yyyy} Nhân viên [{1}] chưa đăng ký ca làm!", ngay, empID);
                    }
                }
                
                lr.msg = message;
                lr.status = LogicResultStatus.success;
                lr.data = totalRecord;
                return lr;
            }
            catch (Exception ex)
            {
                lr.msg = ex.Message;
                lr.status = LogicResultStatus.fail;
                return lr;
            }
        }
    }
}
