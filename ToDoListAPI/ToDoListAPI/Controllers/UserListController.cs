using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Data;
using ToDoListAPI.Models;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "user")]
    public class UserListController : ControllerBase
    {
        private DataContext db;

        public UserListController(DataContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult> UserList()
        {
            List<User> users = db
                .Users
                .ToList();

            return Ok(users);
        }
    }
}
