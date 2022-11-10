using DepartmentAPI.Data;
using DepartmentAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepartmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private DataContext db;

        public DepartmentController(DataContext context)
        {
            db = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Department(int id)
        {
            Department department = db
                .Departments
                .Include(x => x.Members)
                .Include(x => x.Project)
                .Include(x => x.Tasks)
                .FirstOrDefault(x => x.Id == id);

            if (department == null)
                return BadRequest("Department not found.");

            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Department department)
        {
            List<Member> memberList = new List<Member>();
            foreach(var item in department.MembersId)
            {
                Member member = db
                    .Members
                    .FirstOrDefault(x => x.Id == item);
                memberList.Add(member);
            }
            department.Members = memberList;

            db.Departments.Add(department);
            await db.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Department department = db
                .Departments
                .FirstOrDefault(p => p.Id == id);

            if (department == null)
                return BadRequest("Department not found.");


            db.Departments.Remove(department);
            await db.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, Department departmentEdit)
        {
            Department department = db
                .Departments
                .FirstOrDefault(p => p.Id == id);

            if (department == null)
                return BadRequest("Department not found.");

            department.Name = departmentEdit.Name;
            department.Members = departmentEdit.Members;
            department.ProjectId = departmentEdit.ProjectId;

            db.Departments.Update(department);
            await db.SaveChangesAsync();

            return Ok(department);
        }
    }
}
