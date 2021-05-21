using System.Collections.Generic;

namespace SportStore.Entities
{
    public class Student : Person
    {
        public IEnumerable<Class> Classes { get; set; }
    }
}
