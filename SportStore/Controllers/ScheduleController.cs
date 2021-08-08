using Microsoft.AspNetCore.Mvc;
using SportStore.DataBase;
using SportStore.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

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
            return View(new List<Lesson>());
        }
    }
}
