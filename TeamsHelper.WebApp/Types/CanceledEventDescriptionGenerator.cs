using System;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public class CanceledEventDescriptionGenerator:ICanceledEventDescriptionGenerator
    {
        public string Generate(string originalDescription, DescriptionAfterCancelled afterCancelled)
        {
            return afterCancelled switch
            {
                DescriptionAfterCancelled.KeepDescription => originalDescription,
                DescriptionAfterCancelled.ChangeDescription => $"Anulowano: {ToString(DateTime.Now)}",
                DescriptionAfterCancelled.AppendDescription => $"{originalDescription}\n\nAnulowano: {ToString(DateTime.Now)}",
                _ => throw new InvalidOperationException()
            };
        }

        string ToString(DateTime dt)
        {
            return $"{dt.Hour}:{dt.Minute} {dt.Day}.{dt.Month}.{dt.Year}";
        }
    }
}