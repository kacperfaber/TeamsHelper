using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
                x.EmailAddress.ToLower() == emailAddress.ToLower());
        }

        public async Task<User> ProvideAsync(Guid id)
        {
            return await HelperContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<User> ProvideAsync(HttpContext httpContext)
        {
            return Task.Run(() =>
            {
                Guid id = Guid.Parse(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

                return HelperContext.Users.Include(x => x.MicrosoftAuthorization).Include(x => x.GoogleAuthorization).ToList()
                    .FirstOrDefault(x => x.Id == id);
            });
        }
    }
}