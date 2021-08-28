using Microsoft.AspNetCore.Mvc;
using SportStore.DataBase;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using SportStore.Controllers.Security;
using SportStore.Enums;

namespace SportStore.Controllers
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
