using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Data;
using ToDoListAPI.Models;
using ToDoListAPI.Services.PasswordHash;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private DataContext db;
        private IPasswordHash _passHash;

        public RegisterController(DataContext context, IPasswordHash passHash)
        {
            db = context;
            _passHash = passHash;
        }

        [HttpPost]
        public async Task<ActionResult> Register(UserRegister reg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(db.Users.FirstOrDefault(x => x.Username == reg.Username) != null)
            {
                return BadRequest("This username already used.");
            }

            if(reg.RoleId != 1 && reg.RoleId != 2)
            {
                return BadRequest("Write correct role id.");
            }

            _passHash.CreateHash(reg.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new User();

            user.Username = reg.Username;
            user.RoleId = reg.RoleId;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;   

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }
    }
}
