using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportStore.Controllers.Security;
using SportStore.DataBase;
using SportStore.Entities;
using SportStore.Enums;
using SportStore.ViewModels;

namespace SportStore.Controllers
{
    [Route("lessons")]
    [Authorize]
    public class LessonsController : Controller
    {
        private SchoolContext _ctx;

        public LessonsController(SchoolContext ctx)
        {
            _ctx = ctx;
        }

        [Permissions(PermissionsLevel.Manage)]
        public IActionResult Index()
        {
            var lessons = _ctx.Lessons.ToList();
            var teachers = _ctx.Teachers.ToList();

            return View(new LessonViewModel
            {
                Lessons = lessons,
                Teachers = teachers
            });
        }

        [Permissions(PermissionsLevel.Manage)]
        [HttpPost]
        public async Task<IActionResult> Insert(Lesson lesson)
        {
            if (lesson == null)
            {
                return BadRequest();
            }

            _ctx.Add(lesson);
            await _ctx.SaveChangesAsync();

            return Ok();
        }

        [Permissions(PermissionsLevel.Manage)]
        [HttpPut]
        public async Task<IActionResult> Update(Guid lessonId, Subject subject, DayOfWeek day, int hour, Guid teacher)
        {
            var lesson = _ctx.Lessons.FirstOrDefault(x => x.Id == lessonId);

            if (lesson == null)
            {
                return NotFound();
            }

            lesson.Subject = subject;
            lesson.DayOfWeek = day;
            lesson.Hour = hour;
            lesson.TeacherId = teacher;

            _ctx.Update(lesson);
            await _ctx.SaveChangesAsync();

            return Ok();
        }

        [Permissions(PermissionsLevel.Manage)]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var lessonToDelete = _ctx.Lessons.FirstOrDefault(x => x.Id == id);

            if (lessonToDelete == null)
            {
                return NotFound();
            }

            _ctx.Remove(lessonToDelete);
            await _ctx.SaveChangesAsync();

            return Ok();
        }
    }
}