using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayPortalClassLibrary;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using TCH2_WestSiberianRailway.Modules.Interfaces;

namespace TCH2_WestSiberianRailway.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor contextAccessor;
        private ITCH2_WSR_WebClient client;

        public AccountController(IHttpContextAccessor httpContext, ITCH2_WSR_WebClient webClient)
        {
            contextAccessor = httpContext;
            client = webClient;
        }

        [HttpPost]
        public async Task<string> SignIn([FromBody] SignInModel model)
        {
            var user = client.Send<SignInModel>(HttpMethod.Post, "api/account/signIn", model);

            if (user != null)
            {
                await Authenticate(user.Id, user.Email);
                return "/Content/Admin";
            }

            return null;
        }

        private async Task Authenticate(int userId, string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            RegisterSession(userId);
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        private async Task RegisterSession(int userId)
        {
            await Task.Run(() => 
            {
                var request = client.Get<int>($"api/account/session?userId={userId}");
                contextAccessor.HttpContext.Response.Cookies.Append("SessionId", request.SessionId);
            });
            
        }
    }
}
