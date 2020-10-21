using Microsoft.AspNetCore.Mvc;

namespace TeamsHelper.WebApp
{
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return Content("home.");
        }
    }
}