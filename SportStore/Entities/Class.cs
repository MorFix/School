using System.Collections.Generic;

namespace SportStore.Entities
{
    public class Class : BaseEntity
    {
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
