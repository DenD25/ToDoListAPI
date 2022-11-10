using DepartmentAPI.Data;
using DepartmentAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepartmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private DataContext db;

        public ProjectController(DataContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Project>>> List()
        {
            return Ok(await db.Projects.Include(x => x.Departments).ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Project>> Create(Project project)
        {
            db.Projects.Add(project);
            await db.SaveChangesAsync();

            return Ok(project);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Project project = db
                .Projects
                .FirstOrDefault(p => p.Id == id);

            if(project == null)
                return BadRequest("Project not found.");


            db.Projects.Remove(project);
            await db.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, Project projectEdit)
        {
            Project project = db
                .Projects
                .FirstOrDefault(p => p.Id == id);

            if (project == null)
                return BadRequest("Project not found.");

            project.Name = projectEdit.Name;

            db.Projects.Update(project);
            await db.SaveChangesAsync();

            return Ok(project);
        }
    }
}
