using iHRM.Common.Code;
using iHRM.Core.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace iHRM.Core.Controller.QuetThe
{
    public class Helper
    {
        public static DateTime GetStartDateSalaryCycle
        {
            get
            {
                var d = DateTime.Today;
                return new DateTime(d.Year, d.Month, 17).AddMonths(-1);
            }
        }

        public static string GetTrangThai(DataRow dr, int type = 1, bool isWinform = false)
        {
            //int tt_ok = DbHelper.DrGetInt(dr, "tt_ok");
            int tt_leTet = DbHelper.DrGetInt(dr, "tt_leTet");
            int tt_diMuonVeSom = DbHelper.DrGetInt(dr, "tt_diMuonVeSom");
            int tt_nghiPhep = DbHelper.DrGetInt(dr, "tt_nghiPhep");
            int tt_coQuetTay = DbHelper.DrGetInt(dr, "tt_coQuetTay");
            bool tt_chuNhat = DbHelper.DrGetBoolean(dr, "tt_chuNhat") ?? false;
            double kqNgayCong = DbHelper.DrGetFloat(dr, "kqNgayCong");
            double tgTinhTangCa = DbHelper.DrGetFloat(dr, "tgTinhTangCa");

            string s = "";
            if (kqNgayCong > 0)
                s = string.Format("{0:0.##}", kqNgayCong);

            if (tt_leTet > 0)
                s = "LT " + s;
            else if (tt_nghiPhep > 0)
                s = DbHelper.DrGetString(dr, "tt_nghiPhep_Alias") + " " + s;
            if (tt_chuNhat)
                s = "Cn " + s;
            else if (tt_coQuetTay == 1)
                s = "Out";
            else if (tt_coQuetTay == 2)
                s = "In";

            if (tgTinhTangCa > 0)
            {
                if (type == 1)
                    s += string.Format("{1}{0:0.##}", tgTinhTangCa, isWinform ? "\n" : "<br />");
                else if (type == 2)
                    s += string.Format(" ({0:0.##})", tgTinhTangCa);
            }
            return s;
        }
    }
}