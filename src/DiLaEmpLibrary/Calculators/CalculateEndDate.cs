using DiLaEmpLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiLaEmpLibrary.Calculators
{
    public class CalculateEndDate
    {
        public static (DateOnly, decimal) CalculateTheEndDate(
            DateOnly start,
            decimal hours,
            IDictionary<DayOfWeek, decimal> hoursByDay,
            ICollection<DateOnly>? holidays = null)
        {
            decimal days = 0;
            decimal remainingHours = hours;

            //Console.WriteLine("Días " + days);
            DateOnly iDay = start;
            while (remainingHours > 0)
            {
                if (isLaboralDay(iDay, hoursByDay, holidays))
                {
                    remainingHours -= hoursByDay[iDay.DayOfWeek];
                    days++;
                }
                iDay = iDay.AddDays(1);
            }
            DateOnly end = iDay.AddDays(-1);

            //Console.WriteLine(end);

            return (end, days);
        }

        private static bool isLaboralDay(
            DateOnly day, 
            IDictionary<DayOfWeek, decimal> hoursByDay, 
            ICollection<DateOnly>? holidays
            )
        {
            bool isLaboralDay = false;
            if (dayOfTheWeekIsInHoursByDayVariable(day, hoursByDay))
            {
                // The day variable is in the hoursByDay variable, so we can check if it has more than 0 hours.
                if (dayOfTheWeekHasMoreThanZeroHours(day, hoursByDay))
                {
                    // The day variable has more than 0 hours, so we can check if it is a holiday or not.
                    if (holidays != null && holidays.Contains(day))
                    {
                        // Is a holiday day.
                        isLaboralDay = false;
                    }
                    else
                    {
                        // Is a laboral day.
                        isLaboralDay = true;
                    }
                }
            }
            return isLaboralDay;

        }

        private static bool dayOfTheWeekHasMoreThanZeroHours(DateOnly day, IDictionary<DayOfWeek, decimal> hoursByDay)
        {
            return hoursByDay[day.DayOfWeek] > 0;
        }

        private static bool dayOfTheWeekIsInHoursByDayVariable(DateOnly day, IDictionary<DayOfWeek, decimal> hoursByDay)
        {
            return hoursByDay.ContainsKey(day.DayOfWeek);
        }
    }
}
