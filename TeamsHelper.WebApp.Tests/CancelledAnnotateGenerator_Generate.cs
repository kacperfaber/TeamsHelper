using System;
using Moq;
using Xunit;

namespace TeamsHelper.WebApp.Tests
{
    public class CancelledAnnotateGenerator_Generate
    {
        readonly Mock<IDateTimeConverter> DateConverter;

        public CancelledAnnotateGenerator_Generate()
        {
            DateConverter = new Mock<IDateTimeConverter>();
        }

        string exec(DateTime dt) => new CancelledAnnotateGenerator(DateConverter.Object).Generate(dt);

        [Fact]
        public void DontThrows()
        {
            DateConverter.Setup(x => x.Convert(It.IsAny<DateTime>(), It.IsAny<StringDateTime>())).Returns("x");
            exec(DateTime.Now);
        }

        [Fact]
        public void ContainsDateTime()
        {
            DateConverter.Setup(x => x.Convert(It.IsAny<DateTime>(), It.IsAny<StringDateTime>())).Returns("x");
            string res = exec(DateTime.Now);
            Assert.Contains("x", res);
        }

        [Fact]
        public void MatchingRegex()
        {
            DateConverter.Setup(x => x.Convert(It.IsAny<DateTime>(), It.IsAny<StringDateTime>())).Returns("x");
            string res = exec(DateTime.Now);
            Assert.Matches("^Anulowano: x$", res);
        }
    }
}