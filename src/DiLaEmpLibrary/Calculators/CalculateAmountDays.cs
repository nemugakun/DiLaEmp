using DiLaEmpLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiLaEmpLibrary.Calculators
{
    public static class CalculateAmountDays
    {
        public static (int, decimal) CalculateDays(
            DateOnly start,
            DateOnly end,
            IDictionary<DayOfWeek, decimal> hoursByDay,
            ICollection<DateOnly>? holidays = null)
        {
            int days = 0;
            decimal hours = 0;
            DateOnly iDay = start;
            DateOnly endPlusOne = end.AddDays(1);
            while (iDay < endPlusOne)
            {
                if (CalculatorsUtils.IsLaboralDay(iDay, hoursByDay, holidays))
                {
                    days++;
                    hours += hoursByDay[iDay.DayOfWeek];
                }
                iDay = iDay.AddDays(1);
            }
            return (days, hours);
        }
    }
}
