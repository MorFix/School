using System.Collections.Generic;

namespace SportStore.Entities
{
    public class Student : Person
    {
        public Class Class { get; set; }
        public List<Lesson> Lessons { get; set; }

        public Student(string idNumber, string firstName, string lastName, string password)
            : base(idNumber, firstName, lastName, password)
        {
            Lessons = new List<Lesson>();
        }
    }
}