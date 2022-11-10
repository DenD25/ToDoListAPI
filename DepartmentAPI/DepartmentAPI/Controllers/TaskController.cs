using DepartmentAPI.Data;
using DepartmentAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepartmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private DataContext db;

        public TaskController(DataContext context)
        {
            db = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Task(int id)
        {
            TaskModel task = db
                .Tasks
                .Include(x => x.Department)
                .FirstOrDefault(x => x.Id == id);

            if (task == null)
                return BadRequest("Task not found.");


            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult> Create(TaskModel task)
        {
            db.Tasks.Add(task);
            await db.SaveChangesAsync();

            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            TaskModel task = db
                .Tasks
                .FirstOrDefault(p => p.Id == id);

            if (task == null)
                return BadRequest("Task not found.");


            db.Tasks.Remove(task);
            await db.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, TaskModel taskEdit)
        {
            TaskModel task = db
                .Tasks
                .FirstOrDefault(p => p.Id == id);

            if (task == null)
                return BadRequest("Department not found.");

            task.Name = taskEdit.Name;
            task.DepatmentId = taskEdit.DepatmentId;
            task.EndDate = taskEdit.EndDate;

            db.Tasks.Update(task);
            await db.SaveChangesAsync();

            return Ok();
        }
    }
}
