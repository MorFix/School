using System.Collections.Generic;
using School.Enums;
using School.ViewModels;

namespace School.Entities
{
    public class Teacher : User
    {
        public IEnumerable<Lesson> Lessons { get; set; }
        
        public Teacher()
        {
        }

        public Teacher(string idNumber, string firstName, string lastName, string password, string address) : 
            base(idNumber, firstName, lastName, password, address, PermissionsLevel.Manage)
        {
            Lessons = new List<Lesson>();
        }

        public Teacher(UserViewModel userViewModel): base(userViewModel, PermissionsLevel.Manage)
        {
        }
    }
}