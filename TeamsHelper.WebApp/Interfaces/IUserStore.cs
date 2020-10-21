using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public interface IUserStore
    {
        Task StoreAsync(User user);
    }
}