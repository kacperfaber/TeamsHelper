using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public interface IUsersProvider
    {
        Task<List<User>> ProvideAsync();
    }
}