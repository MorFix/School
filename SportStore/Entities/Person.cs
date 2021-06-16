namespace SportStore.Entities
{
    public abstract class Person : BaseEntity
    {
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        protected Person(string idNumber, string firstName, string lastName, string password)
        {
            IdNumber = idNumber;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }
    }
}
