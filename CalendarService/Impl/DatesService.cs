using System;
using System.Collections.Generic;
using System.Linq;
using Calendar.Enums;

namespace Calendar.Impl
{
    public class DatesService
    {
        private readonly int[] _monthsWith30Days;
        private readonly int[] _monthsWith31Days; 

        public DatesService()
        {
            _monthsWith30Days = new [] { 4, 6, 9, 11};
            _monthsWith31Days = new [] { 1, 3, 5, 7, 8, 10, 12 };
        }

        /// <summary>
        /// This method will give you the list of dates that you will get paid
        /// </summary>
        /// <param name="payType">This is PayTypes Enum which will be used to calculate how frequent you will get paid</param>
        /// <param name="startDate">This is the Start Date of the Pay period, this should be the pay date</param>
        /// <param name="endDate">This is the end date till which the pay dates need to be generated</param>
        /// <returns></returns>
        public List<DateTime> GeneratePayDates(PayTypes payType, DateTime startDate, DateTime endDate)
        {
            var dates = new List<DateTime>();
            var iterate = true;
            var iterator = 1;
            while (iterate)
            {
                var nextDate = GetNthPayDateFromStartDate(payType, startDate, iterator);
                iterator++;
                if (nextDate < endDate)
                    dates.Add(nextDate.Date);
                else iterate = false;
            }

            return dates;
        }

        public DateTime GetNthPayDateFromStartDate(PayTypes payType, DateTime startDate, int n)
        {
            switch (payType)
            {
                case PayTypes.Monthly:
                    return GetForMonthlyPayType(startDate, n);
                case PayTypes.SemiMonthly:
                    return GetForSemiMonthlyPayType(startDate, n);
                case PayTypes.BiWeekly:
                    return startDate.AddDays(14 * n);
                case PayTypes.Weekly:
                    return startDate.AddDays(7 * n);
                default:
                    throw new ArgumentOutOfRangeException(nameof(payType), payType, "The system cannot recognize the given PayType");
            }
        }

        private DateTime GetForSemiMonthlyPayType(DateTime startDate, int i)
        {
            var awayFromZeroValue = Convert.ToDecimal(i / 2.0) + 0.1M;
            if (startDate.Day > 15 && DateTime.DaysInMonth(startDate.Year, startDate.Month) == startDate.Day)
            {
                if (i % 2 != 0)
                {
                    var nextPossibleDate = startDate.AddMonths(Convert.ToInt16(decimal.Round(awayFromZeroValue, MidpointRounding.AwayFromZero)));
                    return new DateTime(nextPossibleDate.Year, nextPossibleDate.Month, 15);
                }
                else
                {
                    var nextPossibleDate = startDate.AddMonths(i / 2);
                    var day = _monthsWith30Days.Contains(nextPossibleDate.Month) ? 30 :
                        _monthsWith31Days.Contains(nextPossibleDate.Month) ? 31 :
                        DateTime.IsLeapYear(nextPossibleDate.Year) ? 29 : 28;
                    return new DateTime(nextPossibleDate.Year, nextPossibleDate.Month, day);
                }
            }

            if (i % 2 != 0)
            {
                var nextPossibleDate = startDate.AddMonths(i / 2);
                var day = _monthsWith30Days.Contains(nextPossibleDate.Month) ? 30 :
                    _monthsWith31Days.Contains(nextPossibleDate.Month) ? 31 :
                    DateTime.IsLeapYear(nextPossibleDate.Year) ? 29 : 28;
                return new DateTime(nextPossibleDate.Year, nextPossibleDate.Month, day);
            }
            else
            {
                var nextPossibleDate = startDate.AddMonths(i / 2);
                return new DateTime(nextPossibleDate.Year, nextPossibleDate.Month, 15);
            }
        }

        private DateTime GetForMonthlyPayType(DateTime startDate, int n)
        {
            var newDate = startDate.AddMonths(1 * n);
            if (_monthsWith30Days.Contains(newDate.Month) && startDate.Day == 31)
                return new DateTime(newDate.Year, newDate.Month, 30);
            return newDate.Month == 2 ? GetFebruaryDate(newDate, startDate.Day) : newDate;
        }

        public DateTime GetFebruaryDate(DateTime newDate, int startDateDay)
        {
            if(startDateDay > 31) throw new ArgumentOutOfRangeException(nameof(startDateDay), "We only deal with english calendar");
            if (startDateDay <= 28) return newDate;
            if (!DateTime.IsLeapYear(newDate.Year)) return new DateTime(newDate.Year, newDate.Month, 28);
            return startDateDay > 29 ? new DateTime(newDate.Year, newDate.Month, 29) : newDate;
        }

        /// <summary>
        /// This method will return the next pay date, by default it will assume Monthly payments
        /// </summary>
        /// <param name="payType">Frequency at which the payment is made</param>
        /// <param name="startDate">The pay date after which the next pay date needs to be generated</param>
        /// <param name="iterator"></param>
        /// <returns></returns>
        public DateTime GetNextPayDateWithIteration(PayTypes payType, DateTime startDate, int iterator)
        {
            switch (payType)
            {
                case PayTypes.Monthly:
                    var newDate = startDate.AddMonths(1 * iterator);
                    return new DateTime(newDate.Year, newDate.Month, startDate.Day);
                case PayTypes.SemiMonthly:
                    return startDate.AddMonths(1 / 2 * iterator);
                case PayTypes.BiWeekly:
                    return startDate.AddDays(14 * iterator);
                case PayTypes.Weekly:
                    return startDate.AddDays(7 * iterator);
            }

            return startDate.AddMonths(1);
        }
    }
}
