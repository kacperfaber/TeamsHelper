using System.Threading.Tasks;
using TeamsHelper.CalendarApi;

namespace TeamsHelper.WebApp
{
    public interface IUpdateEventPayloadGenerator
    {
        Task<UpdateEventPayload> GenerateAsync(GoogleEvent googleEvent);
    }
}