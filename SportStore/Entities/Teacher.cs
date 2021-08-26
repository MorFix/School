using System;
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

        public Teacher(string idNumber, string firstName, string lastName, string password, Point address, Guid id) : 
            base(idNumber, firstName, lastName, password, address, PermissionsLevel.Manage, id)
        {
            Lessons = new List<Lesson>();
        }
    }
}