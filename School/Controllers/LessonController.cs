using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.Controllers.Security;
using School.DataBase;
using School.Entities;
using School.Enums;

namespace School.Controllers
{
    [Authorize]
    public class LessonController : Controller
    {
        private readonly SchoolContext _context;

        public LessonController(SchoolContext context)
        {
            _context = context;
        }

        [Permissions(PermissionsLevel.Manage)]
        // GET: Lesson
        public IActionResult Index(string teacher = null, string subject = null, string dayOfWeek = null)
        {
            var filters = new Predicate<Lesson>[] {
                x => string.IsNullOrWhiteSpace(teacher) || x.Teacher?.Id.ToString() == teacher,
                x => string.IsNullOrWhiteSpace(subject) || x.Subject.ToString() == subject,
                x => string.IsNullOrWhiteSpace(dayOfWeek) || x.DayOfWeek.ToString() == dayOfWeek
            };

            var lessons = _context.Lessons
                .Include(l => l.Room)
                .Join(
                   _context.Teachers,
                   l => l.TeacherId,
                   t => t.Id,
                   (l, t) => new Tuple<Lesson, Teacher>(l, t)
                )
                .ToList()
                .Where(x => filters.All(filter => filter(x.Item1)));

            ViewData["Teachers"] = new SelectList(new object[] { new { Id = "", FullName = "(כולם)" } }.Concat(_context.Teachers), "Id", "FullName", teacher);

            var parseSubject = Enum.TryParse<Subject>(subject, out var subjectValue);
            ViewData["Subjects"] = (parseSubject ? subjectValue : 0).ToSelectList(withEmpty: true);

            var parseDay = Enum.TryParse<DayOfWeek>(dayOfWeek, out var dayValue);
            ViewData["DaysOfWeek"] = (parseDay ? dayValue : (DayOfWeek) (-1)).ToSelectList(GetDayDisplayName, true);
            
            return View(lessons);
        }

        [Permissions(PermissionsLevel.Manage)]
        // GET: Lesson/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons
                .Include(l => l.Room)
                .Include(l => l.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // GET: Lesson/Create
        [Permissions(PermissionsLevel.Manage)]
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FullName");
            ViewData["Subject"] = Subject.Art.ToSelectList();
            ViewData["DayOfWeek"] = DayOfWeek.Sunday.ToSelectList(GetDayDisplayName);

            return View();
        }

        // POST: Lesson/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Permissions(PermissionsLevel.Manage)]
        public async Task<IActionResult> Create([Bind("TeacherId,RoomId,Subject,DayOfWeek,Hour,Id")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                lesson.Id = Guid.NewGuid();
                _context.Add(lesson);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", lesson.RoomId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FullName", lesson.TeacherId);
            ViewData["Subject"] = lesson.Subject.ToSelectList();
            ViewData["DayOfWeek"] = lesson.DayOfWeek.ToSelectList(GetDayDisplayName);

            return View(lesson);
        }

        // GET: Lesson/Edit/5
        [Permissions(PermissionsLevel.Manage)]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }

            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", lesson.RoomId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FullName", lesson.TeacherId);
            ViewData["Subject"] = lesson.Subject.ToSelectList();
            ViewData["DayOfWeek"] = lesson.DayOfWeek.ToSelectList(GetDayDisplayName);

            return View(lesson);
        }

        // POST: Lesson/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Permissions(PermissionsLevel.Manage)]
        public async Task<IActionResult> Edit(Guid id, [Bind("TeacherId,RoomId,Subject,DayOfWeek,Hour,Id")] Lesson lesson)
        {
            if (id != lesson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lesson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExists(lesson.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", lesson.RoomId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FullName", lesson.TeacherId);
            ViewData["Subject"] = lesson.Subject.ToSelectList();
            ViewData["DayOfWeek"] = lesson.DayOfWeek.ToSelectList(GetDayDisplayName);

            return View(lesson);
        }

        // GET: Lesson/Delete/5
        [Permissions(PermissionsLevel.Manage)]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons
                .Include(l => l.Room)
                .Include(l => l.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lesson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Permissions(PermissionsLevel.Manage)]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExists(Guid id)
        {
            return _context.Lessons.Any(e => e.Id == id);
        }

        public static string GetDayDisplayName(DayOfWeek day) {
            switch (day)
            {
                case DayOfWeek.Sunday:
                    return "ראשון";
                case DayOfWeek.Monday:
                    return "שני";
                case DayOfWeek.Tuesday:
                    return "שלישי";
                case DayOfWeek.Wednesday:
                    return "רביעי";
                case DayOfWeek.Thursday:
                    return "חמישי";
                case DayOfWeek.Friday:
                    return "שישי";
                case DayOfWeek.Saturday:
                    return "שבת";
                default:
                    return string.Empty;
            }
        }
    }
}
