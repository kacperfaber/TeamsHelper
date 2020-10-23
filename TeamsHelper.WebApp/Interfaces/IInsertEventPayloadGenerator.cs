using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public interface IInsertEventPayloadGenerator
    {
        Task<InsertEventPayload> GenerateAsync(TeamsEvent teamsEvent);
    }
}