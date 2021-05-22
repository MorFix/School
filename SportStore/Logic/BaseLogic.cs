using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SportStore.DataBase;
using SportStore.Entities;

namespace SportStore.Logic
{
    public abstract class BaseLogic<T> where T : BaseEntity, new()
    {
        public SchoolContext Context { get; set; }

        public abstract DbSet<T> GetEntities();

        public IEnumerable<T> GetAll()
        {
            return GetEntities();
        }

        public T GetById(string id)
        {
            return GetEntities().Find(id);
        }

        public void Insert()
        {
        }

        public void Update(string id)
        {
        }

        public void Delete(string id)
        {
        }
    }
}
