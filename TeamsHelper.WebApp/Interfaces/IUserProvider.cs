using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public interface IUserProvider
    {
        Task<User> Provide(string emailAddress);
    }
}