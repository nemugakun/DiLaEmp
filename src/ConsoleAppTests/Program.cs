// 1. Definimos las culturas que queremos comparar
using System.Globalization;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

CultureInfo culturaES = new CultureInfo("es-ES"); // Español (España)
CultureInfo culturaEN = new CultureInfo("en-US"); // Inglés (EE. UU.)

Console.WriteLine(string.Format("{0,-15} | {1,-15} | {2,-15}", "DayOfWeek Enum", "Español", "Inglés"));
Console.WriteLine(new string('-', 50));

// 2. Iteramos sobre los valores de la enumeración DayOfWeek (0 al 6)

List<DayOfWeek> week = new List<DayOfWeek>();

CultureInfo culture = new CultureInfo("ar-SA"); // CultureInfo.CurrentCulture
DayOfWeek firstDay = culture.DateTimeFormat.FirstDayOfWeek;
for (int i = 0; i < 7; i++)
{
    week.Add((DayOfWeek)(((int)firstDay + i) % 7));
}
Console.WriteLine(firstDay + " -F- " + culture.DateTimeFormat.GetDayName(firstDay));
foreach (DayOfWeek dayOfWeek in week)
{
    Console.WriteLine(dayOfWeek + " - " + culture.DateTimeFormat.GetDayName(dayOfWeek));
}
foreach (DayOfWeek dia in Enum.GetValues(typeof(DayOfWeek)))
{
    // 3. Usamos GetDayName pasando el valor de la enumeración
    string nombreES = culturaES.DateTimeFormat.GetDayName(dia);
    string nombreEN = culturaEN.DateTimeFormat.GetDayName(dia);

    Console.WriteLine(string.Format("{0,-15} | {1,-15} | {2,-15}", dia, nombreES, nombreEN));
}