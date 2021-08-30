namespace School.ViewModels
{
    public class LoginViewModel
    {
        public string Error { get; set; }

        public LoginViewModel(string error)
        {
            Error = error;
        }
    }
}
