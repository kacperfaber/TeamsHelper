using System;
using Moq;
using Xunit;

namespace TeamsHelper.WebApp.Tests
{
    public class SleepTimeProvider_Provide
    {
        readonly Mock<IIsNightChecker> NightChecker;

        public SleepTimeProvider_Provide()
        {
            NightChecker = new Mock<IIsNightChecker>();
        }

        TimeSpan exec(DateTime dt, ServiceConfiguration cfg)
        {
            SleepTimeProvider prov = new SleepTimeProvider();
            return prov.Provide(dt, cfg);
        }

        [Fact]
        public void DontThrows()
        {
            NightChecker.Setup(x => x.Check(It.IsAny<DateTime>())).Returns(true);
            
            exec(DateTime.Now, new ServiceConfiguration {SleepMinutes = 60});
        }
        
        [Fact]
        public void ReturnsFromConfigurationIfIsNight()
        {
            const int mins = 60;
            
            NightChecker.Setup(x => x.Check(It.IsAny<DateTime>())).Returns(true);

            TimeSpan result = exec(DateTime.Now, new ServiceConfiguration {SleepMinutes = mins});
            
            Assert.True((int) result.TotalMinutes == mins);
        }
        
        [Fact]
        public void ReturnsFromConfigurationIfIsDay()
        {
            const int mins = 60;
            
            NightChecker.Setup(x => x.Check(It.IsAny<DateTime>())).Returns(false);

            TimeSpan result = exec(DateTime.Now, new ServiceConfiguration {SleepMinutes = mins});
            
            Assert.True((int) result.TotalMinutes == mins);
        }
    }
}