using System;
using System.Collections.Generic;

namespace Calendar.Interface
{
    public interface ICalendarService
    {
        bool IsWeekend(DateTime date);
    }
}