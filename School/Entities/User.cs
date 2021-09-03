using System.ComponentModel.DataAnnotations.Schema;
using School.Enums;
using School.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace School.Entities
{
    public abstract class User : BaseEntity
    {
        [Display(Name = "תעודת זהות")]
        public string IdNumber { get; set; }
        [Display(Name = "שם פרטי")]
        public string FirstName { get; set; }
        [Display(Name = "שם משפחה")]
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public PermissionsLevel permissionsLevel { get; set; }

        [NotMapped]
        [Display(Name = "שם")]
        public string FullName
        {
            get
            {
                return ToString();
            }
        }

        protected User()
        {
        }

        protected User(string idNumber, string firstName, string lastName, string password, string address, PermissionsLevel permissions)
        {
            IdNumber = idNumber;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Address = address;
            permissionsLevel = permissions;
        }

        protected User(UserViewModel userViewModel, PermissionsLevel permissions)
        {
            IdNumber = userViewModel.IdNumber;
            FirstName = userViewModel.FirstName;
            LastName = userViewModel.LastName;
            Password = userViewModel.Password;
            Address = userViewModel.Address;
            permissionsLevel = permissions;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
