using System;
using System.Collections.Generic;
using Calendar.Enums;

namespace Calendar.Interface
{
    public interface IPayDatesService
    {
        List<DateTime> GeneratePayDates(PayTypes payType, DateTime startDate, DateTime endDate);
        DateTime GetNextPayDate(PayTypes payType, DateTime startDate);
    }
}
