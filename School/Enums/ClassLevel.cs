using System.ComponentModel.DataAnnotations;

namespace School.Enums
{
    public enum ClassLevel
    {
        [Display(Name = "א")]
        First = 1,

        [Display(Name = "ב")]
        Second,

        [Display(Name = "ג")]
        Third,

        [Display(Name = "ד")]
        Forth,

        [Display(Name = "ה")]
        Fifth,

        [Display(Name = "ו")]
        Sixth,

        [Display(Name = "ז")]
        Seventh,

        [Display(Name = "ח")]
        Eighth,

        [Display(Name = "ט")]
        Ninth,

        [Display(Name = "י")]
        Tenth,

        [Display(Name = "יא")]
        Eleventh,

        [Display(Name = "יב")]
        Twelveth
    }
}