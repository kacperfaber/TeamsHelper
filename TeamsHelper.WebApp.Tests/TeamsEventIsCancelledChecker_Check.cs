using Moq;
using TeamsHelper.TeamsApi;
using Xunit;

namespace TeamsHelper.WebApp.Tests
{
    public class TeamsEventIsCancelledChecker_Check
    {
        [Fact]
        public void DontThrows()
        {
            TeamsEvent teamsEvent = new TeamsEvent
            {
                IsCancelled = true
            };

            TeamsEventIsCanceledChecker checker = new TeamsEventIsCanceledChecker();

            checker.Check(teamsEvent);
        }

        [Fact]
        public void ReturnsFalseWhenTeamsEventIsNotCancelled()
        {
            TeamsEvent teamsEvent = new TeamsEvent
            {
                IsCancelled = false
            };

            TeamsEventIsCanceledChecker checker = new TeamsEventIsCanceledChecker();

            Assert.False(checker.Check(teamsEvent));
        }
        
        [Fact]
        public void ReturnsTrueWhenTeamsEventIsCancelled()
        {
            TeamsEvent teamsEvent = new TeamsEvent
            {
                IsCancelled = true
            };

            TeamsEventIsCanceledChecker checker = new TeamsEventIsCanceledChecker();

            Assert.True(checker.Check(teamsEvent));
        }
    }
}