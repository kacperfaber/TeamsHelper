using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper
{
    public class GoogleEventGenerator : IGoogleEventGenerator
    {
        public IGoogleEventSummaryGenerator SummaryGenerator;
        public IGoogleEventEndGenerator EndGenerator;
        public IGoogleEventStartGenerator StartGenerator;

        public GoogleEventGenerator(IGoogleEventSummaryGenerator summaryGenerator, IGoogleEventEndGenerator endGenerator, IGoogleEventStartGenerator startGenerator)
        {
            SummaryGenerator = summaryGenerator;
            EndGenerator = endGenerator;
            StartGenerator = startGenerator;
        }

        public Task<GoogleEvent> GenerateAsync(TeamsEvent teamsEvent)
        {
            return Task.Run(() => new GoogleEvent
            {
                Summary = SummaryGenerator.Generate(teamsEvent),
                End = EndGenerator.Generate(teamsEvent),
                Start = StartGenerator.Generate(teamsEvent)
            });
        }
    }
}