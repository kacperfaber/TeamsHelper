using System;
using TeamsHelper.CalendarApi;
using Xunit;

namespace TeamsHelper.WebApp.Tests
{
    public class GoogleTimeGenerator_Generate
    {
        [Fact]
        public void DontThrows()
        {
            GoogleTimeGenerator generator = new GoogleTimeGenerator();

            generator.Generate(default);
        }

        [Fact]
        public void ExpectedDateTime()
        {
            GoogleTimeGenerator generator = new GoogleTimeGenerator();

            GoogleTime gtime = generator.Generate(default);

            Assert.True(gtime.DateTime == default(DateTime));
        }

        [Fact]
        public void NotNullTimeZone()
        {
            GoogleTimeGenerator generator = new GoogleTimeGenerator();
            
            GoogleTime gtime = generator.Generate(default);    
            
            Assert.NotNull(gtime.TimeZone);
        }

        [Fact]
        public void ExpectedTimeZone()
        {
            GoogleTimeGenerator generator = new GoogleTimeGenerator();
            
            GoogleTime gtime = generator.Generate(default);    
            
            Assert.Equal("Europe/Warsaw", gtime.TimeZone);
        }
    }
}