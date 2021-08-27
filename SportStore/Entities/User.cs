using System.ComponentModel.DataAnnotations.Schema;
using SportStore.Enums;

namespace SportStore.Entities
{
    public abstract class User : BaseEntity
    {
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public double AddressX { get; set; }
        public double AddressY { get; set; }
        public PermissionsLevel permissionsLevel { get; set; }

        [NotMapped]
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

        protected User(string idNumber, string firstName, string lastName, string password, Point address, PermissionsLevel permissions)
        {
            IdNumber = idNumber;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            AddressX = address.X;
            AddressY = address.Y;
            permissionsLevel = permissions;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
