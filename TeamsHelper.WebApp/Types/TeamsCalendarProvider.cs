using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.TeamsApi;
using TeamsHelper.WebApp;

namespace TeamsHelper
{
    public class TeamsCalendarProvider : ITeamsCalendarProvider
    {
        public ITeamsCalendarValidator Validator;

        public TeamsCalendarProvider(ITeamsCalendarValidator validator)
        {
            Validator = validator;
        }

        public async Task<TeamsCalendar> ProvideAsync(List<TeamsCalendar> calendars)
        {
            foreach (TeamsCalendar calendar in calendars)
            {
                if (await Validator.ValidateAsync(calendar))
                {
                    return calendar;
                }
            }

            throw new Exception();
        }
    }
}