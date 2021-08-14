using SportStore.Entities;
using SportStore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportStore.Seed
{
    public class SchoolSeed
    {
        public IEnumerable<Teacher> Teachers { get; set; } = new List<Teacher>();
        public IEnumerable<Class> Classes { get; set; } = new List<Class>();
        public IEnumerable<Lesson> Lessons { get; set; } = new List<Lesson>();
        public IEnumerable<Student> Students { get; set; } = new List<Student>();

        public SchoolSeed()
        {
            InitializeSchool();
        }

        private void InitializeSchool()
        {
            var teacher1 = new Teacher("12345671", "Shlomi", "Arssof", "1234");
            var teacher2 = new Teacher("12345672", "Alon", "Mek", "1234");
            var teacher3 = new Teacher("12345673", "Avi", "Yossef", "1234");
            var teacher4 = new Teacher("12345674", "Einat", "Alon", "1234");
            var teacher5 = new Teacher("12345675", "Sharon", "Grossman", "1234");
            var teacher6 = new Teacher("12345676", "Rachel", "Zarfati", "1234");
            var teacher7 = new Teacher("12345677", "Lior", "Lod", "1234");
            var teacher8 = new Teacher("12345678", "Dror", "Perl", "1234");

            var class1 = new Class("A1", teacher1.Id);
            var class2 = new Class("A2", teacher2.Id);
            var class3 = new Class("A3", teacher3.Id);

            var student1 = new Student("312345614", "Avi", "Menash", "1234", class1.Id);
            var student2 = new Student("314345628", "Orli", "Avraham", "1234", class1.Id);
            var student3 = new Student("316345631", "Daniel", "Amit", "1234", class1.Id);
            var student4 = new Student("314832911", "Michael", "Menash", "1234", class1.Id);
            var student5 = new Student("325674677", "Ronit", "Danon", "1234", class1.Id);
            var student6 = new Student("325142444", "Amit", "Hachmon", "1234", class1.Id);
            var student7 = new Student("318273625", "Dana", "Erez", "1234", class1.Id);
            var student8 = new Student("324152614", "May", "Menash", "1234", class2.Id);
            var student9 = new Student("211234561", "Maya", "Menash", "1234", class2.Id);
            var student10 = new Student("211234561", "Rahav", "Menash", "1234", class2.Id);
            var student11 = new Student("211234561", "Ori", "Menash", "1234", class2.Id);
            var student12 = new Student("411234561", "Avi", "Menash", "1234", class2.Id);
            var student13 = new Student("211234561", "Michal", "Menash", "1234", class2.Id);
            var student14 = new Student("411234561", "Avi", "Menash", "1234", class2.Id);
            var student15 = new Student("311234561", "Avi", "Menash", "1234", class3.Id);
            var student16 = new Student("223234561", "Omer", "Menash", "1234", class3.Id);
            var student17 = new Student("215243222", "Tal", "Menash", "1234", class3.Id);
            var student18 = new Student("231144562", "Noa", "Menash", "1234", class3.Id);
            var student19 = new Student("311278522", "Yael`", "Menash", "1234", class3.Id);
            var student20 = new Student("266254190", "Lior", "Menash", "1234", class3.Id);

            // Sunday
            var lessonSunday1A1 = new Lesson(teacher1.Id, Subject.Art, DayOfWeek.Sunday, 1) {Students = class1.Students};
            var lessonSunday2A1A2 = new Lesson(teacher2.Id, Subject.Boxing, DayOfWeek.Sunday, 2){Students = class1.Students.Concat(class2.Students)};
            var lessonSunday3A1 = new Lesson(teacher3.Id, Subject.Economics, DayOfWeek.Sunday, 3) { Students = class1.Students };
            var lessonSunday4A1 = new Lesson(teacher4.Id, Subject.English, DayOfWeek.Sunday, 4) {Students = class1.Students};
            var lessonSunday5A1 = new Lesson(teacher5.Id, Subject.Math, DayOfWeek.Sunday, 5) {Students = class1.Students};
            var lessonSunday6A1 = new Lesson(teacher6.Id,  Subject.Music, DayOfWeek.Sunday, 6){Students = class1.Students};
                                                     
            var lessonSunday1A2 = new Lesson(teacher5.Id, Subject.Art, DayOfWeek.Sunday, 1) { Students = class2.Students };
            var lessonSunday3A2 = new Lesson(teacher2.Id, Subject.Economics, DayOfWeek.Sunday, 3) { Students = class2.Students };
            var lessonSunday4A2 = new Lesson(teacher3.Id, Subject.English, DayOfWeek.Sunday, 4) { Students = class2.Students };
            var lessonSunday5A2 = new Lesson(teacher1.Id, Subject.Math, DayOfWeek.Sunday, 5) { Students = class2.Students };

            var lessonSunday1A3 = new Lesson(teacher2.Id, Subject.Art, DayOfWeek.Sunday, 1) { Students = class3.Students };
            var lessonSunday2A3 = new Lesson(teacher3.Id, Subject.Boxing, DayOfWeek.Sunday, 2) { Students = class3.Students };
            var lessonSunday3A3 = new Lesson(teacher4.Id, Subject.Economics, DayOfWeek.Sunday, 3) { Students = class3.Students };
            var lessonSunday4A3 = new Lesson(teacher5.Id, Subject.English, DayOfWeek.Sunday, 4) { Students = class3.Students };
            var lessonSunday5A3 = new Lesson(teacher6.Id, Subject.Math, DayOfWeek.Sunday, 5) { Students = class3.Students };
            var lessonSunday6A3 = new Lesson(teacher7.Id, Subject.Music, DayOfWeek.Sunday, 6) { Students = class3.Students };
            var lessonSunday7A3 = new Lesson(teacher1.Id, Subject.Music, DayOfWeek.Sunday, 6) { Students = class3.Students };

            // Monday                                 
            var lessonMonday1A1 = new Lesson(teacher1.Id, Subject.Art, DayOfWeek.Monday, 1) { Students = class1.Students };
            var lessonMonday2A1 = new Lesson(teacher2.Id, Subject.Boxing, DayOfWeek.Monday, 2) { Students = class1.Students };
            var lessonMonday3A1 = new Lesson(teacher8.Id, Subject.English, DayOfWeek.Monday, 3) { Students = class1.Students };
            var lessonMonday4A1 = new Lesson(teacher4.Id, Subject.Math, DayOfWeek.Monday, 4) { Students = class1.Students };
            var lessonMonday5A1 = new Lesson(teacher5.Id, Subject.Music, DayOfWeek.Monday, 5) { Students = class1.Students };
                                                     
            var lessonMonday1A2 = new Lesson(teacher1.Id, Subject.Art, DayOfWeek.Monday, 1) { Students = class2.Students };
            var lessonMonday2A2 = new Lesson(teacher2.Id, Subject.Boxing, DayOfWeek.Monday, 2) { Students = class2.Students };
            var lessonMonday3A2 = new Lesson(teacher7.Id, Subject.English, DayOfWeek.Monday, 3) { Students = class2.Students };
            var lessonMonday4A2 = new Lesson(teacher4.Id, Subject.Math, DayOfWeek.Monday, 4) { Students = class2.Students };
                                                     
            var lessonMonday1A3 = new Lesson(teacher2.Id, Subject.Art, DayOfWeek.Monday, 1) { Students = class3.Students };
            var lessonMonday2A3 = new Lesson(teacher3.Id, Subject.Boxing, DayOfWeek.Monday, 2) { Students = class3.Students };
            var lessonMonday3A3 = new Lesson(teacher4.Id, Subject.English, DayOfWeek.Monday, 3) { Students = class3.Students };
            var lessonMonday4A3 = new Lesson(teacher7.Id, Subject.Math, DayOfWeek.Monday, 4) { Students = class3.Students };

            // Tuesday
            var lessonTuesday1A1A2A3 = new Lesson(teacher1.Id, Subject.Music, DayOfWeek.Tuesday, 1){ Students = class1.Students.Concat(class2.Students.Concat(class3.Students)) };
            var lessonTuesday2A1A2A3 = new Lesson(teacher2.Id, Subject.Music, DayOfWeek.Tuesday, 2) { Students = class1.Students.Concat(class2.Students.Concat(class3.Students)) };
            var lessonTuesday3A1 = new Lesson(teacher8.Id, Subject.Spanish, DayOfWeek.Tuesday, 3) { Students = class1.Students };
            var lessonTuesday4A1 = new Lesson(teacher4.Id, Subject.Boxing, DayOfWeek.Tuesday, 4) { Students = class1.Students };
            var lessonTuesday5A1 = new Lesson(teacher5.Id, Subject.Economics, DayOfWeek.Tuesday, 5) { Students = class1.Students };
            var lessonTuesday6A1 = new Lesson(teacher6.Id, Subject.Art, DayOfWeek.Tuesday, 6) { Students = class1.Students };

            var lessonTuesday3A2 = new Lesson(teacher4.Id, Subject.Spanish, DayOfWeek.Tuesday, 3) { Students = class2.Students };
            var lessonTuesday4A2 = new Lesson(teacher3.Id, Subject.Boxing, DayOfWeek.Tuesday, 4) { Students = class2.Students };
            var lessonTuesday5A2 = new Lesson(teacher7.Id, Subject.Economics, DayOfWeek.Tuesday, 5) { Students = class2.Students };
            var lessonTuesday6A2 = new Lesson(teacher1.Id, Subject.Art, DayOfWeek.Tuesday, 6) { Students = class2.Students };

            var lessonTuesday3A3 = new Lesson(teacher2.Id, Subject.Spanish, DayOfWeek.Tuesday, 3) { Students = class3.Students };
            var lessonTuesday4A3 = new Lesson(teacher1.Id, Subject.Boxing, DayOfWeek.Tuesday, 4) { Students = class3.Students };
            var lessonTuesday5A3 = new Lesson(teacher7.Id, Subject.Economics, DayOfWeek.Tuesday, 5) { Students = class3.Students };
            var lessonTuesday6A3 = new Lesson(teacher8.Id, Subject.Art, DayOfWeek.Tuesday, 6) { Students = class3.Students };

            // Wednesday
            var lessonWednesday1A1 = new Lesson(teacher1.Id, Subject.Spanish, DayOfWeek.Wednesday, 1) { Students = class1.Students };
            var lessonWednesday2A1 = new Lesson(teacher2.Id, Subject.English, DayOfWeek.Wednesday, 2) { Students = class1.Students };
            var lessonWednesday3A1 = new Lesson(teacher3.Id, Subject.English, DayOfWeek.Wednesday, 3) { Students = class1.Students };
            var lessonWednesday4A1 = new Lesson(teacher4.Id, Subject.Economics, DayOfWeek.Wednesday, 4) { Students = class1.Students };
                                                        
            var lessonWednesday1A2 = new Lesson(teacher7.Id, Subject.Spanish, DayOfWeek.Wednesday, 1) { Students = class2.Students };
            var lessonWednesday2A2 = new Lesson(teacher8.Id, Subject.English, DayOfWeek.Wednesday, 2) { Students = class2.Students };
            var lessonWednesday3A2 = new Lesson(teacher3.Id, Subject.English, DayOfWeek.Wednesday, 3) { Students = class2.Students };
            var lessonWednesday4A2 = new Lesson(teacher4.Id, Subject.Economics, DayOfWeek.Wednesday, 4) { Students = class2.Students };
                                                        
            var lessonWednesday1A3 = new Lesson(teacher3.Id, Subject.Spanish, DayOfWeek.Wednesday, 1) { Students = class3.Students };
            var lessonWednesday2A3 = new Lesson(teacher4.Id, Subject.English, DayOfWeek.Wednesday, 2) { Students = class3.Students };
            var lessonWednesday3A3 = new Lesson(teacher7.Id, Subject.English, DayOfWeek.Wednesday, 3) { Students = class3.Students };
            var lessonWednesday4A3 = new Lesson(teacher8.Id, Subject.Economics, DayOfWeek.Wednesday, 4) { Students = class3.Students };

            // Thursday
            var lessonThursday1A1 = new Lesson(teacher1.Id, Subject.Boxing, DayOfWeek.Thursday, 1) { Students = class1.Students };
            var lessonThursday3A1 = new Lesson(teacher2.Id, Subject.Boxing, DayOfWeek.Thursday, 2) { Students = class1.Students };
            var lessonThursday4A1 = new Lesson(teacher3.Id, Subject.Math, DayOfWeek.Thursday, 3) { Students = class1.Students };
            var lessonThursday5A1 = new Lesson(teacher4.Id, Subject.Math, DayOfWeek.Thursday, 4) { Students = class1.Students };
            var lessonThursday6A1 = new Lesson(teacher5.Id, Subject.Math, DayOfWeek.Thursday, 5) { Students = class1.Students };
            var lessonThursday7A1 = new Lesson(teacher6.Id, Subject.Math, DayOfWeek.Thursday, 6) { Students = class1.Students };
            var lessonThursday8A1 = new Lesson(teacher7.Id, Subject.Art, DayOfWeek.Thursday, 7) { Students = class1.Students };
                                                       
            var lessonThursday1A2 = new Lesson(teacher7.Id, Subject.Boxing, DayOfWeek.Thursday, 1) { Students = class2.Students };
            var lessonThursday3A2 = new Lesson(teacher8.Id, Subject.Boxing, DayOfWeek.Thursday, 2) {Students = class2.Students};
            var lessonThursday4A2 = new Lesson(teacher1.Id, Subject.Math, DayOfWeek.Thursday, 3) { Students = class2.Students };
            var lessonThursday5A2 = new Lesson(teacher2.Id, Subject.Math, DayOfWeek.Thursday, 4) { Students = class2.Students };
            var lessonThursday6A2 = new Lesson(teacher3.Id, Subject.Math, DayOfWeek.Thursday, 5) { Students = class2.Students };
            var lessonThursday7A2 = new Lesson(teacher4.Id, Subject.Math, DayOfWeek.Thursday, 6) { Students = class2.Students };
                                                       
            var lessonThursday1A3 = new Lesson(teacher4.Id, Subject.Boxing, DayOfWeek.Thursday, 1) { Students = class2.Students };
            var lessonThursday3A3 = new Lesson(teacher3.Id, Subject.Boxing, DayOfWeek.Thursday, 2) { Students = class2.Students };
            var lessonThursday4A3 = new Lesson(teacher8.Id, Subject.Math, DayOfWeek.Thursday, 3) { Students = class2.Students };
            var lessonThursday5A3 = new Lesson(teacher7.Id, Subject.Math, DayOfWeek.Thursday, 4) { Students = class2.Students };
            var lessonThursday6A3 = new Lesson(teacher6.Id, Subject.Math, DayOfWeek.Thursday, 5) { Students = class2.Students };
            var lessonThursday7A3 = new Lesson(teacher5.Id, Subject.Math, DayOfWeek.Thursday, 6) { Students = class2.Students };
            var lessonThursday8A3 = new Lesson(teacher2.Id, Subject.Art, DayOfWeek.Thursday, 7) { Students = class2.Students };

            teacher1.Lessons = new Lesson[]
            {
                lessonSunday1A1, lessonSunday5A2, lessonSunday7A3, lessonMonday1A1, lessonMonday1A2,
                lessonTuesday1A1A2A3, lessonTuesday6A2, lessonTuesday4A3, lessonWednesday1A1, lessonThursday1A1,
                lessonThursday4A2
            };
            teacher2.Lessons = new Lesson[]
            {
                lessonSunday2A1A2, lessonSunday3A2, lessonSunday1A3, lessonMonday2A1, lessonMonday2A2,
                lessonMonday1A3, lessonTuesday2A1A2A3, lessonTuesday3A3, lessonWednesday2A1, lessonThursday3A1,
                lessonThursday5A2, lessonThursday8A3
            };
            teacher3.Lessons = new Lesson[]
            {
                lessonSunday3A1, lessonSunday4A2, lessonSunday2A3, lessonMonday2A3, lessonTuesday4A2,
                lessonWednesday3A1, lessonWednesday3A2, lessonWednesday1A3, lessonThursday4A1, lessonThursday6A2,
                lessonThursday3A3
            };
            teacher4.Lessons = new Lesson[]
            {
                lessonSunday4A1, lessonSunday3A3, lessonMonday4A1, lessonMonday4A2,
                lessonMonday3A3, lessonTuesday4A1, lessonTuesday3A2, lessonWednesday4A1, lessonWednesday4A2,
                lessonWednesday2A3, lessonThursday5A1, lessonThursday7A2, lessonThursday1A3
            };
            teacher5.Lessons = new Lesson[]
            {
                lessonSunday5A1, lessonSunday1A2, lessonSunday4A3, lessonMonday5A1, lessonTuesday5A1,
                lessonThursday6A1, lessonThursday7A3
            };
            teacher6.Lessons = new Lesson[]
                {lessonSunday6A1, lessonSunday5A3, lessonTuesday6A1, lessonThursday7A1, lessonThursday6A3};
            teacher7.Lessons = new Lesson[]
            {
                lessonSunday6A3, lessonMonday3A2, lessonMonday4A3, lessonTuesday5A2, lessonTuesday5A3,
                lessonWednesday1A2,
                lessonWednesday3A3, lessonThursday8A1, lessonThursday1A2, lessonThursday5A3,
            };
            teacher8.Lessons = new Lesson[]
            {
                lessonMonday3A1, lessonTuesday3A1, lessonTuesday6A3, lessonWednesday2A2, lessonWednesday4A3,
                lessonThursday3A2, lessonThursday4A3
            };


            Teachers = new Teacher[] {teacher1, teacher2, teacher3, teacher4, teacher5, teacher6, teacher7, teacher8};
            Students = new Student[]
            {
                student1, student2, student4, student4, student5, student6, student7, student8,
                student9, student10, student11, student12, student13, student14, student15, student16, student17,
                student18, student19, student20
            };
            Classes = new Class[] {class1, class2, class3};
            Lessons = new Lesson[]
            {
                lessonSunday1A1,
                lessonSunday2A1A2,
                lessonSunday3A1,
                lessonSunday4A1,
                lessonSunday5A1,
                lessonSunday6A1,
                lessonSunday1A2,
                lessonSunday3A2,
                lessonSunday4A2,
                lessonSunday5A2,
                lessonSunday1A3,
                lessonSunday2A3,
                lessonSunday3A3,
                lessonSunday4A3,
                lessonSunday5A3,
                lessonSunday6A3,
                lessonSunday7A3,
                lessonMonday1A1,
                lessonMonday2A1,
                lessonMonday3A1,
                lessonMonday4A1,
                lessonMonday5A1,
                lessonMonday1A2,
                lessonMonday2A2,
                lessonMonday3A2,
                lessonMonday4A2,
                lessonMonday1A3,
                lessonMonday2A3,
                lessonMonday3A3,
                lessonMonday4A3,
                lessonTuesday1A1A2A3,
                lessonTuesday2A1A2A3,
                lessonTuesday3A1,
                lessonTuesday4A1,
                lessonTuesday5A1,
                lessonTuesday6A1,
                lessonTuesday3A2,
                lessonTuesday4A2,
                lessonTuesday5A2,
                lessonTuesday6A2,
                lessonTuesday3A3,
                lessonTuesday4A3,
                lessonTuesday5A3,
                lessonTuesday6A3,
                lessonWednesday1A1,
                lessonWednesday2A1,
                lessonWednesday3A1,
                lessonWednesday4A1,
                lessonWednesday1A2,
                lessonWednesday2A2,
                lessonWednesday3A2,
                lessonWednesday4A2,
                lessonWednesday1A3,
                lessonWednesday2A3,
                lessonWednesday3A3,
                lessonWednesday4A3,
                lessonThursday1A1,
                lessonThursday3A1,
                lessonThursday4A1,
                lessonThursday5A1,
                lessonThursday6A1,
                lessonThursday7A1,
                lessonThursday8A1,
                lessonThursday1A2,
                lessonThursday3A2,
                lessonThursday4A2,
                lessonThursday5A2,
                lessonThursday6A2,
                lessonThursday7A2,
                lessonThursday1A3,
                lessonThursday3A3,
                lessonThursday4A3,
                lessonThursday5A3,
                lessonThursday6A3,
                lessonThursday7A3,
                lessonThursday8A3
            };
        }
    }
}