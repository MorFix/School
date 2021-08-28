using System.Collections.Generic;
using SportStore.Enums;
using SportStore.ViewModels;

namespace SportStore.Entities
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