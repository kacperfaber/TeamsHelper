using System;
using Xunit;

namespace TeamsHelper.WebApp.Tests
{
    public class IsNightChecker_Check
    {
        bool check(DateTime dt)
        {
            IsNightChecker checker = new IsNightChecker();
            return checker.Check(dt);
        }

        [Fact]
        public void DontThrows()
        {
            check(DateTime.Now);
        }

        [Theory]
        [InlineData(23, 56)]
        [InlineData(3, 0)]
        [InlineData(5, 59)]
        [InlineData(0, 0)]
        [InlineData(23, 0)]
        public void ShouldReturnTrue(int hour, int minutes)
        {
            DateTime dt = DateTime.Now.Date.AddHours(hour).AddMinutes(minutes);
            Assert.True(check(dt));
        }
        
        [Theory]
        [InlineData(6, 0)]
        [InlineData(8, 0)]
        [InlineData(8, 45)]
        [InlineData(12, 0)]
        [InlineData(16, 30)]
        [InlineData(18, 0)]
        [InlineData(22, 15)]
        [InlineData(22, 59)]
        public void ShouldReturnFalse(int hour, int minutes)
        {
            DateTime dt = DateTime.Now.Date.AddHours(hour).AddMinutes(minutes);
            Assert.False(check(dt));
        }
    }
}