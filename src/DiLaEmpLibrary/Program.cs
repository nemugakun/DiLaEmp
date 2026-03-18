/*using System.Collections.ObjectModel;

DateOnly start = new DateOnly(2026, 3, 18);
int hours = 400;
double hoursByDay = 8;
Collection<DateOnly> holidays = [
    //new DateOnly(2026, 3, 20),
    new DateOnly(2026, 3, 30),
    new DateOnly(2026, 3, 31),
    new DateOnly(2026, 4, 1),
    new DateOnly(2026, 4, 2),
    new DateOnly(2026, 4, 3),
    new DateOnly(2026, 4, 6),
    new DateOnly(2026, 4, 7),
    new DateOnly(2026, 5, 1),
    new DateOnly(2026, 5, 4),
    new DateOnly(2026, 6, 8),
    new DateOnly(2026, 6, 9)
];



double days = hours / hoursByDay;

Console.WriteLine("Días " + days);
DateOnly end = start;
while (days > 0)
{
    if (NeitherWeekendNorHolidays(end, holidays))
    {
        days--;
    }
    end = end.AddDays(1);
}
end = end.AddDays(-1);

Console.WriteLine(end);

static bool NeitherWeekendNorHolidays(DateOnly end, Collection<DateOnly> holidays) => 
    end.DayOfWeek != DayOfWeek.Saturday && 
    end.DayOfWeek != DayOfWeek.Sunday &&
    ! holidays.Contains(end)
    ;
*/