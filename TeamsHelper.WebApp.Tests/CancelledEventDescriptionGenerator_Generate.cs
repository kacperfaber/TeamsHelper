using System;
using Moq;
using Xunit;

namespace TeamsHelper.WebApp.Tests
{
    public class CancelledEventDescriptionGenerator_Generate
    {
        public Mock<ICancelledAnnotateGenerator> AnnotateGenerator;

        public CancelledEventDescriptionGenerator_Generate()
        {
            AnnotateGenerator = new Mock<ICancelledAnnotateGenerator>();
        }

        string exec(string originalDesc, DescriptionAfterCancelled descriptionAfterCancelled)
        {
            CancelledEventsDescriptionGenerator generator = new CancelledEventsDescriptionGenerator(AnnotateGenerator.Object);
            return generator.Generate(originalDesc, descriptionAfterCancelled);
        }

        [Fact]
        public void DontThrows()
        {
            AnnotateGenerator.Setup(x => x.Generate(It.IsAny<DateTime>())).Returns("{annotate}");
            exec("Hello World!", DescriptionAfterCancelled.AppendDescription);
        }

        [Fact]
        public void NotNullIfAppendDescription()
        {
            AnnotateGenerator.Setup(x => x.Generate(It.IsAny<DateTime>())).Returns("{annotate}");
            string res = exec("Hello World!", DescriptionAfterCancelled.AppendDescription);
            Assert.NotNull(res);
        }

        [Fact]
        public void ContainsAnnotateIfAppendDescription()
        {
            AnnotateGenerator.Setup(x => x.Generate(It.IsAny<DateTime>())).Returns("{annotate}");
            string res = exec("Hello World!", DescriptionAfterCancelled.AppendDescription);
            Assert.Contains("{annotate}", res);
        }

        [Fact]
        public void ContainsOriginalIfAppendDescription()
        {
            AnnotateGenerator.Setup(x => x.Generate(It.IsAny<DateTime>())).Returns("{annotate}");
            string res = exec("Hello World!", DescriptionAfterCancelled.AppendDescription);
            Assert.Contains("Hello World!", res);
        }

        [Fact]
        public void NotNullIfKeepDescription()
        {
            AnnotateGenerator.Setup(x => x.Generate(It.IsAny<DateTime>())).Returns("{annotate}");
            string res = exec("Hello World!", DescriptionAfterCancelled.KeepDescription);
            Assert.NotNull(res);
        }

        [Fact]
        public void IsOriginalStringIfKeepDescription()
        {
            const string desc = "Hello World!";
            AnnotateGenerator.Setup(x => x.Generate(It.IsAny<DateTime>())).Returns("{annotate}");
            string res = exec(desc, DescriptionAfterCancelled.KeepDescription);
            Assert.Equal(desc, res);
        }

        [Fact]
        public void NotNullIfChangeDescription()
        {
            const string desc = "Hello World!";
            AnnotateGenerator.Setup(x => x.Generate(It.IsAny<DateTime>())).Returns("{annotate}");
            string res = exec(desc, DescriptionAfterCancelled.ChangeDescription);
            Assert.NotNull(res);
        }

        [Fact]
        public void IsAnnotateIfChangeDescription()
        {
            const string annotate = "{annotate}";
            AnnotateGenerator.Setup(x => x.Generate(It.IsAny<DateTime>())).Returns(annotate);
            string res = exec("Hello World!", DescriptionAfterCancelled.ChangeDescription);
            Assert.Equal(annotate, res);
        }

        [Fact]
        public void MatchingRegexIfAppendDescription()
        {
            const string annotate = "{annotate}";
            const string desc = "Hello World!";
            
            AnnotateGenerator.Setup(x => x.Generate(It.IsAny<DateTime>())).Returns(annotate);
            string res = exec(desc, DescriptionAfterCancelled.AppendDescription);
            Assert.Matches(@$"^{desc}\n\n{annotate}$", res);
        }
    }
}