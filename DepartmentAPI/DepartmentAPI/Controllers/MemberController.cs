using DepartmentAPI.Data;
using DepartmentAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepartmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private DataContext db;

        public MemberController(DataContext context)
        {
            db = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Member(int id)
        {
            Member member = db
                .Members
                .Include( x => x.Departments)
                .FirstOrDefault(m => m.Id == id);

            if(member == null)
                return BadRequest("Member not found.");


            return Ok(member);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Member member)
        {
            db.Members.Add(member);
            await db.SaveChangesAsync();

            return Ok(member);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Member member = db
                .Members
                .FirstOrDefault(p => p.Id == id);

            if (member == null)
                return BadRequest("Member not found.");


            db.Members.Remove(member);
            await db.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, Member memberEdit)
        {
            Member member = db
                .Members
                .FirstOrDefault(p => p.Id == id);

            if (member == null)
                return BadRequest("Project not found.");

            member.Name = memberEdit.Name;

            db.Members.Update(member);
            await db.SaveChangesAsync();

            return Ok(member);
        }
    }
}
