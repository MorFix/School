using SportStore.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace SportStore.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "חובה להזין תעודת זהות תקינה"), RegularExpression("^\\d{8,9}$", ErrorMessage = "מספר תעודת הזהות הינו רצף של 8 או 9 ספרות"), Display(Name = "תעודת זהות")]
        public string IdNumber { get; set; }
        [Required(ErrorMessage = "חובה להזין שם פרטי"), Display(Name = "שם פרטי")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "חובה להזין שם משפחה"), Display(Name = "שם משפחה")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "חובה להזין סיסמא"), Display(Name = "סיסמא")]
        public string Password { get; set; }
        [Required, Display(Name = "סוג משתמש")]
        public UserType Type { get; set; }
        [Required(ErrorMessage = "חובה להזין כתובת"), Display(Name = "כתובת")]
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