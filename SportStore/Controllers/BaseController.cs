using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SportStore.DataBase;
using SportStore.Entities;

namespace SportStore.Controllers
{
    public abstract class BaseController<T> : Controller where T : BaseEntity, new()
    {
        private readonly SchoolContext _context;

        protected BaseController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return View(new List<T>());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return View(new T());
        }


        [HttpPost]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id)
        {
            return View();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return View();
        }
    }
}
