using Microsoft.AspNetCore.Mvc;
using School.DataBase;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using School.Controllers.Security;
using School.Enums;
using System.Threading.Tasks;
using System;
using System.Data.Entity;

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
            ViewBag.StudentsByBehavior = students.GroupBy(x => x.Behavior)
                .ToDictionary(x => x.Key, x => x.Count());
              
            return View(students);
        }

        [Permissions(PermissionsLevel.Manage)]
        [HttpGet]
        [Route("studentsByBehavior")]
        public IActionResult StudentsByBehavior()
        {
            var studentsByBehavior = _ctx.Students.ToList().GroupBy(x => x.Behavior)
                .ToDictionary(x => x.Key, x => x.Count());

            return Ok(studentsByBehavior);
        }

        [Permissions(PermissionsLevel.Manage)]
        [HttpGet]
        [Route("studentsByClass")]
        public IActionResult StudentsByClasses()
        {
            var studentsCountByClass = _ctx.Students
                .ToList()
                .GroupBy(x => x.Class.Name)
                .ToDictionary(x => x.Key, x => x.Count());

            return Ok(studentsCountByClass);
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
