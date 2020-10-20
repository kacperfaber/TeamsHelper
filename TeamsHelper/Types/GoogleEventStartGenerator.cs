using System;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper
{
    public class GoogleEventStartGenerator : IGoogleEventStartGenerator
    {

        public IGoogleTimeGenerator GoogleTimeGenerator;

        public GoogleEventStartGenerator(IGoogleTimeGenerator googleTimeGenerator)
        {
            GoogleTimeGenerator = googleTimeGenerator;
        }

        public GoogleTime Generate(TeamsEvent teamsEvent)
        {
            return GoogleTimeGenerator.Generate(teamsEvent.Start.DateTime);
        }
    }
}