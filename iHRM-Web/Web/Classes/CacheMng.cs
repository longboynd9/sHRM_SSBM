using System;
using System.Web;
using System.Linq;
using System.Runtime.Caching;
using System.Collections.Generic;
using iHRM.WebPC.Code; using iHRM.Common.Code;

namespace iHRM.WebPC.Classes
{
    public class CacheEnums
    {
        public enum KeyCache
        {
            none,
            UserControl //cache nguyen 1 usser control (kem sub key)
        }
    }

    public class CacheMng
    {
        static readonly ObjectCache ObjCache = MemoryCache.Default;

        public static object Get(CacheEnums.KeyCache key, string SubKey = "")
        {
            if (!string.IsNullOrWhiteSpace(SubKey))
                SubKey = "###" + SubKey;
            if (_Has(key.ToString() + SubKey))
                return ObjCache[key.ToString() + SubKey];

            return null;
        }

        public static void Add(object objectToCache, CacheEnums.KeyCache key, string SubKey = "", DateTime? EndTime = null)
        {
            if (!string.IsNullOrWhiteSpace(SubKey))
                SubKey = "###" + SubKey;

            var c = ObjCache.GetCacheItem(key.ToString() + SubKey);
            if (c == null)
            {
                if (EndTime.HasValue)
                {
                    ObjCache.Add(key.ToString() + SubKey, objectToCache, EndTime.Value);
                }
                else
                {
                    ObjCache.Add(key.ToString() + SubKey, objectToCache, DateTime.Now.AddDays(1));
                }
            }
            else
            {
                c.Value = objectToCache;
            }
        }

        public static void Remove(CacheEnums.KeyCache key, string SubKey = "")
        {
            if (!string.IsNullOrWhiteSpace(SubKey))
                SubKey = "###" + SubKey;

            if (_Has(key.ToString() + SubKey))
                ObjCache.Remove(key.ToString() + SubKey);

            foreach (string k in ObjCache.Where(i => i.Key.StartsWith(key + "###")).Select(i => i.Key))
                ObjCache.Remove(k);
        }

        public static bool Has(CacheEnums.KeyCache key, string SubKey = "")
        {
            if (!string.IsNullOrWhiteSpace(SubKey))
                SubKey = "###" + SubKey;
            return ObjCache.Contains(key.ToString() + SubKey);
        }
        private static bool _Has(string key)
        {
            return ObjCache.Contains(key);
        }

        public static void Clear()
        {
            while (ObjCache.Count() > 0)
                ObjCache.Remove(ObjCache.First().Key);
        }

        public static void SaveCacheFile(string path, string data)
        {
            System.IO.File.WriteAllText(HttpContext.Current.Server.MapPath("~/CacheFiles/" + path), data);
        }
        public static string GetCacheFile_Ajax(string path)
        {
            return string.Format("<div id='load{0}'><script>$('#load{0}').load('/CacheFiles/{1}');</script></div>", Guid.NewGuid().ToString("N"), path);
        }
    }
}