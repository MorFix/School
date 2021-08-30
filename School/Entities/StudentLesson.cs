using System;

namespace School.Entities
{
    public class StudentLesson
    {
        public Guid StudentsId { get; set; }
        public Guid LessonsId { get; set; }

        public StudentLesson(Guid studentId, Guid lessonId)
        {
            StudentsId = studentId;
            LessonsId = lessonId;
        }
    }
}