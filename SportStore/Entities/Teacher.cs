using System.Collections.Generic;
using SportStore.Enums;

namespace SportStore.Entities
{
    public class Teacher : User
    {
        public IEnumerable<Lesson> Lessons { get; set; }
        
        public Teacher()
        {
        }

        public Teacher(string idNumber, string firstName, string lastName, string password, Point address) : 
            base(idNumber, firstName, lastName, password, address, PermissionsLevel.Manage)
        {
            Lessons = new List<Lesson>();
        }
    }
}