using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public interface IAuthorizationValidator
    {
        Task<bool> ValidateAsync(Authorization authorization);
    }
}