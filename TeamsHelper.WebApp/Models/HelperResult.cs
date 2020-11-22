using System.Collections.Generic;

namespace TeamsHelper.WebApp
{
    public class HelperResult
    {
        public List<Event> Events { get; set; }
        public List<CanceledEvent> CanceledEvents { get; set; }
    }
}