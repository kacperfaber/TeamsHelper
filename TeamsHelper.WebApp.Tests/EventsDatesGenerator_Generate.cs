using System;
using Xunit;

namespace TeamsHelper.WebApp.Tests
{
    public class EventsDatesGenerator_Generate
    {
        EventsDates exec(DateTime dt)
        {
            EventsDatesGenerator generator = new EventsDatesGenerator();
            return generator.Generate(dt);
        }

        [Fact]
        public void DontThrows()
        {
            exec(new DateTime(2020, 1, 1, 12, 0, 0));
        }

        [Fact]
        public void NotNull()
        {
            EventsDates dates = exec(new DateTime(2020, 1, 1, 12, 0, 0));
            
            Assert.NotNull(dates);
        }

        [Fact]
        public void ExpectedDayStartingAt()
        {
            DateTime dt = new DateTime(2020, 1, 1, 12, 0, 0);
            EventsDates dates = exec(dt);

            Assert.True(dates.DayStartingAt == dt.Date);
        }
        
        [Fact]
        public void ExpectedDayEndingAt()
        {
            DateTime dt = new DateTime(2020, 1, 1, 12, 0, 0);
            EventsDates dates = exec(dt);

            Assert.True(dates.DayEndingAt == new DateTime(2020, 1, 15, 23, 59, 59));
        }
    }
}