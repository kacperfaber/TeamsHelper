using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    [Authorize]
    public class OAuthController : Controller
    {
        public IUserProvider UserProvider;
        
        public async Task<IActionResult> AuthorizeGoogle()
        {
            User user = await UserProvider.ProvideAsync(HttpContext);
        }

        public IActionResult AuthorizeMicrosoft()
        {
        }
    }
}