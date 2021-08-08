namespace SportStore.Entities
{
    public class Student : Person
    {
        public Class Class { get; set; }

        public Student(string idNumber, string firstName, string lastName, string password)
            : base(idNumber, firstName, lastName, password)
        {
        }
    }
}