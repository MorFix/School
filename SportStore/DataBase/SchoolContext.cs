using Microsoft.EntityFrameworkCore;
using SportStore.Entities;
using SportStore.Seed;

namespace SportStore.DataBase
{
    public class SchoolContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var studentBuilder = modelBuilder.Entity<Student>(); 
            var teacherBuilder = modelBuilder.Entity<Teacher>(); 
            var lessonBuilder = modelBuilder.Entity<Lesson>(); 
            
            studentBuilder
                .HasOne(c => c.Classes)
                .WithMany(s => s.Students);

            studentBuilder
                .HasMany(s => s.Lessons)
                .WithMany(l => l.Students);

            studentBuilder.HasData(new StudentsSeed().GetData());
            
            teacherBuilder
                .HasMany(t => t.Classes)
                .WithOne(c => c.Teacher);
            teacherBuilder.HasData(new TeachersSeed().GetData());

            lessonBuilder
                .HasOne(l => l.Teacher)
                .WithMany(t => t.Lessons);
            lessonBuilder.HasData(new LessonsSeed().GetData());
        }
    }
}