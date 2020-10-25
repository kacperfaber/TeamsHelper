using System;
using Moq;
using TeamsHelper.CalendarApi;
using Xunit;

namespace TeamsHelper.WebApp.Tests
{
    public class UpdateEventPayloadGeneratorTests
    {
        [Fact]
        public void DontThrowsExceptions()
        {
            Mock<IGoogleTimeGenerator> mock = new Mock<IGoogleTimeGenerator>();
            mock
                .Setup(x => x.Generate(It.Is<DateTime>(match => default)))
                .Returns<DateTime>(x => new GoogleTime {DateTime = x, TimeZone = "Europe/Warsaw"});

            UpdateEventPayloadGenerator generator = new UpdateEventPayloadGenerator(mock.Object);

            generator.GenerateAsync(new GoogleEvent());
        }

        [Fact]
        public void ReturnsNotNull()
        {
            Mock<IGoogleTimeGenerator> mock = new Mock<IGoogleTimeGenerator>();
            mock.Setup(x => x.Generate(It.Is<DateTime>(match => default)))
                .Returns<DateTime>(x => new GoogleTime {DateTime = x, TimeZone = "Europe/Warsaw"});

            UpdateEventPayloadGenerator generator = new UpdateEventPayloadGenerator(mock.Object);
            
            Assert.NotNull(generator.GenerateAsync(new GoogleEvent()));
        }
    }
}