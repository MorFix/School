using System;
using System.Collections.Generic;
using SportStore.Enums;
using SportStore.ViewModels;

namespace SportStore.Entities
{
    public class Student : User
    {
        public Guid ClassId { get; set; }
        public Class Class { get; set; }
        public virtual IEnumerable<Lesson> Lessons { get; set; }
        public StudentBehavior Behavior { get; set; }

        public Student()
        {
        }

        public Student(string idNumber, string firstName, string lastName, string password, Guid classId, string address,
            PermissionsLevel permissions = PermissionsLevel.Watch, StudentBehavior behavior = StudentBehavior.Good) : base(idNumber, firstName, lastName, password, address, permissions)
        {
            Lessons = new List<Lesson>();
            ClassId = classId;
            Behavior = behavior;
        }

        public Student(UserViewModel userViewModel) : base(userViewModel, PermissionsLevel.Watch)
        {
            Lessons = new List<Lesson>();
            ClassId = userViewModel.ClassId;
            Behavior = StudentBehavior.Good;
        }
    }
}
