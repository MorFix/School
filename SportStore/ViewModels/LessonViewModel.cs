using System.Collections.Generic;
using SportStore.Entities;

namespace SportStore.ViewModels
{
    public class LessonViewModel
    {
        public List<Lesson> Lessons { get; set; }
        public List<Teacher> Teachers { get; set; }

        public LessonViewModel()
        {
            Lessons = new List<Lesson>();
            Teachers = new List<Teacher>();
        }
    }
}