using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public interface ISummaryGenerator
    {
        string Generate(string subject);
    }
}