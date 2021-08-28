using SportStore.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace SportStore.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        [Required, Display(Name = "תעודת זהות")]
        public string IdNumber { get; set; }
        [Required, Display(Name = "שם פרטי")]
        public string FirstName { get; set; }
        [Required, Display(Name = "שם משפחה")]
        public string LastName { get; set; }
        [Required, Display(Name = "סיסמא")]
        public string Password { get; set; }
        [Required, Display(Name = "סוג משתמש")]
        public UserType Type { get; set; }
        [Required, Display(Name = "כתובת")]
        public string Address { get; set; }
        [Display(Name="כיתה")]
        public Guid ClassId { get; set; }


        public UserViewModel() { }

        public UserViewModel(User user)
        {
            Id = user.Id;
            IdNumber = user.IdNumber;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Password = user.Password;
            Address = user.Address;
            Type = user is Student ? UserType.Student : UserType.Teacher;

            if (user is Student student)
            {
                ClassId = student.ClassId;
            }
        }
    }
}