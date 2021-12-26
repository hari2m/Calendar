using System;
using Calendar.Interface;

namespace Calendar.Impl
{
    public class CalendarService : ICalendarService
    {
        public bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday;
        }
    }
}