using System.ComponentModel.DataAnnotations;

namespace SportStore.ViewModels
{
    public enum UserType
    {
        [Display(Name = "תלמיד")]
        Student = 1,
        [Display(Name = "מורה")]
        Teacher
    }
}
