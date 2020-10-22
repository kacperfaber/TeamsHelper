using System;
using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class UserGenerator : IUserGenerator
    {
        public Task<User> GenerateAsync(RegisterViewModel registerViewModel)
        {
            return Task.Run(() => new User
            {
                Id = Guid.NewGuid().ToString(),
                Password = registerViewModel.Password,
                EmailAddress = registerViewModel.EmailAddress,
                DisplayName = registerViewModel.DisplayName
            });
        }
    }
}