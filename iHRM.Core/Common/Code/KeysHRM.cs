using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace iHRM.Common.Code
{
    public static class KeysHRM
    {
        static string[] strSeparator = new string[] { "!@#$%^" };
        public static string GetIDCPU()
        {
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();
            string cpuid = "";

            foreach (ManagementObject managObj in managCollec)
            {
                cpuid += managObj.Properties["processorID"].Value.ToString();
            }
            return cpuid;
        }
        public static string GetMacAddress()
        {
            string macAddresses = "";

            foreach (System.Net.NetworkInformation.NetworkInterface nic in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
            {
                macAddresses = nic.GetPhysicalAddress().ToString();
                if (!string.IsNullOrWhiteSpace(macAddresses))
                    break;
            }
            return macAddresses;
        }
        public static string getIDCPUFromKey(string key)
        {
            string idcpu = "";
            idcpu += key.Split(strSeparator, StringSplitOptions.None)[0];
            return idcpu;
        }
        public static DateTime getDateStartFromKey(string key)
        {
            string d = "";
            d += key.Split(strSeparator, StringSplitOptions.None)[1];
            return Convert.ToDateTime(d);
        }
        public static int getNumdayFromKey(string key)
        {
            string num = "";
            num += key.Split(strSeparator, StringSplitOptions.None)[2];
            return Convert.ToInt32(num);
        }
        public static string Decrypt(string toDecrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
            if (useHashing)
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes("Longit93nd"));
            }
            else keyArray = Encoding.UTF8.GetBytes("Longit93nd");
            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Encoding.UTF8.GetString(resultArray);
        }
    }
}
