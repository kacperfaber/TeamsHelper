using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public interface ISynchronizationGenerator
    {
        Synchronization Generate(HelperResult result, User user);
    }
}