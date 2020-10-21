using System;
using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class UserPasswordValidator : IUserPasswordValidator
    {
        public Task<bool> ValidateAsync(User user, string password)
        {
            return Task.Run(() => string.Equals(user.Password, password, StringComparison.InvariantCulture));
        }
    }
}