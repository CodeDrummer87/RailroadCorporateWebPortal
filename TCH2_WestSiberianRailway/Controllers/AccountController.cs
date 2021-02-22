using Microsoft.AspNetCore.Mvc;
using RailwayPortalClassLibrary;
using System.Net.Http;

namespace TCH2_WestSiberianRailway.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public string SignIn([FromBody] SignInModel model)
        {
            WebClient client = new WebClient("https://localhost:44312");
            var result = client.Send<SignInModel>(HttpMethod.Post, "api/account", model);

            return $"Логин: {result.Email}, Пароль: {result.Password}";
        }
    }
}
