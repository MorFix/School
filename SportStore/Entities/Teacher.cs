using System.Collections.Generic;

namespace SportStore.Entities
{
    public class Teacher : Person
    {
        public IEnumerable<Class> Classes { get; set; }
        public IEnumerable<Lesson> Lessons { get; set; }

        public Teacher(string idNumber, string firstName, string lastName, string password)
            : base(idNumber, firstName, lastName, password)
        {
            Classes = new List<Class>();
            Lessons = new List<Lesson>();
        }
    }
}