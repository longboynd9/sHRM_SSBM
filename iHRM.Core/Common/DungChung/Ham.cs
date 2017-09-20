using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHRM.Common.DungChung
{
    public static class Ham
    {
        /// <summary>
        /// đếm số ngày công (trừ chủ nhật)
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static int DemNgayCong(DateTime startDate, DateTime endDate)
        {
            int c = 0;
            while (startDate <= endDate)
            {
                if (startDate.DayOfWeek != DayOfWeek.Sunday)
                    c += 1;

                startDate = startDate.AddDays(1);
            }
            return c;
        }
    }
}
