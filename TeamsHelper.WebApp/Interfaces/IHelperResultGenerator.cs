using System.Collections.Generic;

namespace TeamsHelper.WebApp
{
    public interface IHelperResultGenerator
    {
        HelperResult Generate(List<Event> events, List<CanceledEvent> canceledEvents);
    }
}