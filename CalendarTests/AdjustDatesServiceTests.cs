using System;
using Calendar.Enums;
using Calendar.Impl;
using Xunit;

namespace CalendarTests
{
    public class AdjustDatesServiceTests
    {
        private readonly AdjustDatesService _service;

        public AdjustDatesServiceTests()
        {
            var calendarService = new CalendarService();
            _service = new AdjustDatesService(calendarService);
        }

        [Fact]
        public void AdjustDate_Saturday()
        {
            Helper.CheckDate("12/24/2021", _service.AdjustDate(new DateTime(2021, 12, 25), BusinessDateConvention.Preceding));
        }

        [Fact]
        public void AdjustDate_Sunday()
        {
            Helper.CheckDate("12/24/2021", _service.AdjustDate(new DateTime(2021, 12, 26), BusinessDateConvention.Preceding));
        }

        [Fact]
        public void AdjustDate_Friday()
        {
            Helper.CheckDate("12/24/2021", _service.AdjustDate(new DateTime(2021, 12, 24), BusinessDateConvention.Preceding));
        }

        [Fact]
        public void AdjustDate_Thursday()
        {
            Helper.CheckDate("12/23/2021", _service.AdjustDate(new DateTime(2021, 12, 23), BusinessDateConvention.Preceding));
        }

        [Fact]
        public void AdjustDate_Wednesday()
        {
            Helper.CheckDate("12/22/2021", _service.AdjustDate(new DateTime(2021, 12, 22), BusinessDateConvention.Preceding));
        }

        [Fact]
        public void AdjustDate_Tuesday()
        {
            Helper.CheckDate("12/21/2021", _service.AdjustDate(new DateTime(2021, 12, 21), BusinessDateConvention.Preceding));
        }

        [Fact]
        public void AdjustDate_Monday()
        {
            Helper.CheckDate("12/20/2021", _service.AdjustDate(new DateTime(2021, 12, 20), BusinessDateConvention.Preceding));
        }
    }
}
