using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SportStore.Entities;

namespace SportStore.Controllers
{
    public abstract class BaseController<T> : Controller where T : BaseEntity, new()
    {
        [HttpGet]
        public IEnumerable<T> GetAll()
        {
            return new List<T>();
        }

        [HttpGet("{id}")]
        public T GetById(string id)
        {
            return new T();
        }


        [HttpPost]
        public void Insert()
        {

        }

        [HttpPut("{id}")]
        public void Update(string id)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {

        }
    }
}
