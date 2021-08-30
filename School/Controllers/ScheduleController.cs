using Microsoft.AspNetCore.Mvc;
using School.DataBase;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using School.Controllers.Security;
using School.Enums;

namespace School.Controllers
{
    [Route("schedule")]
    [Authorize]
    public class ScheduleController : Controller
    {
        private SchoolContext _ctx;

        public ScheduleController(SchoolContext ctx)
        {
            _ctx = ctx;
        }

        [Permissions(PermissionsLevel.Watch)]
        public IActionResult Index()
        {
            var lessons = _ctx.Lessons
                .AsQueryable()
                .Where(x => x.Students.Any(y => y.IdNumber == User.Identity.Name));
              
            return View(lessons);
        }
    }
}
