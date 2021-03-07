using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RailwayPortalClassLibrary;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace InternalAPI.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private ApplicationContext db;

        public AccountController(ApplicationContext context)
        {
            db = context;
        }

        [Route("signIn")]
        [HttpPost]
        public User Post([FromBody] SignInModel model)
        {
            User user = db.Users.FirstOrDefault(u => u.Email == model.Email);
            if (user != null && user.Password == GetHashImage(model.Password, user.Salt))
            {
                return user;
            }

            return null;
        }

        private byte[] GetSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        private string GetHashImage(string pswrd, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pswrd,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        private bool CheckLoginNotExist(string login)
        {
            return db.Users.FirstOrDefault(e => e.Email == login) == null ? true : false;
        }

        [Route("session")]
        [HttpPost]
        public async Task<SessionModel> Post(SessionModel session)
        {
            _ = await db.Sessions.AddAsync(session);
            _ = await db.SaveChangesAsync();

            return session;
        }
    }
}
