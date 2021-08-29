using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportStore.Controllers.Security;
using SportStore.DataBase;
using SportStore.Entities;
using SportStore.Enums;

namespace SportStore.Controllers
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
        public async Task<IActionResult> Index(string teacher = "")
        {
            var hasQuery = !string.IsNullOrWhiteSpace(teacher);
            var lessons = await _context.Lessons
                .Include(l => l.Room)
                .Include(l => l.Teacher)
                .ToListAsync();

            return View(lessons.Where(x => !hasQuery || x.Teacher != null && x.Teacher.FullName.Contains(teacher, StringComparison.CurrentCultureIgnoreCase)));
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
    }
}
