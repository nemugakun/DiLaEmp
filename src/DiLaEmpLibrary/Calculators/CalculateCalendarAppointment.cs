using DiLaEmp.Utils.Calendar.Objects;
using DiLaEmpLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiLaEmpLibrary.Calculators
{
    public static class CalculateCalendarAppointment
    {
        public static SortedSet<CalendarAppointment> GenerateCalendarAppointments(
            DateOnly startDate, DateOnly endDate, SortedDictionary<DayOfWeek, decimal> hoursByDay, 
            SortedSet<DateOnly> holidaysInDateOnly, string workingText, string holidayText)
        {
            SortedSet<CalendarAppointment> appointments = new SortedSet<CalendarAppointment>();

            DateOnly iDate = startDate;
            DateOnly endDatePlusOne = endDate.AddDays(1);
            CalendarAppointment? appointment = null;
            StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;

            Console.WriteLine("End date: " + endDate);
            Console.WriteLine("End date + 1: " + endDatePlusOne);
            while (iDate < endDatePlusOne)
            {
                if (appointment is null)
                {
                    appointment = new CalendarAppointment
                    {
                        Start = DateUtils.GetDateTimeFromDateOnly(iDate)
                    };
                }
                if (CalculatorsUtils.IsLaboralDay(iDate, hoursByDay, holidaysInDateOnly))
                {
                    appointment = HandleAppointment(workingText, appointments, iDate, appointment, comparison);
                }
                else
                {
                    appointment = HandleAppointment(holidayText, appointments, iDate, appointment, comparison);
                }

                iDate = iDate.AddDays(1);
            }
            iDate = iDate.AddDays(-1);
            if (appointment is not null &&
                ! string.IsNullOrEmpty(appointment.Text))
            {
                appointment.End = DateUtils.GetDateTimeFromDateOnly(iDate);
                appointments.Add(appointment);
            }

            return appointments;
        }

        private static CalendarAppointment HandleAppointment(
            string dayTypeText, 
            SortedSet<CalendarAppointment> appointments, 
            DateOnly iDate, 
            CalendarAppointment appointment, 
            StringComparison comparison)
        {
            if (string.IsNullOrEmpty(appointment.Text))
            {
                appointment.Text = dayTypeText;
            }
            else if (!string.Equals(appointment.Text, dayTypeText, comparison))
            {
                appointment.End = DateUtils.GetDateTimeFromDateOnly(iDate.AddDays(-1));
                appointments.Add(appointment);
                appointment = new CalendarAppointment
                {
                    Start = DateUtils.GetDateTimeFromDateOnly(iDate),
                    Text = dayTypeText
                };
            }

            return appointment;
        }
    }
}
