using System.ComponentModel.DataAnnotations;

namespace School.Enums
{
    public enum StudentBehavior
    {
        [Display(Name = "גרועה")]
        VeryBad,

        [Display(Name = "לא טובה")]
        Bad,

        [Display(Name = "מספיקה")]
        Enough,

        [Display(Name = "טובה")]
        Good,

        [Display(Name = "טובה מאוד")]
        VeryGood,
        
        [Display(Name = "מצוינת")]
        Excellent
    }
}
