using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
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
        ApplicationContext db;

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

        [Route("session")]
        [HttpGet]
        public SessionModel Get(int userId)
        {
            DateTime currentDateTime = DateTime.Now;

            SessionModel session = new SessionModel
            {
                SessionId = Guid.NewGuid().ToString(),
                UserId = userId,
                Created = currentDateTime,
                Expired = currentDateTime.AddMinutes(15)
            };

            db.Sessions.Add(session);
            db.SaveChanges();

            return session;
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
    }
}
