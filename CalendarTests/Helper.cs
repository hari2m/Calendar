using System;
using System.Collections.Generic;
using Xunit;

namespace CalendarTests
{
    public class Helper
    {
        public static void CheckDate(string expected, DateTime actual)
        {
            Assert.Equal(expected, actual.ToString("MM/dd/yyyy"));
        }

        public static void CheckDates(string[] expected, IReadOnlyCollection<DateTime> actual)
        {
            var iterator = 0;
            Assert.Equal(expected.Length, actual.Count);
            foreach (var date in actual)
            {
                Assert.Equal(expected[iterator], date.ToString("MM/dd/yyyy"));
                iterator++;
            }
        }
    }
}
