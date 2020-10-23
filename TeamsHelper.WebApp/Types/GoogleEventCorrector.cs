using System;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public class GoogleEventCorrector : IGoogleEventCorrector
    {
        public IGoogleTimeGenerator TimeGenerator;

        public GoogleEventCorrector(IGoogleTimeGenerator timeGenerator)
        {
            TimeGenerator = timeGenerator;
        }

        public Task CorrectAsync(GoogleEvent googleEvent, TeamsEvent teamsEvent, GoogleEventValidationResult validationResult)
        {
            return Task.Run(() =>
            {
                if (!validationResult.StartingAtValidated)
                {
                    googleEvent.Start = TimeGenerator.Generate((DateTime) googleEvent.Start.DateTime);
                }

                if (!validationResult.EndingAtValidated)
                {
                    googleEvent.End = TimeGenerator.Generate((DateTime) googleEvent.End.DateTime);
                }
            });
        }
    }
}