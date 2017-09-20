using iHRM.WebPC;
using iHRM.Core.Business;
using iHRM.WebPC.Classes.Helper;
using System;
using System.Data;
using System.Text.RegularExpressions;


public class UrlRewrite
{
    #region common
    public class RouterConst
    {
        public const string Home = "home";
    }

    public static string BoDauTiengViet(string sContent)
    {
        if (sContent == null)
            return "";

        sContent = sContent.Trim(' ', '\r', '\n', '\t', '-');
        sContent = sContent.Replace(" - ", " ");
        sContent = sContent.Replace(' ', '-');
        sContent = sContent.Replace("</br>", "");
        sContent = sContent.Replace("</ br>", "");
        sContent = sContent.Replace("<br />", "");
        sContent = sContent.Replace("<br/>", "");
        string sUTF8Lower = "a|á|à|ả|ã|ạ|ă|ắ|ằ|ẳ|ẵ|ặ|â|ấ|ầ|ẩ|ẫ|ậ|đ|e|é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ|i|í|ì|ỉ|ĩ|ị|o|ó|ò|ỏ|õ|ọ|ô|ố|ồ|ổ|ỗ|ộ|ơ|ớ|ờ|ở|ỡ|ợ|u|ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự|y|ý|ỳ|ỷ|ỹ|ỵ";

        string sUTF8Upper = "A|Á|À|Ả|Ã|Ạ|Ă|Ắ|Ằ|Ẳ|Ẵ|Ặ|Â|Ấ|Ầ|Ẩ|Ẫ|Ậ|Đ|E|É|È|Ẻ|Ẽ|Ẹ|Ê|Ế|Ề|Ể|Ễ|Ệ|I|Í|Ì|Ỉ|Ĩ|Ị|O|Ó|Ò|Ỏ|Õ|Ọ|Ô|Ố|Ồ|Ổ|Ỗ|Ộ|Ơ|Ớ|Ờ|Ở|Ỡ|Ợ|U|Ú|Ù|Ủ|Ũ|Ụ|Ư|Ứ|Ừ|Ử|Ữ|Ự|Y|Ý|Ỳ|Ỷ|Ỹ|Ỵ";

        string sUCS2Lower = "a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|d|e|e|e|e|e|e|e|e|e|e|e|e|i|i|i|i|i|i|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|u|u|u|u|u|u|u|u|u|u|u|u|y|y|y|y|y|y";

        string sUCS2Upper = "A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|D|E|E|E|E|E|E|E|E|E|E|E|E|I|I|I|I|I|I|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|U|U|U|U|U|U|U|U|U|U|U|U|Y|Y|Y|Y|Y|Y";

        string[] aUTF8Lower = sUTF8Lower.Split(new Char[] { '|' });

        string[] aUTF8Upper = sUTF8Upper.Split(new Char[] { '|' });

        string[] aUCS2Lower = sUCS2Lower.Split(new Char[] { '|' });

        string[] aUCS2Upper = sUCS2Upper.Split(new Char[] { '|' });

        Int32 nLimitChar;

        nLimitChar = aUTF8Lower.GetUpperBound(0);

        for (int i = 1; i <= nLimitChar; i++)
        {

            sContent = sContent.Replace(aUTF8Lower[i], aUCS2Lower[i]);

            sContent = sContent.Replace(aUTF8Upper[i], aUCS2Upper[i]);

        }
        string sUCS2regex = @"[A-Za-z0-9- ]";
        string sEscaped = new Regex(sUCS2regex, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.ExplicitCapture).Replace(sContent, string.Empty);
        if (string.IsNullOrEmpty(sEscaped))
            return sContent;
        sEscaped = sEscaped.Replace("[", "\\[");
        sEscaped = sEscaped.Replace("]", "\\]");
        sEscaped = sEscaped.Replace("^", "\\^");
        string sEscapedregex = @"[" + sEscaped + "]";

        return new Regex(sEscapedregex, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.ExplicitCapture).Replace(sContent, string.Empty).ToLower();
    }

    #endregion

    public static string Gen_DanhMucBaiViet(DataRow dr)
    {
        if (dr.Table.Columns.Contains("dmIdx"))
            return string.Format("/{0}-dm{1}.html", DbHelper.DrGet(dr, "ma"), DbHelper.DrGet(dr, "dmIdx"));
        return string.Format("/{0}-dm{1}.html", DbHelper.DrGet(dr, "ma"), DbHelper.DrGet(dr, "idx"));
    }

    public static string Gen_BaiViet(DataRow dr)
    {
        string dm = DbHelper.DrGetString(dr, "DM_ma");
        if (!string.IsNullOrWhiteSpace(dm))
            dm = dm+="/";
        return string.Format("/{0}{1}-bv{2}.html", dm, DbHelper.DrGet(dr, "maBV"), DbHelper.DrGet(dr, "idx"));
    }
}
