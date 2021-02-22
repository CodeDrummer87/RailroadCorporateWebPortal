using Microsoft.AspNetCore.Mvc;
using RailwayPortalClassLibrary;
using System;
using System.Linq;

namespace InternalAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        ApplicationContext db;

        public AccountController(ApplicationContext context)
        {
            db = context;
        }

        [HttpPost]
        public SignInModel Post([FromBody] SignInModel model)
        {
            User user = db.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            Console.WriteLine(user);

            return model;
        }
    }
}
