using System.Collections.Generic;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public interface ISynchronizationEventsGenerator
    {
        IEnumerable<SynchronizedEvent> Generate(HelperResult result);
    }
}