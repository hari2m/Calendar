using System;
using System.Collections.Generic;
using System.Linq;
using Calendar.Enums;
using Calendar.Interface;

namespace Calendar.Impl
{
    public class AdjustDatesService : IAdjustDatesService
    {
        private readonly ICalendarService _calendarService;

        public AdjustDatesService(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        public DateTime AdjustDate(DateTime dateToAdjust, BusinessDateConvention convention)
        {
            while (_calendarService.IsWeekend(dateToAdjust))
            {
                dateToAdjust = convention == BusinessDateConvention.Preceding ? dateToAdjust.AddDays(-1) : dateToAdjust.AddDays(1);
            }
            return dateToAdjust;
        }

        public List<DateTime> AdjustDates(List<DateTime> datesToAdjust, BusinessDateConvention convention)
        {
            return datesToAdjust.Select(date => AdjustDate(date, convention)).ToList();
        }
    }
}
