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

        public static DateTime GetDateTimeFromDateOnly(DateOnly dt, bool maxTimeOnly = false)
        {
            return dt.ToDateTime(maxTimeOnly ? TimeOnly.MinValue : TimeOnly.MaxValue);
        }

        public static DayOfWeek GetDayOfWeekFromDateTime(DateTime dt)
        {
            return dt.DayOfWeek;
        }

        public static SortedSet<DateOnly> GetDateOnlysFromDateTimes(ICollection<DateTime?> dates)
        {
            SortedSet<DateOnly> dateOnlyHolidays = new SortedSet<DateOnly>();
            foreach (var date in dates)
            {
                if (date is not null)
                {
                    dateOnlyHolidays.Add(DateOnly.FromDateTime(date.Value));
                }
            }
            return dateOnlyHolidays;
        }

        public static SortedSet<DateTime?> GetDateTimesFromDateOnlys(SortedSet<DateOnly> dates)
        {
            SortedSet<DateTime?> dateTimes = new SortedSet<DateTime?>();
            foreach (var date in dates)
            {
                dateTimes.Add(date.ToDateTime(TimeOnly.MinValue));
            }
            return dateTimes;
        }
    }
}
