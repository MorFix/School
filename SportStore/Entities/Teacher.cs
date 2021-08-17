using System.Collections.Generic;

namespace SportStore.Entities
{
    public class Teacher : User
    {
        public IEnumerable<Lesson> Lessons { get; set; }
        
        public Teacher()
        {
        }

        public Teacher(string idNumber, string firstName, string lastName, string password) : 
            base(idNumber, firstName, lastName, password)
        {
            Lessons = new List<Lesson>();
        }
    }
}