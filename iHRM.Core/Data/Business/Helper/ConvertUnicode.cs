using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iHRM.Core.Business.Helper
{
    public class ConvertUnicode
    {
        public string TCVN3toVNI(string vnstr)
        {
            string tempTCVN3toVNI = null;
            string c = null;
            long i = 0;
            //INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of Len(vnstr) for every iteration:
            long tempVar = vnstr.Length;
            for (i = 1; i <= tempVar; i++)
            {
                c = vnstr.Substring((int)(i - 1), 1);
                switch (c)
                {
                    case "a":
                        c = "a";
                        break;
                    case "¸":
                        c = "aù";
                        break;
                    case "µ":
                        c = "aø";
                        break;
                    case "¶":
                        c = "aû";
                        break;
                    case "·":
                        c = "aõ";
                        break;
                    case "¹":
                        c = "aï";
                        break;
                    case "¨":
                        c = "aê";
                        break;
                    case "¾":
                        c = "aé";
                        break;
                    case "»":
                        c = "aè";
                        break;
                    case "¼":
                        c = "aú";
                        break;
                    case "½":
                        c = "aü";
                        break;
                    case "Æ":
                        c = "aë";
                        break;
                    case "©":
                        c = "aâ";
                        break;
                    case "Ê":
                        c = "aá";
                        break;
                    case "Ç":
                        c = "aà";
                        break;
                    case "È":
                        c = "aå";
                        break;
                    case "É":
                        c = "aã";
                        break;
                    case "Ë":
                        c = "aä";
                        break;
                    case "e":
                        c = "e";
                        break;
                    case "Ð":
                        c = "eù";
                        break;
                    case "Ì":
                        c = "eø";
                        break;
                    case "Î":
                        c = "eû";
                        break;
                    case "Ï":
                        c = "eõ";
                        break;
                    case "Ñ":
                        c = "eï";
                        break;
                    case "ª":
                        c = "eâ";
                        break;
                    case "Õ":
                        c = "eá";
                        break;
                    case "Ò":
                        c = "eà";
                        break;
                    case "Ó":
                        c = "eå";
                        break;
                    case "Ô":
                        c = "eã";
                        break;
                    case "Ö":
                        c = "eä";
                        break;
                    case "o":
                        c = "o";
                        break;
                    case "ã":
                        c = "où";
                        break;
                    case "ß":
                        c = "oø";
                        break;
                    case "á":
                        c = "oû";
                        break;
                    case "â":
                        c = "oõ";
                        break;
                    case "ä":
                        c = "oï";
                        break;
                    case "«":
                        c = "oâ";
                        break;
                    case "è":
                        c = "oá";
                        break;
                    case "å":
                        c = "oà";
                        break;
                    case "æ":
                        c = "oå";
                        break;
                    case "ç":
                        c = "oã";
                        break;
                    case "é":
                        c = "oä";
                        break;
                    case "¬":
                        c = "ô";
                        break;
                    case "í":
                        c = "ôù";
                        break;
                    case "ê":
                        c = "ôø";
                        break;
                    case "ë":
                        c = "ôû";
                        break;
                    case "ì":
                        c = "ôõ";
                        break;
                    case "î":
                        c = "ôï";
                        break;
                    case "i":
                        c = "i";
                        break;
                    case "Ý":
                        c = "í";
                        break;
                    case "×":
                        c = "ì";
                        break;
                    case "Ø":
                        c = "æ";
                        break;
                    case "Ü":
                        c = "ó";
                        break;
                    case "Þ":
                        c = "ò";
                        break;
                    case "u":
                        c = "u";
                        break;
                    case "ó":
                        c = "uù";
                        break;
                    case "ï":
                        c = "uø";
                        break;
                    case "ñ":
                        c = "uû";
                        break;
                    case "ò":
                        c = "uõ";
                        break;
                    case "ô":
                        c = "uï";
                        break;
                    case "­":
                        c = "ö";
                        break;
                    case "ø":
                        c = "öù";
                        break;
                    case "õ":
                        c = "uø";
                        break;
                    case "ö":
                        c = "öû";
                        break;
                    case "÷":
                        c = "öõ";
                        break;
                    case "ù":
                        c = "öï";
                        break;
                    case "y":
                        c = "y";
                        break;
                    case "ý":
                        c = "yù";
                        break;
                    case "ú":
                        c = "yø";
                        break;
                    case "û":
                        c = "yû";
                        break;
                    case "ü":
                        c = "yõ";
                        break;
                    case "þ":
                        c = "î";
                        break;
                    case "®":
                        c = "ñ";
                        break;
                    case "A":
                        c = "A";
                        break;
                    case "¡":
                        c = "AÊ";
                        break;
                    case "¢":
                        c = "AÂ";
                        break;
                    case "E":
                        c = "E";
                        break;
                    case "£":
                        c = "EÂ";
                        break;
                    case "O":
                        c = "O";
                        break;
                    case "¤":
                        c = "OÂ";
                        break;
                    case "¥":
                        c = "Ô";
                        break;
                    case "I":
                        c = "I";
                        break;
                    case "U":
                        c = "U";
                        break;
                    case "¦":
                        c = "Ö";
                        break;
                    case "Y":
                        c = "Y";
                        break;
                    case "§":
                        c = "Ñ";
                        break;
                }
                tempTCVN3toVNI = tempTCVN3toVNI + c;
            }
            return tempTCVN3toVNI;
        }
        public string TCVN3toUNICODE(string vnstr)
        {
            string tempTCVN3toUNICODE = null;
            string c = null;
            long i = 0;
            //INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of Len(vnstr) for every iteration:
            long tempVar = vnstr.Length;
            for (i = 1; i <= tempVar; i++)
            {
                c = vnstr.Substring((int)(i - 1), 1);
                switch (c)
                {
                    case "a":
                        c = ((char)97).ToString();
                        break;
                    case "¸":
                        c = ((char)225).ToString();
                        break;
                    case "µ":
                        c = ((char)224).ToString();
                        break;
                    case "¶":
                        c = ((char)7843).ToString();
                        break;
                    case "·":
                        c = ((char)227).ToString();
                        break;
                    case "¹":
                        c = ((char)7841).ToString();
                        break;
                    case "¨":
                        c = ((char)259).ToString();
                        break;
                    case "¾":
                        c = ((char)7855).ToString();
                        break;
                    case "»":
                        c = ((char)7857).ToString();
                        break;
                    case "¼":
                        c = ((char)7859).ToString();
                        break;
                    case "½":
                        c = ((char)7861).ToString();
                        break;
                    case "Æ":
                        c = ((char)7863).ToString();
                        break;
                    case "©":
                        c = ((char)226).ToString();
                        break;
                    case "Ê":
                        c = ((char)7845).ToString();
                        break;
                    case "Ç":
                        c = ((char)7847).ToString();
                        break;
                    case "È":
                        c = ((char)7849).ToString();
                        break;
                    case "É":
                        c = ((char)7851).ToString();
                        break;
                    case "Ë":
                        c = ((char)7853).ToString();
                        break;
                    case "e":
                        c = ((char)101).ToString();
                        break;
                    case "Ð":
                        c = ((char)233).ToString();
                        break;
                    case "Ì":
                        c = ((char)232).ToString();
                        break;
                    case "Î":
                        c = ((char)7867).ToString();
                        break;
                    case "Ï":
                        c = ((char)7869).ToString();
                        break;
                    case "Ñ":
                        c = ((char)7865).ToString();
                        break;
                    case "ª":
                        c = ((char)234).ToString();
                        break;
                    case "Õ":
                        c = ((char)7871).ToString();
                        break;
                    case "Ò":
                        c = ((char)7873).ToString();
                        break;
                    case "Ó":
                        c = ((char)7875).ToString();
                        break;
                    case "Ô":
                        c = ((char)7877).ToString();
                        break;
                    case "Ö":
                        c = ((char)7879).ToString();
                        break;
                    case "o":
                        c = ((char)111).ToString();
                        break;
                    case "ã":
                        c = ((char)243).ToString();
                        break;
                    case "ß":
                        c = ((char)242).ToString();
                        break;
                    case "á":
                        c = ((char)7887).ToString();
                        break;
                    case "â":
                        c = ((char)245).ToString();
                        break;
                    case "ä":
                        c = ((char)7885).ToString();
                        break;
                    case "«":
                        c = ((char)244).ToString();
                        break;
                    case "è":
                        c = ((char)7889).ToString();
                        break;
                    case "å":
                        c = ((char)7891).ToString();
                        break;
                    case "æ":
                        c = ((char)7893).ToString();
                        break;
                    case "ç":
                        c = ((char)7895).ToString();
                        break;
                    case "é":
                        c = ((char)7897).ToString();
                        break;
                    case "¬":
                        c = ((char)417).ToString();
                        break;
                    case "í":
                        c = ((char)7899).ToString();
                        break;
                    case "ê":
                        c = ((char)7901).ToString();
                        break;
                    case "ë":
                        c = ((char)7903).ToString();
                        break;
                    case "ì":
                        c = ((char)7905).ToString();
                        break;
                    case "î":
                        c = ((char)7907).ToString();
                        break;
                    case "i":
                        c = ((char)105).ToString();
                        break;
                    case "Ý":
                        c = ((char)237).ToString();
                        break;
                    case "×":
                        c = ((char)236).ToString();
                        break;
                    case "Ø":
                        c = ((char)7881).ToString();
                        break;
                    case "Ü":
                        c = ((char)297).ToString();
                        break;
                    case "Þ":
                        c = ((char)7883).ToString();
                        break;
                    case "u":
                        c = ((char)117).ToString();
                        break;
                    case "ó":
                        c = ((char)250).ToString();
                        break;
                    case "ï":
                        c = ((char)249).ToString();
                        break;
                    case "ñ":
                        c = ((char)7911).ToString();
                        break;
                    case "ò":
                        c = ((char)361).ToString();
                        break;
                    case "ô":
                        c = ((char)7909).ToString();
                        break;
                    case "­":
                        c = ((char)432).ToString();
                        break;
                    case "ø":
                        c = ((char)7913).ToString();
                        break;
                    case "õ":
                        c = ((char)7915).ToString();
                        break;
                    case "ö":
                        c = ((char)7917).ToString();
                        break;
                    case "÷":
                        c = ((char)7919).ToString();
                        break;
                    case "ù":
                        c = ((char)7921).ToString();
                        break;
                    case "y":
                        c = ((char)121).ToString();
                        break;
                    case "ý":
                        c = ((char)253).ToString();
                        break;
                    case "ú":
                        c = ((char)7923).ToString();
                        break;
                    case "û":
                        c = ((char)7927).ToString();
                        break;
                    case "ü":
                        c = ((char)7929).ToString();
                        break;
                    case "þ":
                        c = ((char)7925).ToString();
                        break;
                    case "®":
                        c = ((char)273).ToString();
                        break;
                    case "A":
                        c = ((char)65).ToString();
                        break;
                    case "¡":
                        c = ((char)258).ToString();
                        break;
                    case "¢":
                        c = ((char)194).ToString();
                        break;
                    case "E":
                        c = ((char)69).ToString();
                        break;
                    case "£":
                        c = ((char)202).ToString();
                        break;
                    case "O":
                        c = ((char)79).ToString();
                        break;
                    case "¤":
                        c = ((char)212).ToString();
                        break;
                    case "¥":
                        c = ((char)416).ToString();
                        break;
                    case "I":
                        c = ((char)73).ToString();
                        break;
                    case "U":
                        c = ((char)85).ToString();
                        break;
                    case "¦":
                        c = ((char)431).ToString();
                        break;
                    case "Y":
                        c = ((char)89).ToString();
                        break;
                    case "§":
                        c = ((char)272).ToString();
                        break;
                }
                tempTCVN3toUNICODE = tempTCVN3toUNICODE + c;
            }
            return tempTCVN3toUNICODE;
        }
        public string UNICODEtoTCVN3(string vnstr)
        {
            string tempUNICODEtoTCVN3 = null;
            string c = null;
            long i = 0;
            //INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of Len(vnstr) for every iteration:
            long tempVar = vnstr.Length;
            for (i = 1; i <= tempVar; i++)
            {
                c = vnstr.Substring((int)(i - 1), 1);
                //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
                //	  Select Case c
                //ORIGINAL LINE: Case ChrW$(97)
                if (c == ((char)97).ToString())
                {
                    c = "a";
                }
                //ORIGINAL LINE: Case ChrW$(225)
                else if (c == ((char)225).ToString())
                {
                    c = "¸";
                }
                //ORIGINAL LINE: Case ChrW$(224)
                else if (c == ((char)224).ToString())
                {
                    c = "µ";
                }
                //ORIGINAL LINE: Case ChrW$(7843)
                else if (c == ((char)7843).ToString())
                {
                    c = "¶";
                }
                //ORIGINAL LINE: Case ChrW$(227)
                else if (c == ((char)227).ToString())
                {
                    c = "·";
                }
                //ORIGINAL LINE: Case ChrW$(7841)
                else if (c == ((char)7841).ToString())
                {
                    c = "¹";
                }
                //ORIGINAL LINE: Case ChrW$(259)
                else if (c == ((char)259).ToString())
                {
                    c = "¨";
                }
                //ORIGINAL LINE: Case ChrW$(7855)
                else if (c == ((char)7855).ToString())
                {
                    c = "¾";
                }
                //ORIGINAL LINE: Case ChrW$(7857)
                else if (c == ((char)7857).ToString())
                {
                    c = "»";
                }
                //ORIGINAL LINE: Case ChrW$(7859)
                else if (c == ((char)7859).ToString())
                {
                    c = "¼";
                }
                //ORIGINAL LINE: Case ChrW$(7861)
                else if (c == ((char)7861).ToString())
                {
                    c = "½";
                }
                //ORIGINAL LINE: Case ChrW$(7863)
                else if (c == ((char)7863).ToString())
                {
                    c = "Æ";
                }
                //ORIGINAL LINE: Case ChrW$(226)
                else if (c == ((char)226).ToString())
                {
                    c = "©";
                }
                //ORIGINAL LINE: Case ChrW$(7845)
                else if (c == ((char)7845).ToString())
                {
                    c = "Ê";
                }
                //ORIGINAL LINE: Case ChrW$(7847)
                else if (c == ((char)7847).ToString())
                {
                    c = "Ç";
                }
                //ORIGINAL LINE: Case ChrW$(7849)
                else if (c == ((char)7849).ToString())
                {
                    c = "È";
                }
                //ORIGINAL LINE: Case ChrW$(7851)
                else if (c == ((char)7851).ToString())
                {
                    c = "É";
                }
                //ORIGINAL LINE: Case ChrW$(7853)
                else if (c == ((char)7853).ToString())
                {
                    c = "Ë";
                }
                //ORIGINAL LINE: Case ChrW$(101)
                else if (c == ((char)101).ToString())
                {
                    c = "e";
                }
                //ORIGINAL LINE: Case ChrW$(233)
                else if (c == ((char)233).ToString())
                {
                    c = "Ð";
                }
                //ORIGINAL LINE: Case ChrW$(232)
                else if (c == ((char)232).ToString())
                {
                    c = "Ì";
                }
                //ORIGINAL LINE: Case ChrW$(7867)
                else if (c == ((char)7867).ToString())
                {
                    c = "Î";
                }
                //ORIGINAL LINE: Case ChrW$(7869)
                else if (c == ((char)7869).ToString())
                {
                    c = "Ï";
                }
                //ORIGINAL LINE: Case ChrW$(7865)
                else if (c == ((char)7865).ToString())
                {
                    c = "Ñ";
                }
                //ORIGINAL LINE: Case ChrW$(234)
                else if (c == ((char)234).ToString())
                {
                    c = "ª";
                }
                //ORIGINAL LINE: Case ChrW$(7871)
                else if (c == ((char)7871).ToString())
                {
                    c = "Õ";
                }
                //ORIGINAL LINE: Case ChrW$(7873)
                else if (c == ((char)7873).ToString())
                {
                    c = "Ò";
                }
                //ORIGINAL LINE: Case ChrW$(7875)
                else if (c == ((char)7875).ToString())
                {
                    c = "Ó";
                }
                //ORIGINAL LINE: Case ChrW$(7877)
                else if (c == ((char)7877).ToString())
                {
                    c = "Ô";
                }
                //ORIGINAL LINE: Case ChrW$(7879)
                else if (c == ((char)7879).ToString())
                {
                    c = "Ö";
                }
                //ORIGINAL LINE: Case ChrW$(111)
                else if (c == ((char)111).ToString())
                {
                    c = "o";
                }
                //ORIGINAL LINE: Case ChrW$(243)
                else if (c == ((char)243).ToString())
                {
                    c = "ã";
                }
                //ORIGINAL LINE: Case ChrW$(242)
                else if (c == ((char)242).ToString())
                {
                    c = "ß";
                }
                //ORIGINAL LINE: Case ChrW$(7887)
                else if (c == ((char)7887).ToString())
                {
                    c = "á";
                }
                //ORIGINAL LINE: Case ChrW$(245)
                else if (c == ((char)245).ToString())
                {
                    c = "â";
                }
                //ORIGINAL LINE: Case ChrW$(7885)
                else if (c == ((char)7885).ToString())
                {
                    c = "ä";
                }
                //ORIGINAL LINE: Case ChrW$(244)
                else if (c == ((char)244).ToString())
                {
                    c = "«";
                }
                //ORIGINAL LINE: Case ChrW$(7889)
                else if (c == ((char)7889).ToString())
                {
                    c = "è";
                }
                //ORIGINAL LINE: Case ChrW$(7891)
                else if (c == ((char)7891).ToString())
                {
                    c = "å";
                }
                //ORIGINAL LINE: Case ChrW$(7893)
                else if (c == ((char)7893).ToString())
                {
                    c = "æ";
                }
                //ORIGINAL LINE: Case ChrW$(7895)
                else if (c == ((char)7895).ToString())
                {
                    c = "ç";
                }
                //ORIGINAL LINE: Case ChrW$(7897)
                else if (c == ((char)7897).ToString())
                {
                    c = "é";
                }
                //ORIGINAL LINE: Case ChrW$(417)
                else if (c == ((char)417).ToString())
                {
                    c = "¬";
                }
                //ORIGINAL LINE: Case ChrW$(7899)
                else if (c == ((char)7899).ToString())
                {
                    c = "í";
                }
                //ORIGINAL LINE: Case ChrW$(7901)
                else if (c == ((char)7901).ToString())
                {
                    c = "ê";
                }
                //ORIGINAL LINE: Case ChrW$(7903)
                else if (c == ((char)7903).ToString())
                {
                    c = "ë";
                }
                //ORIGINAL LINE: Case ChrW$(7905)
                else if (c == ((char)7905).ToString())
                {
                    c = "ì";
                }
                //ORIGINAL LINE: Case ChrW$(7907)
                else if (c == ((char)7907).ToString())
                {
                    c = "î";
                }
                //ORIGINAL LINE: Case ChrW$(105)
                else if (c == ((char)105).ToString())
                {
                    c = "i";
                }
                //ORIGINAL LINE: Case ChrW$(237)
                else if (c == ((char)237).ToString())
                {
                    c = "Ý";
                }
                //ORIGINAL LINE: Case ChrW$(236)
                else if (c == ((char)236).ToString())
                {
                    c = "×";
                }
                //ORIGINAL LINE: Case ChrW$(7881)
                else if (c == ((char)7881).ToString())
                {
                    c = "Ø";
                }
                //ORIGINAL LINE: Case ChrW$(297)
                else if (c == ((char)297).ToString())
                {
                    c = "Ü";
                }
                //ORIGINAL LINE: Case ChrW$(7883)
                else if (c == ((char)7883).ToString())
                {
                    c = "Þ";
                }
                //ORIGINAL LINE: Case ChrW$(117)
                else if (c == ((char)117).ToString())
                {
                    c = "u";
                }
                //ORIGINAL LINE: Case ChrW$(250)
                else if (c == ((char)250).ToString())
                {
                    c = "ó";
                }
                //ORIGINAL LINE: Case ChrW$(249)
                else if (c == ((char)249).ToString())
                {
                    c = "ï";
                }
                //ORIGINAL LINE: Case ChrW$(7911)
                else if (c == ((char)7911).ToString())
                {
                    c = "ñ";
                }
                //ORIGINAL LINE: Case ChrW$(361)
                else if (c == ((char)361).ToString())
                {
                    c = "ò";
                }
                //ORIGINAL LINE: Case ChrW$(7909)
                else if (c == ((char)7909).ToString())
                {
                    c = "ô";
                }
                //ORIGINAL LINE: Case ChrW$(432)
                else if (c == ((char)432).ToString())
                {
                    c = "­";
                }
                //ORIGINAL LINE: Case ChrW$(7913)
                else if (c == ((char)7913).ToString())
                {
                    c = "ø";
                }
                //ORIGINAL LINE: Case ChrW$(7915)
                else if (c == ((char)7915).ToString())
                {
                    c = "õ";
                }
                //ORIGINAL LINE: Case ChrW$(7917)
                else if (c == ((char)7917).ToString())
                {
                    c = "ö";
                }
                //ORIGINAL LINE: Case ChrW$(7919)
                else if (c == ((char)7919).ToString())
                {
                    c = "÷";
                }
                //ORIGINAL LINE: Case ChrW$(7921)
                else if (c == ((char)7921).ToString())
                {
                    c = "ù";
                }
                //ORIGINAL LINE: Case ChrW$(121)
                else if (c == ((char)121).ToString())
                {
                    c = "y";
                }
                //ORIGINAL LINE: Case ChrW$(253)
                else if (c == ((char)253).ToString())
                {
                    c = "ý";
                }
                //ORIGINAL LINE: Case ChrW$(7923)
                else if (c == ((char)7923).ToString())
                {
                    c = "ú";
                }
                //ORIGINAL LINE: Case ChrW$(7927)
                else if (c == ((char)7927).ToString())
                {
                    c = "û";
                }
                //ORIGINAL LINE: Case ChrW$(7929)
                else if (c == ((char)7929).ToString())
                {
                    c = "ü";
                }
                //ORIGINAL LINE: Case ChrW$(7925)
                else if (c == ((char)7925).ToString())
                {
                    c = "þ";
                }
                //ORIGINAL LINE: Case ChrW$(273)
                else if (c == ((char)273).ToString())
                {
                    c = "®";
                }
                //ORIGINAL LINE: Case ChrW$(65)
                else if (c == ((char)65).ToString())
                {
                    c = "A";
                }
                //ORIGINAL LINE: Case ChrW$(193)
                else if (c == ((char)193).ToString())
                {
                    c = "¸";
                }
                //ORIGINAL LINE: Case ChrW$(192)
                else if (c == ((char)192).ToString())
                {
                    c = "µ";
                }
                //ORIGINAL LINE: Case ChrW$(7842)
                else if (c == ((char)7842).ToString())
                {
                    c = "¶";
                }
                //ORIGINAL LINE: Case ChrW$(195)
                else if (c == ((char)195).ToString())
                {
                    c = "·";
                }
                //ORIGINAL LINE: Case ChrW$(7840)
                else if (c == ((char)7840).ToString())
                {
                    c = "¹";
                }
                //ORIGINAL LINE: Case ChrW$(258)
                else if (c == ((char)258).ToString())
                {
                    c = "¡";
                }
                //ORIGINAL LINE: Case ChrW$(7854)
                else if (c == ((char)7854).ToString())
                {
                    c = "¾";
                }
                //ORIGINAL LINE: Case ChrW$(7856)
                else if (c == ((char)7856).ToString())
                {
                    c = "»";
                }
                //ORIGINAL LINE: Case ChrW$(7858)
                else if (c == ((char)7858).ToString())
                {
                    c = "¼";
                }
                //ORIGINAL LINE: Case ChrW$(7860)
                else if (c == ((char)7860).ToString())
                {
                    c = "½";
                }
                //ORIGINAL LINE: Case ChrW$(7862)
                else if (c == ((char)7862).ToString())
                {
                    c = "Æ";
                }
                //ORIGINAL LINE: Case ChrW$(194)
                else if (c == ((char)194).ToString())
                {
                    c = "¢";
                }
                //ORIGINAL LINE: Case ChrW$(7844)
                else if (c == ((char)7844).ToString())
                {
                    c = "Ê";
                }
                //ORIGINAL LINE: Case ChrW$(7846)
                else if (c == ((char)7846).ToString())
                {
                    c = "Ç";
                }
                //ORIGINAL LINE: Case ChrW$(7848)
                else if (c == ((char)7848).ToString())
                {
                    c = "È";
                }
                //ORIGINAL LINE: Case ChrW$(7850)
                else if (c == ((char)7850).ToString())
                {
                    c = "É";
                }
                //ORIGINAL LINE: Case ChrW$(7852)
                else if (c == ((char)7852).ToString())
                {
                    c = "Ë";
                }
                //ORIGINAL LINE: Case ChrW$(69)
                else if (c == ((char)69).ToString())
                {
                    c = "E";
                }
                //ORIGINAL LINE: Case ChrW$(201)
                else if (c == ((char)201).ToString())
                {
                    c = "Ð";
                }
                //ORIGINAL LINE: Case ChrW$(200)
                else if (c == ((char)200).ToString())
                {
                    c = "Ì";
                }
                //ORIGINAL LINE: Case ChrW$(7866)
                else if (c == ((char)7866).ToString())
                {
                    c = "Î";
                }
                //ORIGINAL LINE: Case ChrW$(7868)
                else if (c == ((char)7868).ToString())
                {
                    c = "Ï";
                }
                //ORIGINAL LINE: Case ChrW$(7864)
                else if (c == ((char)7864).ToString())
                {
                    c = "Ñ";
                }
                //ORIGINAL LINE: Case ChrW$(202)
                else if (c == ((char)202).ToString())
                {
                    c = "£";
                }
                //ORIGINAL LINE: Case ChrW$(7870)
                else if (c == ((char)7870).ToString())
                {
                    c = "Õ";
                }
                //ORIGINAL LINE: Case ChrW$(7872)
                else if (c == ((char)7872).ToString())
                {
                    c = "Ò";
                }
                //ORIGINAL LINE: Case ChrW$(7874)
                else if (c == ((char)7874).ToString())
                {
                    c = "Ó";
                }
                //ORIGINAL LINE: Case ChrW$(7876)
                else if (c == ((char)7876).ToString())
                {
                    c = "Ô";
                }
                //ORIGINAL LINE: Case ChrW$(7878)
                else if (c == ((char)7878).ToString())
                {
                    c = "Ö";
                }
                //ORIGINAL LINE: Case ChrW$(79)
                else if (c == ((char)79).ToString())
                {
                    c = "O";
                }
                //ORIGINAL LINE: Case ChrW$(211)
                else if (c == ((char)211).ToString())
                {
                    c = "ã";
                }
                //ORIGINAL LINE: Case ChrW$(210)
                else if (c == ((char)210).ToString())
                {
                    c = "ß";
                }
                //ORIGINAL LINE: Case ChrW$(7886)
                else if (c == ((char)7886).ToString())
                {
                    c = "á";
                }
                //ORIGINAL LINE: Case ChrW$(213)
                else if (c == ((char)213).ToString())
                {
                    c = "â";
                }
                //ORIGINAL LINE: Case ChrW$(7884)
                else if (c == ((char)7884).ToString())
                {
                    c = "ä";
                }
                //ORIGINAL LINE: Case ChrW$(212)
                else if (c == ((char)212).ToString())
                {
                    c = "¤";
                }
                //ORIGINAL LINE: Case ChrW$(7888)
                else if (c == ((char)7888).ToString())
                {
                    c = "è";
                }
                //ORIGINAL LINE: Case ChrW$(7890)
                else if (c == ((char)7890).ToString())
                {
                    c = "å";
                }
                //ORIGINAL LINE: Case ChrW$(7892)
                else if (c == ((char)7892).ToString())
                {
                    c = "æ";
                }
                //ORIGINAL LINE: Case ChrW$(7894)
                else if (c == ((char)7894).ToString())
                {
                    c = "ç";
                }
                //ORIGINAL LINE: Case ChrW$(7896)
                else if (c == ((char)7896).ToString())
                {
                    c = "é";
                }
                //ORIGINAL LINE: Case ChrW$(416)
                else if (c == ((char)416).ToString())
                {
                    c = "¥";
                }
                //ORIGINAL LINE: Case ChrW$(7898)
                else if (c == ((char)7898).ToString())
                {
                    c = "í";
                }
                //ORIGINAL LINE: Case ChrW$(7900)
                else if (c == ((char)7900).ToString())
                {
                    c = "ê";
                }
                //ORIGINAL LINE: Case ChrW$(7902)
                else if (c == ((char)7902).ToString())
                {
                    c = "ë";
                }
                //ORIGINAL LINE: Case ChrW$(7904)
                else if (c == ((char)7904).ToString())
                {
                    c = "ì";
                }
                //ORIGINAL LINE: Case ChrW$(7906)
                else if (c == ((char)7906).ToString())
                {
                    c = "î";
                }
                //ORIGINAL LINE: Case ChrW$(73)
                else if (c == ((char)73).ToString())
                {
                    c = "I";
                }
                //ORIGINAL LINE: Case ChrW$(205)
                else if (c == ((char)205).ToString())
                {
                    c = "Ý";
                }
                //ORIGINAL LINE: Case ChrW$(204)
                else if (c == ((char)204).ToString())
                {
                    c = "×";
                }
                //ORIGINAL LINE: Case ChrW$(7880)
                else if (c == ((char)7880).ToString())
                {
                    c = "Ø";
                }
                //ORIGINAL LINE: Case ChrW$(296)
                else if (c == ((char)296).ToString())
                {
                    c = "Ü";
                }
                //ORIGINAL LINE: Case ChrW$(7882)
                else if (c == ((char)7882).ToString())
                {
                    c = "Þ";
                }
                //ORIGINAL LINE: Case ChrW$(85)
                else if (c == ((char)85).ToString())
                {
                    c = "U";
                }
                //ORIGINAL LINE: Case ChrW$(218)
                else if (c == ((char)218).ToString())
                {
                    c = "ó";
                }
                //ORIGINAL LINE: Case ChrW$(217)
                else if (c == ((char)217).ToString())
                {
                    c = "ï";
                }
                //ORIGINAL LINE: Case ChrW$(7910)
                else if (c == ((char)7910).ToString())
                {
                    c = "ñ";
                }
                //ORIGINAL LINE: Case ChrW$(360)
                else if (c == ((char)360).ToString())
                {
                    c = "ò";
                }
                //ORIGINAL LINE: Case ChrW$(7908)
                else if (c == ((char)7908).ToString())
                {
                    c = "ô";
                }
                //ORIGINAL LINE: Case ChrW$(431)
                else if (c == ((char)431).ToString())
                {
                    c = "¦";
                }
                //ORIGINAL LINE: Case ChrW$(7912)
                else if (c == ((char)7912).ToString())
                {
                    c = "ø";
                }
                //ORIGINAL LINE: Case ChrW$(7914)
                else if (c == ((char)7914).ToString())
                {
                    c = "õ";
                }
                //ORIGINAL LINE: Case ChrW$(7916)
                else if (c == ((char)7916).ToString())
                {
                    c = "ö";
                }
                //ORIGINAL LINE: Case ChrW$(7918)
                else if (c == ((char)7918).ToString())
                {
                    c = "÷";
                }
                //ORIGINAL LINE: Case ChrW$(7920)
                else if (c == ((char)7920).ToString())
                {
                    c = "ù";
                }
                //ORIGINAL LINE: Case ChrW$(89)
                else if (c == ((char)89).ToString())
                {
                    c = "Y";
                }
                //ORIGINAL LINE: Case ChrW$(221)
                else if (c == ((char)221).ToString())
                {
                    c = "ý";
                }
                //ORIGINAL LINE: Case ChrW$(7922)
                else if (c == ((char)7922).ToString())
                {
                    c = "ú";
                }
                //ORIGINAL LINE: Case ChrW$(7926)
                else if (c == ((char)7926).ToString())
                {
                    c = "û";
                }
                //ORIGINAL LINE: Case ChrW$(7928)
                else if (c == ((char)7928).ToString())
                {
                    c = "ü";
                }
                //ORIGINAL LINE: Case ChrW$(7924)
                else if (c == ((char)7924).ToString())
                {
                    c = "þ";
                }
                //ORIGINAL LINE: Case ChrW$(272)
                else if (c == ((char)272).ToString())
                {
                    c = "§";
                }
                tempUNICODEtoTCVN3 = tempUNICODEtoTCVN3 + c;
            }
            return tempUNICODEtoTCVN3;
        }
        public string UNICODEtoVNI(string vnstr)
        {
            string tempUNICODEtoVNI = null;
            string c = null;
            long i = 0;
            //INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of Len(vnstr) for every iteration:
            long tempVar = vnstr.Length;
            for (i = 1; i <= tempVar; i++)
            {
                c = vnstr.Substring((int)(i - 1), 1);
                //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
                //	  Select Case c
                //ORIGINAL LINE: Case ChrW$(97)
                if (c == ((char)97).ToString())
                {
                    c = "a";
                }
                //ORIGINAL LINE: Case ChrW$(225)
                else if (c == ((char)225).ToString())
                {
                    c = "aù";
                }
                //ORIGINAL LINE: Case ChrW$(224)
                else if (c == ((char)224).ToString())
                {
                    c = "aø";
                }
                //ORIGINAL LINE: Case ChrW$(7843)
                else if (c == ((char)7843).ToString())
                {
                    c = "aû";
                }
                //ORIGINAL LINE: Case ChrW$(227)
                else if (c == ((char)227).ToString())
                {
                    c = "aõ";
                }
                //ORIGINAL LINE: Case ChrW$(7841)
                else if (c == ((char)7841).ToString())
                {
                    c = "aï";
                }
                //ORIGINAL LINE: Case ChrW$(259)
                else if (c == ((char)259).ToString())
                {
                    c = "aê";
                }
                //ORIGINAL LINE: Case ChrW$(7855)
                else if (c == ((char)7855).ToString())
                {
                    c = "aé";
                }
                //ORIGINAL LINE: Case ChrW$(7857)
                else if (c == ((char)7857).ToString())
                {
                    c = "aè";
                }
                //ORIGINAL LINE: Case ChrW$(7859)
                else if (c == ((char)7859).ToString())
                {
                    c = "aú";
                }
                //ORIGINAL LINE: Case ChrW$(7861)
                else if (c == ((char)7861).ToString())
                {
                    c = "aü";
                }
                //ORIGINAL LINE: Case ChrW$(7863)
                else if (c == ((char)7863).ToString())
                {
                    c = "aë";
                }
                //ORIGINAL LINE: Case ChrW$(226)
                else if (c == ((char)226).ToString())
                {
                    c = "aâ";
                }
                //ORIGINAL LINE: Case ChrW$(7845)
                else if (c == ((char)7845).ToString())
                {
                    c = "aá";
                }
                //ORIGINAL LINE: Case ChrW$(7847)
                else if (c == ((char)7847).ToString())
                {
                    c = "aà";
                }
                //ORIGINAL LINE: Case ChrW$(7849)
                else if (c == ((char)7849).ToString())
                {
                    c = "aå";
                }
                //ORIGINAL LINE: Case ChrW$(7851)
                else if (c == ((char)7851).ToString())
                {
                    c = "aã";
                }
                //ORIGINAL LINE: Case ChrW$(7853)
                else if (c == ((char)7853).ToString())
                {
                    c = "aä";
                }
                //ORIGINAL LINE: Case ChrW$(101)
                else if (c == ((char)101).ToString())
                {
                    c = "e";
                }
                //ORIGINAL LINE: Case ChrW$(233)
                else if (c == ((char)233).ToString())
                {
                    c = "eù";
                }
                //ORIGINAL LINE: Case ChrW$(232)
                else if (c == ((char)232).ToString())
                {
                    c = "eø";
                }
                //ORIGINAL LINE: Case ChrW$(7867)
                else if (c == ((char)7867).ToString())
                {
                    c = "eû";
                }
                //ORIGINAL LINE: Case ChrW$(7869)
                else if (c == ((char)7869).ToString())
                {
                    c = "eõ";
                }
                //ORIGINAL LINE: Case ChrW$(7865)
                else if (c == ((char)7865).ToString())
                {
                    c = "eï";
                }
                //ORIGINAL LINE: Case ChrW$(234)
                else if (c == ((char)234).ToString())
                {
                    c = "eâ";
                }
                //ORIGINAL LINE: Case ChrW$(7871)
                else if (c == ((char)7871).ToString())
                {
                    c = "eá";
                }
                //ORIGINAL LINE: Case ChrW$(7873)
                else if (c == ((char)7873).ToString())
                {
                    c = "eà";
                }
                //ORIGINAL LINE: Case ChrW$(7875)
                else if (c == ((char)7875).ToString())
                {
                    c = "eå";
                }
                //ORIGINAL LINE: Case ChrW$(7877)
                else if (c == ((char)7877).ToString())
                {
                    c = "eã";
                }
                //ORIGINAL LINE: Case ChrW$(7879)
                else if (c == ((char)7879).ToString())
                {
                    c = "eä";
                }
                //ORIGINAL LINE: Case ChrW$(111)
                else if (c == ((char)111).ToString())
                {
                    c = "o";
                }
                //ORIGINAL LINE: Case ChrW$(243)
                else if (c == ((char)243).ToString())
                {
                    c = "où";
                }
                //ORIGINAL LINE: Case ChrW$(242)
                else if (c == ((char)242).ToString())
                {
                    c = "oø";
                }
                //ORIGINAL LINE: Case ChrW$(7887)
                else if (c == ((char)7887).ToString())
                {
                    c = "oû";
                }
                //ORIGINAL LINE: Case ChrW$(245)
                else if (c == ((char)245).ToString())
                {
                    c = "oõ";
                }
                //ORIGINAL LINE: Case ChrW$(7885)
                else if (c == ((char)7885).ToString())
                {
                    c = "oï";
                }
                //ORIGINAL LINE: Case ChrW$(244)
                else if (c == ((char)244).ToString())
                {
                    c = "oâ";
                }
                //ORIGINAL LINE: Case ChrW$(7889)
                else if (c == ((char)7889).ToString())
                {
                    c = "oá";
                }
                //ORIGINAL LINE: Case ChrW$(7891)
                else if (c == ((char)7891).ToString())
                {
                    c = "oà";
                }
                //ORIGINAL LINE: Case ChrW$(7893)
                else if (c == ((char)7893).ToString())
                {
                    c = "oå";
                }
                //ORIGINAL LINE: Case ChrW$(7895)
                else if (c == ((char)7895).ToString())
                {
                    c = "oã";
                }
                //ORIGINAL LINE: Case ChrW$(7897)
                else if (c == ((char)7897).ToString())
                {
                    c = "oä";
                }
                //ORIGINAL LINE: Case ChrW$(417)
                else if (c == ((char)417).ToString())
                {
                    c = "ô";
                }
                //ORIGINAL LINE: Case ChrW$(7899)
                else if (c == ((char)7899).ToString())
                {
                    c = "ôù";
                }
                //ORIGINAL LINE: Case ChrW$(7901)
                else if (c == ((char)7901).ToString())
                {
                    c = "ôø";
                }
                //ORIGINAL LINE: Case ChrW$(7903)
                else if (c == ((char)7903).ToString())
                {
                    c = "ôû";
                }
                //ORIGINAL LINE: Case ChrW$(7905)
                else if (c == ((char)7905).ToString())
                {
                    c = "ôõ";
                }
                //ORIGINAL LINE: Case ChrW$(7907)
                else if (c == ((char)7907).ToString())
                {
                    c = "ôï";
                }
                //ORIGINAL LINE: Case ChrW$(105)
                else if (c == ((char)105).ToString())
                {
                    c = "i";
                }
                //ORIGINAL LINE: Case ChrW$(237)
                else if (c == ((char)237).ToString())
                {
                    c = "í";
                }
                //ORIGINAL LINE: Case ChrW$(236)
                else if (c == ((char)236).ToString())
                {
                    c = "ì";
                }
                //ORIGINAL LINE: Case ChrW$(7881)
                else if (c == ((char)7881).ToString())
                {
                    c = "æ";
                }
                //ORIGINAL LINE: Case ChrW$(297)
                else if (c == ((char)297).ToString())
                {
                    c = "ó";
                }
                //ORIGINAL LINE: Case ChrW$(7883)
                else if (c == ((char)7883).ToString())
                {
                    c = "ò";
                }
                //ORIGINAL LINE: Case ChrW$(117)
                else if (c == ((char)117).ToString())
                {
                    c = "u";
                }
                //ORIGINAL LINE: Case ChrW$(250)
                else if (c == ((char)250).ToString())
                {
                    c = "uù";
                }
                //ORIGINAL LINE: Case ChrW$(249)
                else if (c == ((char)249).ToString())
                {
                    c = "uø";
                }
                //ORIGINAL LINE: Case ChrW$(7911)
                else if (c == ((char)7911).ToString())
                {
                    c = "uû";
                }
                //ORIGINAL LINE: Case ChrW$(361)
                else if (c == ((char)361).ToString())
                {
                    c = "uõ";
                }
                //ORIGINAL LINE: Case ChrW$(7909)
                else if (c == ((char)7909).ToString())
                {
                    c = "uï";
                }
                //ORIGINAL LINE: Case ChrW$(432)
                else if (c == ((char)432).ToString())
                {
                    c = "ö";
                }
                //ORIGINAL LINE: Case ChrW$(7913)
                else if (c == ((char)7913).ToString())
                {
                    c = "öù";
                }
                //ORIGINAL LINE: Case ChrW$(7915)
                else if (c == ((char)7915).ToString())
                {
                    c = "uø";
                }
                //ORIGINAL LINE: Case ChrW$(7917)
                else if (c == ((char)7917).ToString())
                {
                    c = "öû";
                }
                //ORIGINAL LINE: Case ChrW$(7919)
                else if (c == ((char)7919).ToString())
                {
                    c = "öõ";
                }
                //ORIGINAL LINE: Case ChrW$(7921)
                else if (c == ((char)7921).ToString())
                {
                    c = "öï";
                }
                //ORIGINAL LINE: Case ChrW$(121)
                else if (c == ((char)121).ToString())
                {
                    c = "y";
                }
                //ORIGINAL LINE: Case ChrW$(253)
                else if (c == ((char)253).ToString())
                {
                    c = "yù";
                }
                //ORIGINAL LINE: Case ChrW$(7923)
                else if (c == ((char)7923).ToString())
                {
                    c = "yø";
                }
                //ORIGINAL LINE: Case ChrW$(7927)
                else if (c == ((char)7927).ToString())
                {
                    c = "yû";
                }
                //ORIGINAL LINE: Case ChrW$(7929)
                else if (c == ((char)7929).ToString())
                {
                    c = "yõ";
                }
                //ORIGINAL LINE: Case ChrW$(7925)
                else if (c == ((char)7925).ToString())
                {
                    c = "î";
                }
                //ORIGINAL LINE: Case ChrW$(273)
                else if (c == ((char)273).ToString())
                {
                    c = "ñ";
                }
                //ORIGINAL LINE: Case ChrW$(65)
                else if (c == ((char)65).ToString())
                {
                    c = "A";
                }
                //ORIGINAL LINE: Case ChrW$(193)
                else if (c == ((char)193).ToString())
                {
                    c = "AÙ";
                }
                //ORIGINAL LINE: Case ChrW$(192)
                else if (c == ((char)192).ToString())
                {
                    c = "AØ";
                }
                //ORIGINAL LINE: Case ChrW$(7842)
                else if (c == ((char)7842).ToString())
                {
                    c = "AÛ";
                }
                //ORIGINAL LINE: Case ChrW$(195)
                else if (c == ((char)195).ToString())
                {
                    c = "AÕ";
                }
                //ORIGINAL LINE: Case ChrW$(7840)
                else if (c == ((char)7840).ToString())
                {
                    c = "AÏ";
                }
                //ORIGINAL LINE: Case ChrW$(258)
                else if (c == ((char)258).ToString())
                {
                    c = "AÊ";
                }
                //ORIGINAL LINE: Case ChrW$(7854)
                else if (c == ((char)7854).ToString())
                {
                    c = "AÉ";
                }
                //ORIGINAL LINE: Case ChrW$(7856)
                else if (c == ((char)7856).ToString())
                {
                    c = "AÈ";
                }
                //ORIGINAL LINE: Case ChrW$(7858)
                else if (c == ((char)7858).ToString())
                {
                    c = "AÚ";
                }
                //ORIGINAL LINE: Case ChrW$(7860)
                else if (c == ((char)7860).ToString())
                {
                    c = "AÜ";
                }
                //ORIGINAL LINE: Case ChrW$(7862)
                else if (c == ((char)7862).ToString())
                {
                    c = "AË";
                }
                //ORIGINAL LINE: Case ChrW$(194)
                else if (c == ((char)194).ToString())
                {
                    c = "AÂ";
                }
                //ORIGINAL LINE: Case ChrW$(7844)
                else if (c == ((char)7844).ToString())
                {
                    c = "AÁ";
                }
                //ORIGINAL LINE: Case ChrW$(7846)
                else if (c == ((char)7846).ToString())
                {
                    c = "AÀ";
                }
                //ORIGINAL LINE: Case ChrW$(7848)
                else if (c == ((char)7848).ToString())
                {
                    c = "AÅ";
                }
                //ORIGINAL LINE: Case ChrW$(7850)
                else if (c == ((char)7850).ToString())
                {
                    c = "AÃ";
                }
                //ORIGINAL LINE: Case ChrW$(7852)
                else if (c == ((char)7852).ToString())
                {
                    c = "AÄ";
                }
                //ORIGINAL LINE: Case ChrW$(69)
                else if (c == ((char)69).ToString())
                {
                    c = "E";
                }
                //ORIGINAL LINE: Case ChrW$(201)
                else if (c == ((char)201).ToString())
                {
                    c = "EÙ";
                }
                //ORIGINAL LINE: Case ChrW$(200)
                else if (c == ((char)200).ToString())
                {
                    c = "EØ";
                }
                //ORIGINAL LINE: Case ChrW$(7866)
                else if (c == ((char)7866).ToString())
                {
                    c = "EÛ";
                }
                //ORIGINAL LINE: Case ChrW$(7868)
                else if (c == ((char)7868).ToString())
                {
                    c = "EÕ";
                }
                //ORIGINAL LINE: Case ChrW$(7864)
                else if (c == ((char)7864).ToString())
                {
                    c = "EÏ";
                }
                //ORIGINAL LINE: Case ChrW$(202)
                else if (c == ((char)202).ToString())
                {
                    c = "EÂ";
                }
                //ORIGINAL LINE: Case ChrW$(7870)
                else if (c == ((char)7870).ToString())
                {
                    c = "EÁ";
                }
                //ORIGINAL LINE: Case ChrW$(7872)
                else if (c == ((char)7872).ToString())
                {
                    c = "EÀ";
                }
                //ORIGINAL LINE: Case ChrW$(7874)
                else if (c == ((char)7874).ToString())
                {
                    c = "EÅ";
                }
                //ORIGINAL LINE: Case ChrW$(7876)
                else if (c == ((char)7876).ToString())
                {
                    c = "EÃ";
                }
                //ORIGINAL LINE: Case ChrW$(7878)
                else if (c == ((char)7878).ToString())
                {
                    c = "EÄ";
                }
                //ORIGINAL LINE: Case ChrW$(79)
                else if (c == ((char)79).ToString())
                {
                    c = "O";
                }
                //ORIGINAL LINE: Case ChrW$(211)
                else if (c == ((char)211).ToString())
                {
                    c = "OÙ";
                }
                //ORIGINAL LINE: Case ChrW$(210)
                else if (c == ((char)210).ToString())
                {
                    c = "OØ";
                }
                //ORIGINAL LINE: Case ChrW$(7886)
                else if (c == ((char)7886).ToString())
                {
                    c = "OÛ";
                }
                //ORIGINAL LINE: Case ChrW$(213)
                else if (c == ((char)213).ToString())
                {
                    c = "OÕ";
                }
                //ORIGINAL LINE: Case ChrW$(7884)
                else if (c == ((char)7884).ToString())
                {
                    c = "OÏ";
                }
                //ORIGINAL LINE: Case ChrW$(212)
                else if (c == ((char)212).ToString())
                {
                    c = "OÂ";
                }
                //ORIGINAL LINE: Case ChrW$(7888)
                else if (c == ((char)7888).ToString())
                {
                    c = "OÁ";
                }
                //ORIGINAL LINE: Case ChrW$(7890)
                else if (c == ((char)7890).ToString())
                {
                    c = "OÀ";
                }
                //ORIGINAL LINE: Case ChrW$(7892)
                else if (c == ((char)7892).ToString())
                {
                    c = "OÅ";
                }
                //ORIGINAL LINE: Case ChrW$(7894)
                else if (c == ((char)7894).ToString())
                {
                    c = "OÃ";
                }
                //ORIGINAL LINE: Case ChrW$(7896)
                else if (c == ((char)7896).ToString())
                {
                    c = "OÄ";
                }
                //ORIGINAL LINE: Case ChrW$(416)
                else if (c == ((char)416).ToString())
                {
                    c = "Ô";
                }
                //ORIGINAL LINE: Case ChrW$(7898)
                else if (c == ((char)7898).ToString())
                {
                    c = "ÔÙ";
                }
                //ORIGINAL LINE: Case ChrW$(7900)
                else if (c == ((char)7900).ToString())
                {
                    c = "ÔØ";
                }
                //ORIGINAL LINE: Case ChrW$(7902)
                else if (c == ((char)7902).ToString())
                {
                    c = "ÔÛ";
                }
                //ORIGINAL LINE: Case ChrW$(7904)
                else if (c == ((char)7904).ToString())
                {
                    c = "ÔÕ";
                }
                //ORIGINAL LINE: Case ChrW$(7906)
                else if (c == ((char)7906).ToString())
                {
                    c = "ÔÏ";
                }
                //ORIGINAL LINE: Case ChrW$(73)
                else if (c == ((char)73).ToString())
                {
                    c = "I";
                }
                //ORIGINAL LINE: Case ChrW$(205)
                else if (c == ((char)205).ToString())
                {
                    c = "Í";
                }
                //ORIGINAL LINE: Case ChrW$(204)
                else if (c == ((char)204).ToString())
                {
                    c = "Ì";
                }
                //ORIGINAL LINE: Case ChrW$(7880)
                else if (c == ((char)7880).ToString())
                {
                    c = "Æ";
                }
                //ORIGINAL LINE: Case ChrW$(296)
                else if (c == ((char)296).ToString())
                {
                    c = "Ó";
                }
                //ORIGINAL LINE: Case ChrW$(7882)
                else if (c == ((char)7882).ToString())
                {
                    c = "Ò";
                }
                //ORIGINAL LINE: Case ChrW$(85)
                else if (c == ((char)85).ToString())
                {
                    c = "U";
                }
                //ORIGINAL LINE: Case ChrW$(218)
                else if (c == ((char)218).ToString())
                {
                    c = "UÙ";
                }
                //ORIGINAL LINE: Case ChrW$(217)
                else if (c == ((char)217).ToString())
                {
                    c = "UØ";
                }
                //ORIGINAL LINE: Case ChrW$(7910)
                else if (c == ((char)7910).ToString())
                {
                    c = "UÛ";
                }
                //ORIGINAL LINE: Case ChrW$(360)
                else if (c == ((char)360).ToString())
                {
                    c = "UÕ";
                }
                //ORIGINAL LINE: Case ChrW$(7908)
                else if (c == ((char)7908).ToString())
                {
                    c = "UÏ";
                }
                //ORIGINAL LINE: Case ChrW$(431)
                else if (c == ((char)431).ToString())
                {
                    c = "Ö";
                }
                //ORIGINAL LINE: Case ChrW$(7912)
                else if (c == ((char)7912).ToString())
                {
                    c = "ÖÙ";
                }
                //ORIGINAL LINE: Case ChrW$(7914)
                else if (c == ((char)7914).ToString())
                {
                    c = "ÖØ";
                }
                //ORIGINAL LINE: Case ChrW$(7916)
                else if (c == ((char)7916).ToString())
                {
                    c = "ÖÛ";
                }
                //ORIGINAL LINE: Case ChrW$(7918)
                else if (c == ((char)7918).ToString())
                {
                    c = "ÖÕ";
                }
                //ORIGINAL LINE: Case ChrW$(7920)
                else if (c == ((char)7920).ToString())
                {
                    c = "ÖÏ";
                }
                //ORIGINAL LINE: Case ChrW$(89)
                else if (c == ((char)89).ToString())
                {
                    c = "Y";
                }
                //ORIGINAL LINE: Case ChrW$(221)
                else if (c == ((char)221).ToString())
                {
                    c = "YÙ";
                }
                //ORIGINAL LINE: Case ChrW$(7922)
                else if (c == ((char)7922).ToString())
                {
                    c = "YØ";
                }
                //ORIGINAL LINE: Case ChrW$(7926)
                else if (c == ((char)7926).ToString())
                {
                    c = "YÛ";
                }
                //ORIGINAL LINE: Case ChrW$(7928)
                else if (c == ((char)7928).ToString())
                {
                    c = "YÕ";
                }
                //ORIGINAL LINE: Case ChrW$(7924)
                else if (c == ((char)7924).ToString())
                {
                    c = "Î";
                }
                //ORIGINAL LINE: Case ChrW$(272)
                else if (c == ((char)272).ToString())
                {
                    c = "Ñ";
                }
                tempUNICODEtoVNI = tempUNICODEtoVNI + c;
            }
            return tempUNICODEtoVNI;
        }
        public string VNItoUNICODE(string vnstr)
        {
            string tempVNItoUNICODE = null;
            string c = null;
            long i = 0;
            bool db = false;
            //INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of Len(vnstr) for every iteration:
            long tempVar = vnstr.Length;
            for (i = 1; i <= tempVar; i++)
            {
                db = false;
                if (i < vnstr.Length)
                {
                    c = vnstr.Substring((int)i, 1);
                    if (c == "ù" || c == "ø" || c == "û" || c == "õ" || c == "ï" || c == "ê" || c == "é" || c == "è" || c == "ú" || c == "ü" || c == "ë" || c == "â" || c == "á" || c == "à" || c == "å" || c == "ã" || c == "ä" || c == "Ù" || c == "Ø" || c == "Û" || c == "Õ" || c == "Ï" || c == "Ê" || c == "É" || c == "È" || c == "Ú" || c == "Ü" || c == "Ë" || c == "Â" || c == "Á" || c == "À" || c == "Å" || c == "Ã" || c == "Ä")
                    {
                        db = true;
                    }
                }
                if (db)
                {
                    c = vnstr.Substring((int)(i - 1), 2);
                    switch (c)
                    {
                        case "aù":
                            c = ((char)225).ToString();
                            break;
                        case "aø":
                            c = ((char)224).ToString();
                            break;
                        case "aû":
                            c = ((char)7843).ToString();
                            break;
                        case "aõ":
                            c = ((char)227).ToString();
                            break;
                        case "aï":
                            c = ((char)7841).ToString();
                            break;
                        case "aê":
                            c = ((char)259).ToString();
                            break;
                        case "aé":
                            c = ((char)7855).ToString();
                            break;
                        case "aè":
                            c = ((char)7857).ToString();
                            break;
                        case "aú":
                            c = ((char)7859).ToString();
                            break;
                        case "aü":
                            c = ((char)7861).ToString();
                            break;
                        case "aë":
                            c = ((char)7863).ToString();
                            break;
                        case "aâ":
                            c = ((char)226).ToString();
                            break;
                        case "aá":
                            c = ((char)7845).ToString();
                            break;
                        case "aà":
                            c = ((char)7847).ToString();
                            break;
                        case "aå":
                            c = ((char)7849).ToString();
                            break;
                        case "aã":
                            c = ((char)7851).ToString();
                            break;
                        case "aä":
                            c = ((char)7853).ToString();
                            break;
                        case "eù":
                            c = ((char)233).ToString();
                            break;
                        case "eø":
                            c = ((char)232).ToString();
                            break;
                        case "eû":
                            c = ((char)7867).ToString();
                            break;
                        case "eõ":
                            c = ((char)7869).ToString();
                            break;
                        case "eï":
                            c = ((char)7865).ToString();
                            break;
                        case "eâ":
                            c = ((char)234).ToString();
                            break;
                        case "eá":
                            c = ((char)7871).ToString();
                            break;
                        case "eà":
                            c = ((char)7873).ToString();
                            break;
                        case "eå":
                            c = ((char)7875).ToString();
                            break;
                        case "eã":
                            c = ((char)7877).ToString();
                            break;
                        case "eä":
                            c = ((char)7879).ToString();
                            break;
                        case "où":
                            c = ((char)243).ToString();
                            break;
                        case "oø":
                            c = ((char)242).ToString();
                            break;
                        case "oû":
                            c = ((char)7887).ToString();
                            break;
                        case "oõ":
                            c = ((char)245).ToString();
                            break;
                        case "oï":
                            c = ((char)7885).ToString();
                            break;
                        case "oâ":
                            c = ((char)244).ToString();
                            break;
                        case "oá":
                            c = ((char)7889).ToString();
                            break;
                        case "oà":
                            c = ((char)7891).ToString();
                            break;
                        case "oå":
                            c = ((char)7893).ToString();
                            break;
                        case "oã":
                            c = ((char)7895).ToString();
                            break;
                        case "oä":
                            c = ((char)7897).ToString();
                            break;
                        case "ôù":
                            c = ((char)7899).ToString();
                            break;
                        case "ôø":
                            c = ((char)7901).ToString();
                            break;
                        case "ôû":
                            c = ((char)7903).ToString();
                            break;
                        case "ôõ":
                            c = ((char)7905).ToString();
                            break;
                        case "ôï":
                            c = ((char)7907).ToString();
                            break;
                        case "uù":
                            c = ((char)250).ToString();
                            break;
                        case "uø":
                            c = ((char)249).ToString();
                            break;
                        case "uû":
                            c = ((char)7911).ToString();
                            break;
                        case "uõ":
                            c = ((char)361).ToString();
                            break;
                        case "uï":
                            c = ((char)7909).ToString();
                            break;
                        case "öù":
                            c = ((char)7913).ToString();
                            break;
                        case "öø":
                            c = ((char)7915).ToString();
                            break;
                        case "öû":
                            c = ((char)7917).ToString();
                            break;
                        case "öõ":
                            c = ((char)7919).ToString();
                            break;
                        case "öï":
                            c = ((char)7921).ToString();
                            break;
                        case "yù":
                            c = ((char)253).ToString();
                            break;
                        case "yø":
                            c = ((char)7923).ToString();
                            break;
                        case "yû":
                            c = ((char)7927).ToString();
                            break;
                        case "yõ":
                            c = ((char)7929).ToString();
                            break;
                        case "AÙ":
                            c = ((char)193).ToString();
                            break;
                        case "AØ":
                            c = ((char)192).ToString();
                            break;
                        case "AÛ":
                            c = ((char)7842).ToString();
                            break;
                        case "AÕ":
                            c = ((char)195).ToString();
                            break;
                        case "AÏ":
                            c = ((char)7840).ToString();
                            break;
                        case "AÊ":
                            c = ((char)258).ToString();
                            break;
                        case "AÉ":
                            c = ((char)7854).ToString();
                            break;
                        case "AÈ":
                            c = ((char)7856).ToString();
                            break;
                        case "AÚ":
                            c = ((char)7858).ToString();
                            break;
                        case "AÜ":
                            c = ((char)7860).ToString();
                            break;
                        case "AË":
                            c = ((char)7862).ToString();
                            break;
                        case "AÂ":
                            c = ((char)194).ToString();
                            break;
                        case "AÁ":
                            c = ((char)7844).ToString();
                            break;
                        case "AÀ":
                            c = ((char)7846).ToString();
                            break;
                        case "AÅ":
                            c = ((char)7848).ToString();
                            break;
                        case "AÃ":
                            c = ((char)7850).ToString();
                            break;
                        case "AÄ":
                            c = ((char)7852).ToString();
                            break;
                        case "EÙ":
                            c = ((char)201).ToString();
                            break;
                        case "EØ":
                            c = ((char)200).ToString();
                            break;
                        case "EÛ":
                            c = ((char)7866).ToString();
                            break;
                        case "EÕ":
                            c = ((char)7868).ToString();
                            break;
                        case "EÏ":
                            c = ((char)7864).ToString();
                            break;
                        case "EÂ":
                            c = ((char)202).ToString();
                            break;
                        case "EÁ":
                            c = ((char)7870).ToString();
                            break;
                        case "EÀ":
                            c = ((char)7872).ToString();
                            break;
                        case "EÅ":
                            c = ((char)7874).ToString();
                            break;
                        case "EÃ":
                            c = ((char)7876).ToString();
                            break;
                        case "EÄ":
                            c = ((char)7878).ToString();
                            break;
                        case "OÙ":
                            c = ((char)211).ToString();
                            break;
                        case "OØ":
                            c = ((char)210).ToString();
                            break;
                        case "OÛ":
                            c = ((char)7886).ToString();
                            break;
                        case "OÕ":
                            c = ((char)213).ToString();
                            break;
                        case "OÏ":
                            c = ((char)7884).ToString();
                            break;
                        case "OÂ":
                            c = ((char)212).ToString();
                            break;
                        case "OÁ":
                            c = ((char)7888).ToString();
                            break;
                        case "OÀ":
                            c = ((char)7890).ToString();
                            break;
                        case "OÅ":
                            c = ((char)7892).ToString();
                            break;
                        case "OÃ":
                            c = ((char)7894).ToString();
                            break;
                        case "OÄ":
                            c = ((char)7896).ToString();
                            break;
                        case "ÔÙ":
                            c = ((char)7898).ToString();
                            break;
                        case "ÔØ":
                            c = ((char)7900).ToString();
                            break;
                        case "ÔÛ":
                            c = ((char)7902).ToString();
                            break;
                        case "ÔÕ":
                            c = ((char)7904).ToString();
                            break;
                        case "ÔÏ":
                            c = ((char)7906).ToString();
                            break;
                        case "UÙ":
                            c = ((char)218).ToString();
                            break;
                        case "UØ":
                            c = ((char)217).ToString();
                            break;
                        case "UÛ":
                            c = ((char)7910).ToString();
                            break;
                        case "UÕ":
                            c = ((char)360).ToString();
                            break;
                        case "UÏ":
                            c = ((char)7908).ToString();
                            break;
                        case "ÖÙ":
                            c = ((char)7912).ToString();
                            break;
                        case "ÖØ":
                            c = ((char)7914).ToString();
                            break;
                        case "ÖÛ":
                            c = ((char)7916).ToString();
                            break;
                        case "ÖÕ":
                            c = ((char)7918).ToString();
                            break;
                        case "ÖÏ":
                            c = ((char)7920).ToString();
                            break;
                        case "YÙ":
                            c = ((char)221).ToString();
                            break;
                        case "YØ":
                            c = ((char)7922).ToString();
                            break;
                        case "YÛ":
                            c = ((char)7926).ToString();
                            break;
                        case "YÕ":
                            c = ((char)7928).ToString();
                            break;
                    }
                }
                else
                {
                    c = vnstr.Substring((int)(i - 1), 1);
                    switch (c)
                    {
                        case "ô":
                            c = ((char)417).ToString();
                            break;
                        case "í":
                            c = ((char)237).ToString();
                            break;
                        case "ì":
                            c = ((char)236).ToString();
                            break;
                        case "æ":
                            c = ((char)7881).ToString();
                            break;
                        case "ó":
                            c = ((char)297).ToString();
                            break;
                        case "ò":
                            c = ((char)7883).ToString();
                            break;
                        case "ö":
                            c = ((char)432).ToString();
                            break;
                        case "î":
                            c = ((char)7925).ToString();
                            break;
                        case "ñ":
                            c = ((char)273).ToString();
                            break;
                        case "Ô":
                            c = ((char)416).ToString();
                            break;
                        case "Í":
                            c = ((char)205).ToString();
                            break;
                        case "Ì":
                            c = ((char)204).ToString();
                            break;
                        case "Æ":
                            c = ((char)7880).ToString();
                            break;
                        case "Ó":
                            c = ((char)296).ToString();
                            break;
                        case "Ò":
                            c = ((char)7882).ToString();
                            break;
                        case "Ö":
                            c = ((char)431).ToString();
                            break;
                        case "Î":
                            c = ((char)7924).ToString();
                            break;
                        case "Ñ":
                            c = ((char)272).ToString();
                            break;
                    }
                }
                tempVNItoUNICODE = tempVNItoUNICODE + c;
                if (db)
                {
                    i = i + 1;
                }
            }
            return tempVNItoUNICODE;
        }
        public string VNItoTCVN3(string vnstr)
        {
            string tempVNItoTCVN3 = null;
            string c = null;
            long i = 0;
            bool db = false;
            //INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of Len(vnstr) for every iteration:
            long tempVar = vnstr.Length;
            for (i = 1; i <= tempVar; i++)
            {
                db = false;
                if (i < vnstr.Length)
                {
                    c = vnstr.Substring((int)i, 1);
                    if (c == "ù" || c == "ø" || c == "û" || c == "õ" || c == "ï" || c == "ê" || c == "é" || c == "è" || c == "ú" || c == "ü" || c == "ë" || c == "â" || c == "á" || c == "à" || c == "å" || c == "ã" || c == "ä" || c == "Ù" || c == "Ø" || c == "Û" || c == "Õ" || c == "Ï" || c == "Ê" || c == "É" || c == "È" || c == "Ú" || c == "Ü" || c == "Ë" || c == "Â" || c == "Á" || c == "À" || c == "Å" || c == "Ã" || c == "Ä")
                    {
                        db = true;
                    }
                }
                if (db)
                {
                    c = vnstr.Substring((int)(i - 1), 2);
                    switch (c)
                    {
                        case "aù":
                            c = "¸";
                            break;
                        case "aø":
                            c = "µ";
                            break;
                        case "aû":
                            c = "¶";
                            break;
                        case "aõ":
                            c = "·";
                            break;
                        case "aï":
                            c = "¹";
                            break;
                        case "aê":
                            c = "¨";
                            break;
                        case "aé":
                            c = "¾";
                            break;
                        case "aè":
                            c = "»";
                            break;
                        case "aú":
                            c = "¼";
                            break;
                        case "aü":
                            c = "½";
                            break;
                        case "aë":
                            c = "Æ";
                            break;
                        case "aâ":
                            c = "©";
                            break;
                        case "aá":
                            c = "Ê";
                            break;
                        case "aà":
                            c = "Ç";
                            break;
                        case "aå":
                            c = "È";
                            break;
                        case "aã":
                            c = "É";
                            break;
                        case "aä":
                            c = "Ë";
                            break;
                        case "eù":
                            c = "Ð";
                            break;
                        case "eø":
                            c = "Ì";
                            break;
                        case "eû":
                            c = "Î";
                            break;
                        case "eõ":
                            c = "Ï";
                            break;
                        case "eï":
                            c = "Ñ";
                            break;
                        case "eâ":
                            c = "ª";
                            break;
                        case "eá":
                            c = "Õ";
                            break;
                        case "eà":
                            c = "Ò";
                            break;
                        case "eå":
                            c = "Ó";
                            break;
                        case "eã":
                            c = "Ô";
                            break;
                        case "eä":
                            c = "Ö";
                            break;
                        case "où":
                            c = "ã";
                            break;
                        case "oø":
                            c = "ß";
                            break;
                        case "oû":
                            c = "á";
                            break;
                        case "oõ":
                            c = "â";
                            break;
                        case "oï":
                            c = "ä";
                            break;
                        case "oâ":
                            c = "«";
                            break;
                        case "oá":
                            c = "è";
                            break;
                        case "oà":
                            c = "å";
                            break;
                        case "oå":
                            c = "æ";
                            break;
                        case "oã":
                            c = "ç";
                            break;
                        case "oä":
                            c = "é";
                            break;
                        case "ôù":
                            c = "í";
                            break;
                        case "ôø":
                            c = "ê";
                            break;
                        case "ôû":
                            c = "ë";
                            break;
                        case "ôõ":
                            c = "ì";
                            break;
                        case "ôï":
                            c = "î";
                            break;
                        case "uù":
                            c = "ó";
                            break;
                        case "uø":
                            c = "ï";
                            break;
                        case "uû":
                            c = "ñ";
                            break;
                        case "uõ":
                            c = "ò";
                            break;
                        case "uï":
                            c = "ô";
                            break;
                        case "öù":
                            c = "ø";
                            break;
                        case "öø":
                            c = "õ";
                            break;
                        case "öû":
                            c = "ö";
                            break;
                        case "öõ":
                            c = "÷";
                            break;
                        case "öï":
                            c = "ù";
                            break;
                        case "yù":
                            c = "ý";
                            break;
                        case "yø":
                            c = "ú";
                            break;
                        case "yû":
                            c = "û";
                            break;
                        case "yõ":
                            c = "ü";
                            break;
                        case "AÙ":
                            c = "¸";
                            break;
                        case "AØ":
                            c = "µ";
                            break;
                        case "AÛ":
                            c = "¶";
                            break;
                        case "AÕ":
                            c = "·";
                            break;
                        case "AÏ":
                            c = "¹";
                            break;
                        case "AÉ":
                            c = "¾";
                            break;
                        case "AÈ":
                            c = "»";
                            break;
                        case "AÚ":
                            c = "¼";
                            break;
                        case "AÜ":
                            c = "½";
                            break;
                        case "AË":
                            c = "Æ";
                            break;
                        case "AÁ":
                            c = "Ê";
                            break;
                        case "AÀ":
                            c = "Ç";
                            break;
                        case "AÅ":
                            c = "È";
                            break;
                        case "AÃ":
                            c = "É";
                            break;
                        case "AÄ":
                            c = "Ë";
                            break;
                        case "EÙ":
                            c = "Ð";
                            break;
                        case "EØ":
                            c = "Ì";
                            break;
                        case "EÛ":
                            c = "Î";
                            break;
                        case "EÕ":
                            c = "Ï";
                            break;
                        case "EÏ":
                            c = "Ñ";
                            break;
                        case "EÁ":
                            c = "Õ";
                            break;
                        case "EÀ":
                            c = "Ò";
                            break;
                        case "EÅ":
                            c = "Ó";
                            break;
                        case "EÃ":
                            c = "Ô";
                            break;
                        case "EÄ":
                            c = "Ö";
                            break;
                        case "OÙ":
                            c = "ã";
                            break;
                        case "OØ":
                            c = "ß";
                            break;
                        case "OÛ":
                            c = "á";
                            break;
                        case "OÕ":
                            c = "â";
                            break;
                        case "OÏ":
                            c = "ä";
                            break;
                        case "OÁ":
                            c = "è";
                            break;
                        case "OÀ":
                            c = "å";
                            break;
                        case "OÅ":
                            c = "æ";
                            break;
                        case "OÃ":
                            c = "ç";
                            break;
                        case "OÄ":
                            c = "é";
                            break;
                        case "ÔÙ":
                            c = "í";
                            break;
                        case "ÔØ":
                            c = "ê";
                            break;
                        case "ÔÛ":
                            c = "ë";
                            break;
                        case "ÔÕ":
                            c = "ì";
                            break;
                        case "ÔÏ":
                            c = "î";
                            break;
                        case "UÙ":
                            c = "ó";
                            break;
                        case "UØ":
                            c = "ï";
                            break;
                        case "UÛ":
                            c = "ñ";
                            break;
                        case "UÕ":
                            c = "ò";
                            break;
                        case "UÏ":
                            c = "ô";
                            break;
                        case "ÖÙ":
                            c = "ø";
                            break;
                        case "ÖØ":
                            c = "õ";
                            break;
                        case "ÖÛ":
                            c = "ö";
                            break;
                        case "ÖÕ":
                            c = "÷";
                            break;
                        case "ÖÏ":
                            c = "ù";
                            break;
                        case "YÙ":
                            c = "ý";
                            break;
                        case "YØ":
                            c = "ú";
                            break;
                        case "YÛ":
                            c = "û";
                            break;
                        case "YÕ":
                            c = "ü";
                            break;
                        case "AÊ":
                            c = "¡";
                            break;
                        case "AÂ":
                            c = "¢";
                            break;
                        case "EÂ":
                            c = "£";
                            break;
                        case "OÂ":
                            c = "¤";
                            break;
                    }
                }
                else
                {
                    c = vnstr.Substring((int)(i - 1), 1);
                    switch (c)
                    {
                        case "ô":
                            c = "¬";
                            break;
                        case "i":
                            c = "i";
                            break;
                        case "í":
                            c = "Ý";
                            break;
                        case "ì":
                            c = "×";
                            break;
                        case "æ":
                            c = "Ø";
                            break;
                        case "ó":
                            c = "Ü";
                            break;
                        case "ò":
                            c = "Þ";
                            break;
                        case "ö":
                            c = "­";
                            break;
                        case "î":
                            c = "þ";
                            break;
                        case "ñ":
                            c = "®";
                            break;
                        case "A":
                            c = "A";
                            break;
                        case "Ô":
                            c = "¥";
                            break;
                        case "I":
                            c = "I";
                            break;
                        case "Í":
                            c = "Æ";
                            break;
                        case "Ý":
                            c = "Ø";
                            break;
                        case "U":
                            c = "U";
                            break;
                        case "Ö":
                            c = "¦";
                            break;
                        case "Y":
                            c = "Y";
                            break;
                        case "Ñ":
                            c = "§";
                            break;
                    }
                }
                tempVNItoTCVN3 = tempVNItoTCVN3 + c;
                if (db)
                {
                    i = i + 1;
                }
            }
            return tempVNItoTCVN3;
        }
        public string TCVN3fromVNI(string vnstr)
        {
            return VNItoTCVN3(vnstr);
        }
        public string TCVN3fromUNICODE(string vnstr)
        {
            return UNICODEtoTCVN3(vnstr);
        }
        public string VNIfromTCVN3(string vnstr)
        {
            return TCVN3toVNI(vnstr);
        }
        public string VNIfromUNICODE(string vnstr)
        {
            return UNICODEtoVNI(vnstr);
        }
        public string UNICODEfromVNI(string vnstr)
        {
            return VNItoUNICODE(vnstr);
        }
        public string UNICODEfromTCVN3(string vnstr)
        {
            return TCVN3toUNICODE(vnstr);
        }

        public string UPPERUni(string vnstr)
        {
            string c = null;
            long i = 0;
            vnstr = vnstr.ToUpper();
            //INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of Len(vnstr) for every iteration:
            long tempVar = vnstr.Length;
            for (i = 1; i <= tempVar; i++)
            {
                c = vnstr.Substring((int)(i - 1), 1);
                //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
                //	  Select Case c
                //ORIGINAL LINE: Case ChrW$(97)
                if (c == ((char)97).ToString())
                {
                    c = ((char)65).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(225)
                else if (c == ((char)225).ToString())
                {
                    c = ((char)193).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(224)
                else if (c == ((char)224).ToString())
                {
                    c = ((char)192).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7843)
                else if (c == ((char)7843).ToString())
                {
                    c = ((char)7842).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(227)
                else if (c == ((char)227).ToString())
                {
                    c = ((char)195).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7841)
                else if (c == ((char)7841).ToString())
                {
                    c = ((char)7840).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(259)
                else if (c == ((char)259).ToString())
                {
                    c = ((char)258).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7855)
                else if (c == ((char)7855).ToString())
                {
                    c = ((char)7854).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7857)
                else if (c == ((char)7857).ToString())
                {
                    c = ((char)7856).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7859)
                else if (c == ((char)7859).ToString())
                {
                    c = ((char)7858).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7861)
                else if (c == ((char)7861).ToString())
                {
                    c = ((char)7860).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7863)
                else if (c == ((char)7863).ToString())
                {
                    c = ((char)7862).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(226)
                else if (c == ((char)226).ToString())
                {
                    c = ((char)194).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7845)
                else if (c == ((char)7845).ToString())
                {
                    c = ((char)7844).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7847)
                else if (c == ((char)7847).ToString())
                {
                    c = ((char)7846).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7849)
                else if (c == ((char)7849).ToString())
                {
                    c = ((char)7848).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7851)
                else if (c == ((char)7851).ToString())
                {
                    c = ((char)7850).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7853)
                else if (c == ((char)7853).ToString())
                {
                    c = ((char)7852).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(101)
                else if (c == ((char)101).ToString())
                {
                    c = ((char)69).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(233)
                else if (c == ((char)233).ToString())
                {
                    c = ((char)201).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(232)
                else if (c == ((char)232).ToString())
                {
                    c = ((char)200).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7867)
                else if (c == ((char)7867).ToString())
                {
                    c = ((char)7866).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7869)
                else if (c == ((char)7869).ToString())
                {
                    c = ((char)7868).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7865)
                else if (c == ((char)7865).ToString())
                {
                    c = ((char)7864).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(234)
                else if (c == ((char)234).ToString())
                {
                    c = ((char)202).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7871)
                else if (c == ((char)7871).ToString())
                {
                    c = ((char)7870).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7873)
                else if (c == ((char)7873).ToString())
                {
                    c = ((char)7872).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7875)
                else if (c == ((char)7875).ToString())
                {
                    c = ((char)7874).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7877)
                else if (c == ((char)7877).ToString())
                {
                    c = ((char)7876).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7879)
                else if (c == ((char)7879).ToString())
                {
                    c = ((char)7878).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(111)
                else if (c == ((char)111).ToString())
                {
                    c = ((char)79).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(243)
                else if (c == ((char)243).ToString())
                {
                    c = ((char)211).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(242)
                else if (c == ((char)242).ToString())
                {
                    c = ((char)210).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7887)
                else if (c == ((char)7887).ToString())
                {
                    c = ((char)7886).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(245)
                else if (c == ((char)245).ToString())
                {
                    c = ((char)213).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7885)
                else if (c == ((char)7885).ToString())
                {
                    c = ((char)7884).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(244)
                else if (c == ((char)244).ToString())
                {
                    c = ((char)212).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7889)
                else if (c == ((char)7889).ToString())
                {
                    c = ((char)7888).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7891)
                else if (c == ((char)7891).ToString())
                {
                    c = ((char)7890).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7893)
                else if (c == ((char)7893).ToString())
                {
                    c = ((char)7892).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7895)
                else if (c == ((char)7895).ToString())
                {
                    c = ((char)7894).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7897)
                else if (c == ((char)7897).ToString())
                {
                    c = ((char)7896).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(417)
                else if (c == ((char)417).ToString())
                {
                    c = ((char)416).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7899)
                else if (c == ((char)7899).ToString())
                {
                    c = ((char)7898).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7901)
                else if (c == ((char)7901).ToString())
                {
                    c = ((char)7900).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7903)
                else if (c == ((char)7903).ToString())
                {
                    c = ((char)7902).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7905)
                else if (c == ((char)7905).ToString())
                {
                    c = ((char)7904).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7907)
                else if (c == ((char)7907).ToString())
                {
                    c = ((char)7906).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(105)
                else if (c == ((char)105).ToString())
                {
                    c = ((char)73).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(237)
                else if (c == ((char)237).ToString())
                {
                    c = ((char)205).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(236)
                else if (c == ((char)236).ToString())
                {
                    c = ((char)204).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7881)
                else if (c == ((char)7881).ToString())
                {
                    c = ((char)7880).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(297)
                else if (c == ((char)297).ToString())
                {
                    c = ((char)296).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7883)
                else if (c == ((char)7883).ToString())
                {
                    c = ((char)7882).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(117)
                else if (c == ((char)117).ToString())
                {
                    c = ((char)85).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(250)
                else if (c == ((char)250).ToString())
                {
                    c = ((char)218).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(249)
                else if (c == ((char)249).ToString())
                {
                    c = ((char)217).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7911)
                else if (c == ((char)7911).ToString())
                {
                    c = ((char)7910).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(361)
                else if (c == ((char)361).ToString())
                {
                    c = ((char)360).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7909)
                else if (c == ((char)7909).ToString())
                {
                    c = ((char)7908).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(432)
                else if (c == ((char)432).ToString())
                {
                    c = ((char)431).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7913)
                else if (c == ((char)7913).ToString())
                {
                    c = ((char)7912).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7915)
                else if (c == ((char)7915).ToString())
                {
                    c = ((char)7914).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7917)
                else if (c == ((char)7917).ToString())
                {
                    c = ((char)7916).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7919)
                else if (c == ((char)7919).ToString())
                {
                    c = ((char)7918).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7921)
                else if (c == ((char)7921).ToString())
                {
                    c = ((char)7920).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(121)
                else if (c == ((char)121).ToString())
                {
                    c = ((char)89).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(253)
                else if (c == ((char)253).ToString())
                {
                    c = ((char)221).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7923)
                else if (c == ((char)7923).ToString())
                {
                    c = ((char)7922).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7927)
                else if (c == ((char)7927).ToString())
                {
                    c = ((char)7926).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7929)
                else if (c == ((char)7929).ToString())
                {
                    c = ((char)7928).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7925)
                else if (c == ((char)7925).ToString())
                {
                    c = ((char)7924).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(273)
                else if (c == ((char)273).ToString())
                {
                    c = ((char)272).ToString();
                }
            }
            return vnstr;
        }
        public string lowerUni(string vnstr)
        {
            string c = null;
            long i = 0;
            vnstr = vnstr.ToLower();
            //INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of Len(vnstr) for every iteration:
            long tempVar = vnstr.Length;
            for (i = 1; i <= tempVar; i++)
            {
                c = vnstr.Substring((int)(i - 1), 1);
                //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
                //	  Select Case c
                //ORIGINAL LINE: Case ChrW$(97)
                if (c == ((char)97).ToString())
                {
                    c = ((char)65).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(225)
                else if (c == ((char)225).ToString())
                {
                    c = ((char)193).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(224)
                else if (c == ((char)224).ToString())
                {
                    c = ((char)192).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7843)
                else if (c == ((char)7843).ToString())
                {
                    c = ((char)7842).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(227)
                else if (c == ((char)227).ToString())
                {
                    c = ((char)195).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7841)
                else if (c == ((char)7841).ToString())
                {
                    c = ((char)7840).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(259)
                else if (c == ((char)259).ToString())
                {
                    c = ((char)258).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7855)
                else if (c == ((char)7855).ToString())
                {
                    c = ((char)7854).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7857)
                else if (c == ((char)7857).ToString())
                {
                    c = ((char)7856).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7859)
                else if (c == ((char)7859).ToString())
                {
                    c = ((char)7858).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7861)
                else if (c == ((char)7861).ToString())
                {
                    c = ((char)7860).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7863)
                else if (c == ((char)7863).ToString())
                {
                    c = ((char)7862).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(226)
                else if (c == ((char)226).ToString())
                {
                    c = ((char)194).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7845)
                else if (c == ((char)7845).ToString())
                {
                    c = ((char)7844).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7847)
                else if (c == ((char)7847).ToString())
                {
                    c = ((char)7846).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7849)
                else if (c == ((char)7849).ToString())
                {
                    c = ((char)7848).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7851)
                else if (c == ((char)7851).ToString())
                {
                    c = ((char)7850).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7853)
                else if (c == ((char)7853).ToString())
                {
                    c = ((char)7852).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(101)
                else if (c == ((char)101).ToString())
                {
                    c = ((char)69).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(233)
                else if (c == ((char)233).ToString())
                {
                    c = ((char)201).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(232)
                else if (c == ((char)232).ToString())
                {
                    c = ((char)200).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7867)
                else if (c == ((char)7867).ToString())
                {
                    c = ((char)7866).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7869)
                else if (c == ((char)7869).ToString())
                {
                    c = ((char)7868).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7865)
                else if (c == ((char)7865).ToString())
                {
                    c = ((char)7864).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(234)
                else if (c == ((char)234).ToString())
                {
                    c = ((char)202).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7871)
                else if (c == ((char)7871).ToString())
                {
                    c = ((char)7870).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7873)
                else if (c == ((char)7873).ToString())
                {
                    c = ((char)7872).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7875)
                else if (c == ((char)7875).ToString())
                {
                    c = ((char)7874).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7877)
                else if (c == ((char)7877).ToString())
                {
                    c = ((char)7876).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7879)
                else if (c == ((char)7879).ToString())
                {
                    c = ((char)7878).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(111)
                else if (c == ((char)111).ToString())
                {
                    c = ((char)79).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(243)
                else if (c == ((char)243).ToString())
                {
                    c = ((char)211).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(242)
                else if (c == ((char)242).ToString())
                {
                    c = ((char)210).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7887)
                else if (c == ((char)7887).ToString())
                {
                    c = ((char)7886).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(245)
                else if (c == ((char)245).ToString())
                {
                    c = ((char)213).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7885)
                else if (c == ((char)7885).ToString())
                {
                    c = ((char)7884).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(244)
                else if (c == ((char)244).ToString())
                {
                    c = ((char)212).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7889)
                else if (c == ((char)7889).ToString())
                {
                    c = ((char)7888).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7891)
                else if (c == ((char)7891).ToString())
                {
                    c = ((char)7890).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7893)
                else if (c == ((char)7893).ToString())
                {
                    c = ((char)7892).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7895)
                else if (c == ((char)7895).ToString())
                {
                    c = ((char)7894).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7897)
                else if (c == ((char)7897).ToString())
                {
                    c = ((char)7896).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(417)
                else if (c == ((char)417).ToString())
                {
                    c = ((char)416).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7899)
                else if (c == ((char)7899).ToString())
                {
                    c = ((char)7898).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7901)
                else if (c == ((char)7901).ToString())
                {
                    c = ((char)7900).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7903)
                else if (c == ((char)7903).ToString())
                {
                    c = ((char)7902).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7905)
                else if (c == ((char)7905).ToString())
                {
                    c = ((char)7904).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7907)
                else if (c == ((char)7907).ToString())
                {
                    c = ((char)7906).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(105)
                else if (c == ((char)105).ToString())
                {
                    c = ((char)73).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(237)
                else if (c == ((char)237).ToString())
                {
                    c = ((char)205).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(236)
                else if (c == ((char)236).ToString())
                {
                    c = ((char)204).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7881)
                else if (c == ((char)7881).ToString())
                {
                    c = ((char)7880).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(297)
                else if (c == ((char)297).ToString())
                {
                    c = ((char)296).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7883)
                else if (c == ((char)7883).ToString())
                {
                    c = ((char)7882).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(117)
                else if (c == ((char)117).ToString())
                {
                    c = ((char)85).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(250)
                else if (c == ((char)250).ToString())
                {
                    c = ((char)218).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(249)
                else if (c == ((char)249).ToString())
                {
                    c = ((char)217).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7911)
                else if (c == ((char)7911).ToString())
                {
                    c = ((char)7910).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(361)
                else if (c == ((char)361).ToString())
                {
                    c = ((char)360).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7909)
                else if (c == ((char)7909).ToString())
                {
                    c = ((char)7908).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(432)
                else if (c == ((char)432).ToString())
                {
                    c = ((char)431).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7913)
                else if (c == ((char)7913).ToString())
                {
                    c = ((char)7912).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7915)
                else if (c == ((char)7915).ToString())
                {
                    c = ((char)7914).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7917)
                else if (c == ((char)7917).ToString())
                {
                    c = ((char)7916).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7919)
                else if (c == ((char)7919).ToString())
                {
                    c = ((char)7918).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7921)
                else if (c == ((char)7921).ToString())
                {
                    c = ((char)7920).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(121)
                else if (c == ((char)121).ToString())
                {
                    c = ((char)89).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(253)
                else if (c == ((char)253).ToString())
                {
                    c = ((char)221).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7923)
                else if (c == ((char)7923).ToString())
                {
                    c = ((char)7922).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7927)
                else if (c == ((char)7927).ToString())
                {
                    c = ((char)7926).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7929)
                else if (c == ((char)7929).ToString())
                {
                    c = ((char)7928).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(7925)
                else if (c == ((char)7925).ToString())
                {
                    c = ((char)7924).ToString();
                }
                //ORIGINAL LINE: Case ChrW$(273)
                else if (c == ((char)273).ToString())
                {
                    c = ((char)272).ToString();
                }
            }
            return vnstr;
        }
        public string ProperUni(string vnstr)
        {
            string tempProperUni = null;
            string c = null;
            long i = 0;
            vnstr = lowerUni(vnstr).ToString();
            //INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of Len(vnstr) for every iteration:
            long tempVar = vnstr.Length;
            for (i = 1; i <= tempVar; i++)
            {
                c = vnstr.Substring((int)(i - 1), 1);
                if (i == 1)
                {
                    c = UPPERUni(c);
                }
                else
                {
                    if (vnstr.Substring((int)(i - 2), 1) == " ")
                    {
                        c = UPPERUni(c);
                    }
                }
                tempProperUni = tempProperUni + c;
            }
            if (vnstr.Length == 0)
            {
                tempProperUni = "";
            }
            return tempProperUni;
        }
        public string ProperVni(string vnstr)
        {
            string tempProperVni = null;
            string c = null;
            long i = 0;
            vnstr = ProperUni(vnstr).ToString();
            if (vnstr.Length >= 1)
            {
                tempProperVni = vnstr.Substring(0, 1).ToUpper();
            }
            //INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of Len(vnstr) for every iteration:
            long tempVar = vnstr.Length;
            for (i = 2; i <= tempVar; i++)
            {
                c = vnstr.Substring((int)(i - 1), 1);
                if ((c == "ù") || (c == "ø") || (c == "û") || (c == "õ") || (c == "ï") || (c == "ê") || (c == "è") || (c == "é") || (c == "ú") || (c == "ü") || (c == "ë") || (c == "â") || (c == "á") || (c == "à") || (c == "å") || (c == "ã") || (c == "ä"))
                {
                    if (i == 2)
                    {
                        c = c.ToUpper();
                    }
                    else
                    {
                        if (vnstr.Substring((int)((i - 2) - 1), 1) == " ")
                        {
                            c = c.ToUpper();
                        }
                    }
                }
                tempProperVni = tempProperVni + c;
            }
            if (vnstr.Length == 0)
            {
                tempProperVni = "";
            }
            return tempProperVni;
        }
        public static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",  
            "đ",  
            "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",  
            "í","ì","ỉ","ĩ","ị",  
            "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",  
            "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",  
            "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",  
                "d",  
                "e","e","e","e","e","e","e","e","e","e","e",  
                "i","i","i","i","i",  
                "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",  
                "u","u","u","u","u","u","u","u","u","u","u",  
                "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }  
    }
}