using System;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public class CancelledEventsDescriptionGenerator : ICancelledEventsDescriptionGenerator
    {
        public ICancelledAnnotateGenerator CancelledAnnotateGenerator;

        public CancelledEventsDescriptionGenerator(ICancelledAnnotateGenerator cancelledAnnotateGenerator)
        {
            CancelledAnnotateGenerator = cancelledAnnotateGenerator;
        }

        public string Generate(string originalDescription, DescriptionAfterCancelled afterCancelled)
        {
            return afterCancelled switch
            {
                DescriptionAfterCancelled.KeepDescription => originalDescription,
                DescriptionAfterCancelled.ChangeDescription => CancelledAnnotateGenerator.Generate(DateTime.Now),
                DescriptionAfterCancelled.AppendDescription => originalDescription + "\n\n" + CancelledAnnotateGenerator.Generate(DateTime.Now),
                _ => throw new InvalidOperationException()
            };
        }
    }
}