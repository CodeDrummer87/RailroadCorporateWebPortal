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
        private ITCH2_WSR_WebClient client;

        public ContentController(ITCH2_WSR_WebClient webClient)
        {
            client = webClient;
        }

        public IActionResult Admin()
        {
            return View();
        }


        [HttpGet]
        public string GetPositions()
        {
            var result = client.Send("api/data/positions");
            return result ;
        }

        [HttpGet]
        public string GetEmployees()
        {
            return client.Send("api/data/employees");
        }
    }
}
