using System;
namespace SportStore.Models
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
