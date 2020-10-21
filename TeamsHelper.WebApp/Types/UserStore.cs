using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class UserStore : IUserStore
    {
        public HelperContext HelperContext;

        public UserStore(HelperContext helperContext)
        {
            HelperContext = helperContext;
        }

        public async Task StoreAsync(User user)
        {
            await HelperContext.AddAsync(user);
        }
    }
}