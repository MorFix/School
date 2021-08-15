using System;
using System.Collections.Generic;

namespace SportStore.Entities
{
    public class Student : Person
    {
        public Guid ClassId { get; set; }
        public Class Class { get; set; }
        public virtual IEnumerable<Lesson> Lessons { get; set; }

        public Student()
        {
        }

        public Student(string idNumber, string firstName, string lastName, string password, Guid classId)
            : base(idNumber, firstName, lastName, password)
        {
            Lessons = new List<Lesson>();
            ClassId = classId;
        }
    }
}
