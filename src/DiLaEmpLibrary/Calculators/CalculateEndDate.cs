using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DiLaEmpLibrary.Calculators
{
    public class CalculateEndDate
    {
        public static (DateOnly, decimal) CalculateTheEndDate(
            DateOnly start,
            int hours,
            decimal hoursByDay,
            Collection<DateOnly>? holidays = null)
        {
            decimal days = hours / hoursByDay;
            decimal remainingDays = days;

            //Console.WriteLine("Días " + days);
            DateOnly end = start;
            while (remainingDays > 0)
            {
                if (NeitherWeekendNorHolidays(end, holidays))
                {
                    remainingDays--;
                }
                end = end.AddDays(1);
            }
            end = end.AddDays(-1);

            //Console.WriteLine(end);

            return (end, days);
        }

        private static bool NeitherWeekendNorHolidays(DateOnly end, Collection<DateOnly>? holidays)
        {
            return 
                end.DayOfWeek != DayOfWeek.Saturday &&
                end.DayOfWeek != DayOfWeek.Sunday &&
                (holidays == null || !holidays.Contains(end));
        }

    }
}
