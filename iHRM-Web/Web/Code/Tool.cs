using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Ext.Net;

namespace iHRM.WebPC.Code
{
    public class Tools
    {

        /// <summary>
        /// Ma Hoa Quá trình mã hóa: 
        /// toEncrypt: Chuỗi cần mã hóa  
        /// key: Chuỗi key mã hóa (24 kí tự)
        /// useHashing: sử dụng MD5 hay không
        ///</summary>
        public static string Encrypt(string toEncrypt, string key, bool useHashing = true)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string EncryptPW(string pw)
        {
            return Encrypt(pw, "ENCRYPT_DECRYPT_PW_KEY1", true);
        }

        /// <summary>
        /// Quá trình giải mã: 
        /// toEncrypt: Chuỗi cần mã hóa  
        /// key: Chuỗi key mã hóa (24 kí tự)
        /// useHashing: sử dụng MD5 hay không
        ///</summary>
        public static string Decrypt(string toDecrypt, string key, bool useHashing = true)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                }
                else
                {
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);
                }
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch
            {
                return "";
            }
        }
        public static string DecryptPW(string pw)
        {
            return Decrypt(pw, "ENCRYPT_DECRYPT_PW_KEY1", true);
        }

        /// <summary>
        /// Chuẩn hóa lại xâu nếu có nhiều khoảng trắng
        /// </summary>
        /// <param name="xau"></param>
        /// <returns></returns>
        public static string ChuanHoaXau(string xau)
        {
            StringBuilder kq = new StringBuilder();
            xau = xau.Trim();
            for (int i = 0; i < xau.Length; i++)
            {
                kq.Append(xau[i]);
                if (xau[i] == ' ')
                {
                    while (xau[i] == ' ')
                    {
                        i++;
                    }
                    kq.Append(xau[i]);
                }
            }
            return kq.ToString();
        }

        public static void messageEx(Exception ex, string msg = "Has exception while execute...")
        {
            X.Msg.Show(new MessageBoxConfig
            {
                Buttons = MessageBox.Button.OK,
                Icon = MessageBox.Icon.ERROR,
                Title = "Lỗi",
                Message = string.Format("{2}<br /><b>Source</b>: {0}<br /><b>Message</b>: {1}", ex.Source, ex.Message, msg)
            });
        }

        /// <summary>
        /// Thông báo 
        /// </summary>
        /// <param name="message"></param>
        public static void message(string message, string title = "Thông báo", Icon ico = Icon.Comments, bool autoHide = true, int height = 80, int width = 220)
        {
            Notification.Show(new NotificationConfig
            {
                AlignCfg = new NotificationAlignConfig
                {
                    ElementAnchor = AnchorPoint.Center,
                    TargetAnchor = AnchorPoint.Center,
                    OffsetX = 0,
                    OffsetY = 0
                },
                HideFx = new FadeOut { Options = new FadeOutConfig { Duration = 3, EndOpacity = 0.25f } },
                PinEvent = "none",
                Height = height,
                Width = width,
                AutoHide = autoHide,
                Closable = !autoHide,
                CloseVisible = !autoHide,
                HideDelay = 1800,
                Html = message,
                Title = title,
                Icon = ico,
                Resizable = false,
                Shadow = true,
                AutoScroll = true
            });
        }

        public static void messageConfirmErr(string message, string title = "Lỗi ngoại lệ")
        {
            X.Msg.Show(new MessageBoxConfig
            {
                Buttons = MessageBox.Button.OK,
                Icon = MessageBox.Icon.WARNING,
                Title = title,
                Message = message
            });

            return;
        }
        public static void messageConfirmSuccess(string message, string title = "Thông báo")
        {
            X.Msg.Show(new MessageBoxConfig
            {
                Buttons = MessageBox.Button.OK,
                Icon = MessageBox.Icon.INFO,
                Title = title,
                Message = message
            });

            return;
        }
        public static bool IsNumberDigit(string strInput)
        {
            return Regex.IsMatch(strInput, "^[0-9]+$", RegexOptions.Compiled);
        }

        public static string ReplaceHackCode(string strSource)
        {
            string str = strSource;
            if (!string.IsNullOrEmpty(str))
            {
                return str.Replace("'", "&#39;").Replace("\"", "&#34;").Replace("<", "&lt;").Replace(">", "&gt;");
            }
            else return str;
        }

        public static string GetStringStandard(string strContent)
        {
            return strContent.Replace("" + (char)13, "<br />");
        }

        public static string CatTietDe(string title, int len)
        {
            if (string.IsNullOrWhiteSpace(title))
                return title;

            if (title.Length <= len)
                return title;

            string s = title.Substring(0, len);
            int i = s.LastIndexOf(' ');
            if (i > s.Length / 2)
                s = s.Substring(0, i);

            if (!string.IsNullOrWhiteSpace(s))
                s += " ...";

            return s;
        }


        public static string HashPassword(string password)
        {
            SHA1CryptoServiceProvider PWD_CRYPTO = new SHA1CryptoServiceProvider();
            try
            {
                if (password == null)
                    throw new ArgumentNullException("password");

                byte[] encryptedBytes = PWD_CRYPTO.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder sb = new StringBuilder();
                foreach (byte b in encryptedBytes) sb.AppendFormat("{0:x2}", b);

                return sb.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static string EncodeToSHA1(string value)
        {
            try
            {
                UnicodeEncoding uEncode = new UnicodeEncoding();
                byte[] byteValue = uEncode.GetBytes(value);
                SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
                byte[] hash = sha1.ComputeHash(byteValue);
                return BitConverter.ToString(hash);
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Sinh chuoi ngau nhien
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            try
            {
                Random r = new Random(Environment.TickCount);
                string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
                StringBuilder builder = new StringBuilder(length);

                for (int i = 0; i < length; ++i)
                {
                    builder.Append(chars[r.Next(chars.Length)]);
                }
                return builder.ToString();
            }
            catch
            {
                return "";
            }
        }

    }
}