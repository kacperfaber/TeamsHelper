using System.Collections.Generic;
using TeamsHelper.CalendarApi;
using Xunit;

namespace TeamsHelper.WebApp.Tests
{
    public class GoogleEventRemindersGenerator_Generate
    {
        GoogleEventReminders exec(GoogleConfiguration googleConfiguration, bool isCancelled)
        {
            GoogleEventRemindersGenerator generator = new GoogleEventRemindersGenerator();
            return generator.Generate(googleConfiguration, isCancelled);
        }
        
        [Fact]
        public void DontThrows()
        {
            GoogleConfiguration configuration = new GoogleConfiguration
            {
                Reminders = new List<GoogleConfigurationReminder>
                {
                    new GoogleConfigurationReminder
                    {
                        MinutesBefore = 3
                    }
                }
            };
            
            exec(configuration, false);
        }

        [Fact]
        public void NotNull()
        {
            GoogleConfiguration configuration = new GoogleConfiguration
            {
                Reminders = new List<GoogleConfigurationReminder>
                {
                    new GoogleConfigurationReminder
                    {
                        MinutesBefore = 3
                    }
                }
            };

            GoogleEventReminders result = exec(configuration, false);
            
            Assert.NotNull(result);
        }

        [Fact]
        public void ReturnsUseDefaultAsFalse()
        {
            GoogleConfiguration configuration = new GoogleConfiguration
            {
                Reminders = new List<GoogleConfigurationReminder>
                {
                    new GoogleConfigurationReminder
                    {
                        MinutesBefore = 3
                    }
                }
            };

            GoogleEventReminders result = exec(configuration, false);
            
            Assert.False(result.UseDefault);
        }

        [Fact]
        public void ReturnsExpectedCountWhenIsNotCancelled()
        {
            GoogleConfiguration configuration = new GoogleConfiguration
            {
                Reminders = new List<GoogleConfigurationReminder>
                {
                    new GoogleConfigurationReminder
                    {
                        MinutesBefore = 3
                    }
                }
            };

            GoogleEventReminders result = exec(configuration, false);
            
            Assert.True(result.Reminds.Count == 1);
        }

        [Fact]
        public void ReturnsExpectedCountWhenIsCancelled()
        {
            GoogleConfiguration configuration = new GoogleConfiguration
            {
                CancelledReminders = new List<GoogleConfigurationReminder>
                {
                    new GoogleConfigurationReminder
                    {
                        MinutesBefore = 30
                    },
                    new GoogleConfigurationReminder
                    {
                        MinutesBefore = 45
                    }
                }
            };

            GoogleEventReminders result = exec(configuration, true);
            
            Assert.True(result.Reminds.Count == 2);
        }
    }
}