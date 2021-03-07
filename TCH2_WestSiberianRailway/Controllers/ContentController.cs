using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TCH2_WestSiberianRailway.Modules.Interfaces;

namespace TCH2_WestSiberianRailway.Controllers
{
    [Authorize]
    public class ContentController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }
    }
}
