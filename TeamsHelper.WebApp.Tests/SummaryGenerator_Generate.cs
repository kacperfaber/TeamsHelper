using Xunit;

namespace TeamsHelper.WebApp.Tests
{
    public class SummaryGenerator_Generate
    {
        string exec(string subject) => new SummaryGenerator().Generate(subject);
        
        [Fact]
        public void DontThrows()
        {
            exec("Math");
        }

        [Fact]
        public void NotNull()
        {
            Assert.NotNull(exec("Math"));
        }

        [Fact]
        public void ContainsSubject()
        {
            Assert.Contains("Math", exec("Math"));
        }

        [Fact]
        public void MatchingRegex()
        {
            const string subject = "math";
            string s = exec(subject);
            Assert.Matches($"^Lekcja: {subject}$", s);
        }
    }
}