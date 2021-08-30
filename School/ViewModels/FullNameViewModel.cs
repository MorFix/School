
namespace School.ViewModels
{
    public class FullNameViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public FullNameViewModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
