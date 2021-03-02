using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalAPI.Controllers
{
    [Route("api/data")]
    [ApiController]
    public class DataController : ControllerBase
    {
        ApplicationContext db;

        public DataController(ApplicationContext context)
        {
            db = context;
        }

        [Route("positions")]
        [HttpGet]
        public string Get()
        {
            var result = db.Positions.Where(p => p.Id > 0).Select(p => new { p.FullName}).ToList();
            var jsonResult = JsonConvert.SerializeObject(result);
            return jsonResult;
        }

        [Route("employees")]
        [HttpGet]
        public string GetEmployees()
        {
            var result = db.Users.Where(p => p.Id > 0).Select(p => new { p.Email }).ToList();
            var jsonResult = JsonConvert.SerializeObject(result);
            return jsonResult;
        }
    }
}
