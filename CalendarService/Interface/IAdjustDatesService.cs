using System;
using System.Collections.Generic;
using Calendar.Enums;

namespace Calendar.Interface
{
    public interface IAdjustDatesService
    {
        DateTime AdjustDate(DateTime dateToAdjust, BusinessDateConvention convention);
        List<DateTime> AdjustDates(List<DateTime> datesToAdjust, BusinessDateConvention convention);
    }
}
