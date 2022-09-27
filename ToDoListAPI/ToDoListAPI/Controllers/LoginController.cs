using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Data;
using ToDoListAPI.Models;
using ToDoListAPI.Services;
using ToDoListAPI.Services.PasswordHash;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private DataContext db;
        private IJWT _jwt;
        private IPasswordHash _passHash;

        public LoginController(DataContext context, IJWT userService, IPasswordHash passHash)
        {
            db = context;
            _jwt = userService;
            _passHash = passHash;
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserLogin login)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(db.Users.FirstOrDefault(x => x.Username == login.Username) == null)
            {
                return BadRequest("User not found.");
            }

            User user = db
                .Users
                .Include(x => x.Role)
                .FirstOrDefault(x => x.Username == login.Username);

            if(!_passHash.VerifyHash(login.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = _jwt.CreateToken(user);

            return Ok(token);
        }
    }
}
