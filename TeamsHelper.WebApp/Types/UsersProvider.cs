using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class UsersProvider : IUsersProvider
    {
        public HelperContext HelperContext;

        public UsersProvider(HelperContext helperContext)
        {
            HelperContext = helperContext;
        }

        public Task<List<User>> ProvideAsync()
        {
            return HelperContext.Users
                .Include(x => x.MicrosoftAuthorization)
                .Include(x => x.GoogleAuthorization)
                .Where(x => x.MicrosoftAuthorization != null && x.GoogleAuthorization != null)
                .ToListAsync();
        }
    }
}