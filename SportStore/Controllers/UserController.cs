using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class UserController : Controller
    {
        private readonly SchoolContext _context;

        public UserController(SchoolContext context)
        {
            _context = context;
        }

        // GET: User
        public IActionResult Index(string idNumber = "", string name = "")
        {
            var currentUser = HttpContext.GetSchoolUser();

            var filters = new Predicate<User>[] {
                x => x.Id == currentUser.Id || x is Student,
                x => string.IsNullOrWhiteSpace(idNumber) || x.IdNumber.Contains(idNumber),
                x => string.IsNullOrWhiteSpace(name) || x.FullName.Contains(name, StringComparison.CurrentCultureIgnoreCase)
            };

            if (currentUser.permissionsLevel == PermissionsLevel.Manage) {
                var students = _context.Users.ToList()
                    .Where(x => filters.All(filter => filter(x)))
                    .OrderByDescending(x => x.Id == currentUser.Id);

                return View("Index", students);
            }

            return RedirectToAction("Details", new { id = currentUser.Id });
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentUser = HttpContext.GetSchoolUser();
            if (currentUser.permissionsLevel != PermissionsLevel.Manage)
            {
                id = currentUser.Id;
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            var userViewModel = new UserViewModel(user);
            ViewData["Classes"] = _context.Classes;
            ViewData["Type"] = userViewModel.Type.ToSelectList();

            return View("Details", userViewModel);
        }

        // GET: User/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Classes.ToList().OrderBy(x => x.Name), "Id", "Name");
            ViewData["Type"] = UserType.Student.ToSelectList();

            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create([Bind("IdNumber,FirstName,LastName,Password,Address, ClassId, Type")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var dbUser = _context.Users.FirstOrDefault(x => x.IdNumber == userViewModel.IdNumber);

                if (dbUser != null)
                {
                    ViewBag.Error = "?????? ???? ????";
                    ViewData["ClassId"] = new SelectList(_context.Classes.ToList().OrderBy(x => x.Name), "Id", "Name");
                    ViewData["Type"] = UserType.Student.ToSelectList();
                    return View();
                }

                if (userViewModel.Type == UserType.Student)
                {
                    var student = new Student(userViewModel);
                    var sClass = _context.Classes.First(x => x.Id == userViewModel.ClassId);
                    _context.Students.Add(student);
                }
                else if (userViewModel.Type == UserType.Teacher)
                {
                    var teacher = new Teacher(userViewModel);
                    _context.Teachers.Add(teacher);
                }

                await _context.SaveChangesAsync();

                return Redirect("/Home");
            }

            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Name");
            ViewData["Type"] = UserType.Student.ToSelectList();
            return View(userViewModel);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentUser = HttpContext.GetSchoolUser();
            if (currentUser.permissionsLevel != PermissionsLevel.Manage) {
                id = currentUser.Id;
            }

            var user = _context.Users
               .AsQueryable()
               .First(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            var userViewModel = new UserViewModel(user);
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Name");
            ViewData["Type"] = userViewModel.Type.ToSelectList();
            return View(userViewModel);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdNumber,FirstName,LastName,Password,Address,Id,ClassId,Type")] UserViewModel userViewModel)
        {
            if (id != userViewModel.Id)
            {
                return NotFound();
            }

            var currentUser = HttpContext.GetSchoolUser();
            if (currentUser.permissionsLevel != PermissionsLevel.Manage)
            {
                id = currentUser.Id;
            }

            var dbUser = await _context.Users.FindAsync(id);
            if (dbUser == null) {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                dbUser.Address = userViewModel.Address;
                dbUser.Password = userViewModel.Password;

                if (dbUser is Student)
                {
                    ((Student)dbUser).ClassId = userViewModel.ClassId;
                }

                _context.Update(dbUser);
                await _context.SaveChangesAsync();

                return Index();
            }

            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Name");
            ViewData["Type"] = userViewModel.Type.ToSelectList();
            return View(userViewModel);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentUser = HttpContext.GetSchoolUser();
            if (currentUser.permissionsLevel != PermissionsLevel.Manage)
            {
                id = currentUser.Id;
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var currentUser = HttpContext.GetSchoolUser();
            if (currentUser.permissionsLevel != PermissionsLevel.Manage)
            {
                id = currentUser.Id;
            }

            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            if (id == currentUser.Id) {
                await HttpContext.SignOutAsync();

                return RedirectToAction("Index", "Home");
            }

            return Index();
        }

        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
