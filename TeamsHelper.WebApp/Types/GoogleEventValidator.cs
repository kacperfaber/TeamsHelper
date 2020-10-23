using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public class GoogleEventValidator : IGoogleEventValidator
    {
        public Task<GoogleEventValidationResult> ValidateAsync(GoogleEvent googleEvent, TeamsEvent teamsEvent)
        {
            return Task.Run(() =>
            {
                GoogleEventValidationResult result = new GoogleEventValidationResult();

                TimeSpan startCompare = (DateTime) googleEvent.Start.DateTime - teamsEvent.Start.DateTime;

                if (startCompare.TotalSeconds > 60 || startCompare.TotalSeconds < 60)
                {
                    result.StartingAtValidated = false;
                }

                TimeSpan endCompare = ((DateTime) googleEvent.End.DateTime) - teamsEvent.End.DateTime;
            
                if (endCompare.TotalSeconds > 60 || endCompare.TotalSeconds < 60)
                {
                    result.EndingAtValidated = false;
                }

                return result;
            });
        }
    }
}