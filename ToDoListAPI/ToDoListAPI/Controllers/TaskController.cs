using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Data;
using ToDoListAPI.Models;

namespace ToDoListAPI.Controllers
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

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetTasks()
        {
            return Ok(await db.Tasks.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TaskModel>>> GetTask(int id)
        {
            TaskModel dbtask = await db
                .Tasks
                .FindAsync(id);

            if (dbtask == null)
                return BadRequest("Task not found.");

            return Ok(dbtask);
        }

        [HttpPost]
        public async Task<ActionResult<List<TaskModel>>> CreateTask(TaskModel task)
        {
            task.CreateTime = DateTime.Now;

            db.Tasks.Add(task);
            await db.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<List<TaskModel>>> UpdateTask(TaskModel task)
        {
            TaskModel dbtask = await db
                .Tasks
                .FindAsync(task.Id);

            if (dbtask == null)
                return BadRequest("Task not found.");

            dbtask.Title = task.Title;
            dbtask.Description = task.Description;
            dbtask.LastEditTime = DateTime.Now;

            await db.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<TaskModel>>> DoneTask(int id)
        {
            TaskModel dbtask = await db
                .Tasks
                .FindAsync(id);

            if (dbtask == null)
                return BadRequest("Task not found.");

            dbtask.Done = true;
            dbtask.DoneTime = DateTime.Now;

            await db.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TaskModel>>> DeleteTask(int id)
        {
            var dbHero = await db
                .Tasks
                .FindAsync(id);

            if (dbHero == null)
                return BadRequest("Task not found.");

            db.Tasks.Remove(dbHero);
            await db.SaveChangesAsync();

            return Ok();
        }
    }
}
