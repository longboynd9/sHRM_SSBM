using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iHRM.Core.Business.Logic.ChamCong
{
    public class DoubleIntegerObject
    {
        private long lngFirst;
        private long lngLast;

        public long getLngFirst()
        {
            return lngFirst;
        }

        public void setLngFirst(long int1)
        {
            this.lngFirst = int1;
        }

        public long getLngLast()
        {
            return lngLast;
        }

        public void setLngLast(long int2)
        {
            this.lngLast = int2;
        }
    
    }
}