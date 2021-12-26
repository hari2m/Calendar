using System;
using Calendar.Impl;
using Xunit;

namespace CalendarTests
{
    public class CalendarServiceTests
    {
        private readonly CalendarService _service;

        public CalendarServiceTests()
        {
            _service = new CalendarService();
        }

        [Fact]
        public void IsWeekend_Saturday_Test1()
        {
            Assert.True(_service.IsWeekend(new DateTime(2021, 12, 25)));
        }

        [Fact]
        public void IsWeekend_Sunday_Test1()
        {
            Assert.True(_service.IsWeekend(new DateTime(2021, 12, 26)));
        }

        [Fact]
        public void IsWeekend_Saturday_Test2()
        {
            Assert.True(_service.IsWeekend( new DateTime(2021, 11, 13)));
        }

        [Fact]
        public void IsWeekend_Sunday_Test2()
        {
            Assert.True(_service.IsWeekend( new DateTime(2021, 11, 14)));
        }

        [Fact]
        public void IsWeekend_Monday()
        {
            Assert.False(_service.IsWeekend(new DateTime(2021, 11, 08)));
        }

        [Fact]
        public void IsWeekend_Tuesday()
        {
            Assert.False(_service.IsWeekend(new DateTime(2021, 11, 9)));
        }

        [Fact]
        public void IsWeekend_Wednesday()
        {
            Assert.False(_service.IsWeekend(new DateTime(2021, 11, 10)));
        }

        [Fact]
        public void IsWeekend_Thursday()
        {
            Assert.False(_service.IsWeekend(new DateTime(2021, 11, 11)));
        }

        [Fact]
        public void IsWeekend_Friday()
        {
            Assert.False(_service.IsWeekend(new DateTime(2021, 11, 12)));
        }
    }
}
