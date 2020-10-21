using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public interface IUserPasswordValidator
    {
        Task<bool> ValidateAsync(User user, string password);
    }
}