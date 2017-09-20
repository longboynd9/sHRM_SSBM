using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHRM.Common.Code
{
    public class BitHelper
    {
        /// <summary>
        /// kiểm tra số i trong value ko
        /// </summary>
        /// <param name="value">giá trị muốn kiểm tra</param>
        /// <param name="stt">stt</param>
        /// <returns></returns>
        public static bool Has(long value, long i)
        {
            return (value & i) == i;
        }

        /// <summary>
        /// thêm giá trị i vào value
        /// </summary>
        /// <param name="value">giá trị muốn kiểm tra</param>
        /// <param name="stt">stt</param>
        /// <returns></returns>
        public static long Add(long value, long i)
        {
            return value | i;
        }

        /// <summary>
        /// xóa giá trị i trong value
        /// </summary>
        /// <param name="value">giá trị muốn kiểm tra</param>
        /// <param name="stt">stt</param>
        /// <returns></returns>
        public static long Del(long value, long i)
        {
            return value & (int.MaxValue ^ i);
        }
    }
}