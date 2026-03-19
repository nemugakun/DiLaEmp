using System;
using System.Collections.Generic;
using System.Text;

namespace DiLaEmpLibrary.Utils
{
    public static class DateUtils
    {
        public static DateOnly GetDateOnlyFromDateTime(DateTime dt)
        {
            return DateOnly.FromDateTime(dt);
        }

        public static DayOfWeek GetDayOfWeekFromDateTime(DateTime dt)
        {
            return dt.DayOfWeek;
        }
    }
}
