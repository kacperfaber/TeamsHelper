using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public interface IUserGenerator
    {
        Task<User> GenerateAsync(RegisterViewModel registerViewModel);
    }
}