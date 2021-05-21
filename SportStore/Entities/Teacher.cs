using System.Collections.Generic;

namespace SportStore.Entities
{
    public class Teacher : Person
    {
        public IEnumerable<Class> Classes { get; set; }
    }
}
