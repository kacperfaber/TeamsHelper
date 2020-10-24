using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public interface IUserDeletor
    {
        Task<bool> DeleteAsync(User user);
    }
}