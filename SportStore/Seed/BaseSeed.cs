using System.Collections.Generic;
using SportStore.Entities;

namespace SportStore.Seed
{
    public abstract class BaseSeed<T> where T : BaseEntity
    {
        public abstract IEnumerable<T> GetData();
    }
}