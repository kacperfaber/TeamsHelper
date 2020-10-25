using System;
using System.Threading.Tasks;
using Moq;
using TeamsHelper.CalendarApi;
using Xunit;

namespace TeamsHelper.WebApp.Tests
{
    public class UpdateEventPayloadGeneratorTests
    {
        [Fact]
        public async Task DontThrowsExceptions()
        {
            GoogleEvent googleEvent = new GoogleEvent
            {
                Start = new GoogleTime
                {
                    DateTime = DateTime.Now,
                    TimeZone = "Europe/Warsaw"
                },
                End = new GoogleTime
                {
                    DateTime = DateTime.Now.AddDays(1),
                    TimeZone = "Europe/Warsaw"
                }
            };
            
            Mock<IGoogleTimeGenerator> googleTimeGenerator = new Mock<IGoogleTimeGenerator>();
            googleTimeGenerator.Setup(x => x.Generate(default)).Returns(new GoogleTime());

            UpdateEventPayloadGenerator generator = new UpdateEventPayloadGenerator(googleTimeGenerator.Object);
            _ = await generator.GenerateAsync(googleEvent);
        }

        [Fact]
        public void ReturnsNotNull()
        {
        }
    }
}