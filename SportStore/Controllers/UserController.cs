using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportStore.DataBase;
using SportStore.Entities;
using SportStore.Enums;
using SportStore.ViewModels;

namespace SportStore.Controllers
{
    public class UserController : Controller
    {
        private readonly SchoolContext _context;

        public UserController(SchoolContext context)
        {
            _context = context;
        }

        // GET: User
        public IActionResult Index()
        {
            var idNumber = User.Identity.Name;
            var isManagerLevel = _context.Users
               .AsQueryable()
               .First(x => x.IdNumber == idNumber).permissionsLevel == PermissionsLevel.Manage;

            return View(_context.Users.ToList()
                .Where(x => x.IdNumber == idNumber || (isManagerLevel && x is Student))
                .OrderByDescending(x => x.IdNumber == idNumber));
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            var userViewModel = new UserViewModel(user);
            ViewData["Classes"] = _context.Classes;
            ViewData["Type"] = EnumToSelectList(userViewModel.Type);

            return View(userViewModel);
        }

        // GET: User/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Classes.ToList().OrderBy(x => x.Name), "Id", "Name");
            ViewData["Type"] = EnumToSelectList<UserType>();

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
                    ViewBag.Error = "המשתמש קיים במערכת";
                    ViewData["ClassId"] = new SelectList(_context.Classes.ToList().OrderBy(x => x.Name), "Id", "Name");
                    ViewData["Type"] = EnumToSelectList<UserType>();
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
            ViewData["Type"] = EnumToSelectList<UserType>();
            return View(userViewModel);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
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
            ViewData["Type"] = EnumToSelectList(userViewModel.Type);
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

            if (ModelState.IsValid)
            {
                try
                {
                    var dbUser = _context.Users
                        .FirstOrDefault(x => x.IdNumber == userViewModel.IdNumber && x.IdNumber == User.Identity.Name);

                    dbUser.Address = userViewModel.Address;
                    dbUser.Password = userViewModel.Password;

                    if (dbUser is Student)
                    {
                        ((Student)dbUser).ClassId = userViewModel.ClassId;
                    }

                    _context.Update(dbUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(userViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Home");
            }

            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Name");
            ViewData["Type"] = EnumToSelectList(userViewModel.Type);
            return View(userViewModel);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
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
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        private SelectList EnumToSelectList<TEnum>(TEnum enumObj = default)
          where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                         select new { Id = e, Name = GetEnumDisplayName(e) };

            return new SelectList(values, "Id", "Name", enumObj);
        }

        private string GetEnumDisplayName<TEnum>(TEnum enumObj)
           where TEnum : struct
        {
            return enumObj.GetType()
                            .GetMember(enumObj.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            ?.GetName();
        }
    }
}
