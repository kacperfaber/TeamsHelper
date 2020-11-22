using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public interface ISynchronizationEventGenerator
    {
        SynchronizedEvent Generate(Event @event);
    }
}