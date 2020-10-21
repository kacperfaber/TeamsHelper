using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class UserProvider : IUserProvider
    {
        public HelperContext HelperContext;

        public UserProvider(HelperContext helperContext)
        {
            HelperContext = helperContext;
        }

        public async Task<User> Provide(string emailAddress)
        {
            return await HelperContext.Users.FirstOrDefaultAsync(x =>
                string.Equals(emailAddress, x.EmailAddress, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}