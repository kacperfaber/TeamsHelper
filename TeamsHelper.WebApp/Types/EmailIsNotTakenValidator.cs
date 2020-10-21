using System;
using System.Linq;
using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class EmailIsNotTakenValidator : IEmailIsNotTakenValidator
    {
        public HelperContext HelperContext;

        public EmailIsNotTakenValidator(HelperContext helperContext)
        {
            HelperContext = helperContext;
        }

        public Task<bool> ValidateAsync(string emailAddress)
        {
            return Task.Run(() =>
            {
                return !HelperContext.Users.Any(x => string.Equals(x.EmailAddress, emailAddress, StringComparison.InvariantCultureIgnoreCase));
            });
        }
    }
}