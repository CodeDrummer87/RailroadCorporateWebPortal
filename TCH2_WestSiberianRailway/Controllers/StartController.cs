using Microsoft.AspNetCore.Mvc;

namespace TCH2_WestSiberianRailway.Controllers
{
    public class StartController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
