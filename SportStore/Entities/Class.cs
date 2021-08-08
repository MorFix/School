using System.Collections.Generic;

namespace SportStore.Entities
{
    public class Class : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Student> Students { get; set; }

        public IEnumerable<Lesson> Lessons { get; set; }
        public Class(string name)
        {
            Name = name;
            Students = new List<Student>();
            Lessons = new List<Lesson>();
        }
    }
}