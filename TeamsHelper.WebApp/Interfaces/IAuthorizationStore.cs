using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public interface IAuthorizationStore
    {
        Task StoreAsync(Authorization authorization, User owner);
    }
}