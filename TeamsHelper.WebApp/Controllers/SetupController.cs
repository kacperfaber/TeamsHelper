using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TeamsHelper.WebApp
{
    [Authorize]
    public class SetupController : Controller
    {
        public IActionResult Setup()
        {
            return View("Setup");
        }
    }
}