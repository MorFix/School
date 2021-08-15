using Microsoft.AspNetCore.Mvc;
using SportStore.DataBase;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

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

        public IActionResult Index()
        {
            var lessons = _ctx.Lessons
                .AsQueryable()
                .Where(x => x.Students.Any(y => y.IdNumber == User.Identity.Name))
                .GroupBy(x => x.Hour)
                .ToDictionary(x => x.Key, y => y.ToList());

            return View(lessons);
        }
    }
}
