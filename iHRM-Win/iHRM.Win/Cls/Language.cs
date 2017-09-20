using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace iHRM.Win
{
    public class Language
    {
        private static eLanguage _currentLng = eLanguage.VN;
        public static eLanguage CurrentLng
        {
            get { return _currentLng; }
        }
        
    }
}