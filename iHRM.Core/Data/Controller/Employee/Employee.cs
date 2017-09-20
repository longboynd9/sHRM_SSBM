using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace iHRM.Core.Controller.QuetThe
{
    public class Employee : LogicBase
    {
        public LogicProgress lp = new LogicProgress();
        Business.Logic.ChamCong.calam logic = new Business.Logic.ChamCong.calam();
        Business.Logic.Employee.Emp logic_Emp = new Business.Logic.Employee.Emp();

        public LogicResult DkCaNhan(string empID, DateTime tuNgay, DateTime denNgay, Guid idCaLam, bool regSunday, int? dkLamThem = null, int? hsLuong = null)
        {
            LogicResult lr = new LogicResult();

            var count_day = (denNgay - tuNgay).TotalDays;
            if (count_day < 0)
            {
                lr.status = LogicResultStatus.fail;
                lr.msg = Lng.QuetThe_DKCaLam.msg_1;
                return lr;
            }

            string WeekHoliday = "," + Business.Logic.AllLogic.SysPa_Get("WeekHoliday") + ",";
            DateTime d;
            int rowAffect = 0;
            string msg = "";

            //reg progress...
            lp.MaxValue = (int)count_day;
            lp.OutMessage("Đang đăng ký..");

            for (int i = 0; i <= count_day; i++)
            {
                d = tuNgay.AddDays(i);
                Core.Business.Base.ExecuteResult ii = null;
                if (WeekHoliday.IndexOf("," + (int)d.DayOfWeek + ",") >= 0) //nếu vào ngày nghỉ
                {
                    if (regSunday)
                        ii = logic.DangKyCaLam(empID, d, idCaLam, 1, 200);
                }
                else
                {
                    ii = logic.DangKyCaLam(empID, d, idCaLam, dkLamThem, hsLuong);
                }

                lp.CurrentValue = i; //report progress
                if (ii != null)
                {
                    rowAffect += ii.NumberOfRowAffected < 0 ? 0 : ii.NumberOfRowAffected;
                    if (!string.IsNullOrWhiteSpace(ii.Message))
                    {
                        string s = string.Format("Ngày {0:dd/MM}: {1}<br />", d, ii.Message);
                        msg += s;
                        lp.OutMessage(s); //out msg progress
                    }
                }
            }

            lp.OutMessage(string.Format("Complete! ({0} row afected)", rowAffect)); //complete progress
            lr.msg = msg;
            lr.status = LogicResultStatus.success;
            lr.data = rowAffect;
            return lr;
        }

        public LogicResult DkNhom1(int idNhom1, DateTime tuNgay, DateTime denNgay, Guid idCaLam, bool regSunday, int? dkLamThem = null, int? hsLuong = null)
        {
            LogicResult lr = new LogicResult();

            var count_day = (denNgay - tuNgay).TotalDays;
            if (count_day < 0)
            {
                lr.status = LogicResultStatus.fail;
                lr.msg = Lng.QuetThe_DKCaLam.msg_1;
                return lr;
            }

            //reg progress...
            lp.MaxValue = (int)count_day;
            lp.OutMessage("Đang đăng ký..");

            string WeekHoliday = "," + Business.Logic.AllLogic.SysPa_Get("WeekHoliday") + ",";
            DateTime d;
            int rowAffect = 0;
            for (int i = 0; i <= count_day; i++)
            {
                d = tuNgay.AddDays(i);
                if (WeekHoliday.IndexOf("," + (int)d.DayOfWeek + ",") >= 0) //nếu vào ngày nghỉ
                {
                    if (regSunday)
                        rowAffect += logic.DangKyCaLam_nhom1(idNhom1, d, idCaLam, 1, 200);
                }
                else
                {
                    rowAffect += logic.DangKyCaLam_nhom1(idNhom1, d, idCaLam, dkLamThem, hsLuong);
                }
                lp.CurrentValue = i; //report progress
            }

            lp.OutMessage(string.Format("Complete! ({0} row afected)", rowAffect)); //complete progress
            lr.status = LogicResultStatus.success;
            lr.data = rowAffect;
            return lr;
        }

        public LogicResult DkTapThe(string depID, DateTime tuNgay, DateTime denNgay, Guid idCaLam, bool regSunday, int? dkLamThem = null, int? hsLuong = null)
        {
            LogicResult lr = new LogicResult();

            var count_day = (denNgay - tuNgay).TotalDays;
            if (count_day < 0)
            {
                lr.status = LogicResultStatus.fail;
                lr.msg = Lng.QuetThe_DKCaLam.msg_1;
                return lr;
            }

            //reg progress...
            lp.MaxValue = (int)count_day;
            lp.OutMessage("Đang đăng ký..");

            string WeekHoliday = "," + Business.Logic.AllLogic.SysPa_Get("WeekHoliday") + ",";
            DateTime d;
            int rowAffect = 0;
            for (int i = 0; i <= count_day; i++)
            {
                d = tuNgay.AddDays(i);
                if (WeekHoliday.IndexOf("," + (int)d.DayOfWeek + ",") >= 0) //nếu vào ngày nghỉ
                {
                    if (regSunday)
                        rowAffect += logic.DangKyCaLam_tapThe(depID, d, idCaLam, 1, 200);
                }
                else
                {
                    rowAffect += logic.DangKyCaLam_tapThe(depID, d, idCaLam, dkLamThem, hsLuong);
                }
                lp.CurrentValue = i; //report progress
                //System.Threading.Thread.Sleep(300);
            }

            lp.OutMessage(string.Format("Complete! ({0} row afected)", rowAffect)); //complete progress
            lr.status = LogicResultStatus.success;
            lr.data = rowAffect;
            return lr;
        }
    }
}
