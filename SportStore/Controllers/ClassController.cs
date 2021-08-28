using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportStore.Controllers.Security;
using SportStore.DataBase;
using SportStore.Entities;
using SportStore.Enums;
using SportStore.ViewModels;

namespace SportStore.Controllers
{
    public class ClassController : Controller
    {
        private readonly SchoolContext _context;

        public ClassController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Class
        [Permissions(PermissionsLevel.Manage)]
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Classes.Include(x => x.Room).Include(x => x.Teacher);
            return View(await schoolContext.ToListAsync());
        }

        // GET: Class/Details/5
        [Permissions(PermissionsLevel.Manage)]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Classes
                .Include(x => x.Room)
                .Include(x => x.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        public IActionResult GroupedClasses()
        {
            var classesList = _context.Classes
                .Join(
                    _context.Students,
                    c => c.Id,
                    s => s.ClassId,
                    (c, s) => new
                    {
                        ClassName = c.Name,
                        FirstName = s.FirstName,
                        LastName = s.LastName
                    }
                    ).ToList().OrderBy(x => x.ClassName)
                    .GroupBy(x => x.ClassName, x => new FullNameViewModel(x.FirstName, x.LastName));

            return View(classesList);
        }

        // GET: Class/Create
        [Permissions(PermissionsLevel.Manage)]
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FullName");
            ViewData["Level"] = ClassLevel.First.ToSelectList();

            return View();
        }

        // POST: Class/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Permissions(PermissionsLevel.Manage)]
        public async Task<IActionResult> Create([Bind("Name,Level,TeacherId,RoomId,Id")] Class @class)
        {
            if (ModelState.IsValid)
            {
                @class.Id = Guid.NewGuid();
                _context.Add(@class);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", @class.RoomId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FullName", @class.TeacherId);
            ViewData["Level"] = @class.Level.ToSelectList();

            return View(@class);
        }

        // GET: Class/Edit/5
        [Permissions(PermissionsLevel.Manage)]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Classes.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", @class.RoomId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FullName", @class.TeacherId);
            ViewData["Level"] = @class.Level.ToSelectList();

            return View(@class);
        }

        // POST: Class/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Permissions(PermissionsLevel.Manage)]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Level,TeacherId,RoomId,Id")] Class @class)
        {
            if (id != @class.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@class);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(@class.Id))
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
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", @class.RoomId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FullName", @class.TeacherId);
            ViewData["Level"] = @class.Level.ToSelectList();

            return View(@class);
        }

        // GET: Class/Delete/5
        [Permissions(PermissionsLevel.Manage)]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Classes
                .Include(x => x.Room)
                .Include(x => x.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // POST: Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Permissions(PermissionsLevel.Manage)]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var @class = await _context.Classes.FindAsync(id);
            _context.Classes.Remove(@class);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(Guid id)
        {
            return _context.Classes.Any(e => e.Id == id);
        }
    }
}
