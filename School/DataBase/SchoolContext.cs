using Microsoft.EntityFrameworkCore;
using School.Entities;
using School.Seed;

namespace School.DataBase
{
    public class SchoolContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var studentBuilder = modelBuilder.Entity<Student>();
            var teacherBuilder = modelBuilder.Entity<Teacher>();
            var lessonBuilder = modelBuilder.Entity<Lesson>();
            var classBuilder = modelBuilder.Entity<Class>();
            var roomBuilder = modelBuilder.Entity<Room>();

            var seeder = new SchoolSeed();
            studentBuilder.HasData(seeder.Students);
            teacherBuilder.HasData(seeder.Teachers);
            roomBuilder.HasData(seeder.Rooms);
            lessonBuilder.HasData(seeder.Lessons);
            classBuilder.HasData(seeder.Classes);

            studentBuilder
                .HasOne(c => c.Class)
                .WithMany(s => s.Students);

            classBuilder
                .HasMany(c => c.Students)
                .WithOne(s => s.Class);
            classBuilder
                .HasOne(c => c.Teacher);
            classBuilder
                .HasOne(c => c.Room);

            lessonBuilder
                .HasMany(l=> l.Students)
                .WithMany(s => s.Lessons)
                .UsingEntity(j => j.HasData(seeder.StudentsLessons));

            lessonBuilder
                .HasOne(l => l.Teacher)
                .WithMany(t => t.Lessons);

            lessonBuilder
                .HasOne(l => l.Room);

            teacherBuilder
                .HasMany(t => t.Lessons)
                .WithOne(l => l.Teacher);
        }
    }
}