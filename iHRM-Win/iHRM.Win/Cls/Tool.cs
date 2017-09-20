using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace iHRM.Win.Cls
{
    public class Tools
    {
        private const string ENCRYPT_DECRYPT_PW_KEY = "ENCRYPT_DECRYPT_PW_KEY1";

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
            return Encrypt(pw, ENCRYPT_DECRYPT_PW_KEY, true);
        }

        /// <summary>
        /// Computes a salted hash of the password and salt provided and returns as a base64 encoded string.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <param name="salt">The salt to use in the hash.</param>
        public static string EncryptOneWay(string password, string salt)
        {
            // merge password and salt together
            string sHashWithSalt = password + salt;
            // convert this merged value to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(sHashWithSalt);
            // use hash algorithm to compute the hash
            System.Security.Cryptography.HashAlgorithm algorithm = new System.Security.Cryptography.SHA256Managed();
            // convert merged bytes to a hash as byte array
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // return the has as a base 64 encoded string
            return Convert.ToBase64String(hash);
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
            return Decrypt(pw, ENCRYPT_DECRYPT_PW_KEY, true);
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



        public static byte[] Image2ByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
        }
        public static Image ByteArray2Image(byte[] imageByte)
        {
            MemoryStream ms = new MemoryStream(imageByte);
            Image image = Image.FromStream(ms);
            return image;
        }

    }
}