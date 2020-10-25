using System.Threading.Tasks;
using Moq;
using TeamsHelper.CalendarApi;
using Xunit;

namespace TeamsHelper.WebApp.Tests
{
    public class PrimaryCalendarProvider_Provide
    {
        readonly Mock<GoogleApi> GoogleApi;

        public PrimaryCalendarProvider_Provide()
        {
            GoogleApi = new Mock<GoogleApi>();
        }

        Task<GoogleCalendar> exec(string accessToken)
        {
            PrimaryCalendarProvider prov = new PrimaryCalendarProvider(GoogleApi.Object);
            return prov.Provide(accessToken);
        }

        [Fact]
        public async Task DontThrows()
        {
            GoogleApi.Setup(x => x.GetCalendar(It.Is<string>(match => match == "primary"), It.IsAny<string>())).ReturnsAsync(new GoogleCalendar());
            _ = await exec("");
        }

        [Fact]
        public async Task Expected()
        {
            GoogleCalendar calendar = new GoogleCalendar();
            GoogleApi.Setup(x => x.GetCalendar(It.Is<string>(x => x == "primary"), It.IsAny<string>())).ReturnsAsync(calendar);
            GoogleCalendar result = await exec("");
            
            Assert.Equal(result, calendar);
        }
    }
}