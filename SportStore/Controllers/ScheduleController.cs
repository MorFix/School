using Microsoft.AspNetCore.Mvc;
using SportStore.DataBase;
using SportStore.Entities;
using System.Collections.Generic;

namespace SportStore.Controllers
{
    [Route("schedule")]
    public class ScheduleController : Controller
    {
        private SchoolContext _ctx;

        public ScheduleController(SchoolContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            return View(new List<Lesson> { 
                new() {Subject="english", DayOfWeek=System.DayOfWeek.Monday, Hour = 4},
                new() {Subject="hebrew", DayOfWeek=System.DayOfWeek.Tuesday, Hour = 4},
                new() {Subject="ccc", DayOfWeek=System.DayOfWeek.Wednesday, Hour = 4},
                new() {Subject="ddddd", DayOfWeek=System.DayOfWeek.Wednesday, Hour = 4},
                new() {Subject="eeeeee", DayOfWeek=System.DayOfWeek.Wednesday, Hour = 4},
                new() {Subject="fffff", DayOfWeek=System.DayOfWeek.Wednesday, Hour = 4},
            });
        }
    }
}
