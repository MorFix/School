using System.ComponentModel.DataAnnotations;

namespace SportStore.Enums
{
    public enum Subject
    {
        [Display(Name = "אנגלית")]
        English = 1,

        [Display(Name = "ספרדית")]
        Spanish,

        [Display(Name = "אמנות")]
        Art,

        [Display(Name = "מוזיקה")]
        Music,

        [Display(Name = "אגרוף")]
        Boxing,

        [Display(Name = "כלכלה")]
        Economics,

        [Display(Name = "מתמטיקה")]
        Math
    }
}
