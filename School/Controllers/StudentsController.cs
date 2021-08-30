using Microsoft.AspNetCore.Mvc;
using School.DataBase;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using School.Controllers.Security;
using School.Enums;
using System.Threading.Tasks;
using System;

namespace School.Controllers
{
    [Route("students")]
    [Authorize]
    public class StudentsController : Controller
    {
        private SchoolContext _ctx;

        public StudentsController(SchoolContext ctx)
        {
            _ctx = ctx;
        }

        [Permissions(PermissionsLevel.Manage)]
        public IActionResult Index()
        {
            var students = _ctx.Students.ToList();
            ViewData["Behavior"] = StudentBehavior.Good.ToSelectList();
              
            return View(students);
        }

        [Permissions(PermissionsLevel.Manage)]
        [HttpPut]
        public async Task<IActionResult> UpdateBehavior(string student, string behavior)
        {
            var dbstudent = _ctx.Students.FirstOrDefault(x => x.IdNumber == student);
            if (dbstudent == null) {
                return NotFound();
            }

            dbstudent.Behavior = Enum.Parse<StudentBehavior>(behavior);
            _ctx.Update(dbstudent);
            await _ctx.SaveChangesAsync();

            return Ok();
        }
    }
}
