using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DiLaEmpLibrary.Utils
{
    public static class DayOfWeekUtils
    {
        public static DayOfWeek NextDayOfWeek(DayOfWeek day)
        {
            return (DayOfWeek)(((int)day + 1) % 7);
        }

        public static List<DayOfWeek> GetWeekFromCulture(CultureInfo culture)
        {
            List<DayOfWeek> week = new List<DayOfWeek>();
            DayOfWeek firstDay = culture.DateTimeFormat.FirstDayOfWeek;
            for (int i = 0; i < 7; i++)
            {
                week.Add((DayOfWeek)(((int)firstDay + i) % 7));
            }
            return week;
        }

        public static string GetNameOfDayOfWeek(DayOfWeek day, CultureInfo culture)
        {
            return culture.DateTimeFormat.GetDayName(day);
        }

        public static List<DayOfWeek> GetWeekFromCurrentCulture()
        {
            return GetWeekFromCulture(CultureInfo.CurrentCulture);
        }
    }
}
