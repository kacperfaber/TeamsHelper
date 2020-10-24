using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class UserDeletor : IUserDeletor
    {
        public HelperContext HelperContext;

        public UserDeletor(HelperContext helperContext)
        {
            HelperContext = helperContext;
        }

        public async Task<bool> DeleteAsync(User user)
        {
            HelperContext.Users.Remove(user);
            await HelperContext.SaveChangesAsync();

            return true;
        }
    }
}