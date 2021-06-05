using Microsoft.EntityFrameworkCore;
using SportStore.Entities;

namespace SportStore.DataBase
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(c => c.Classes)
                .WithMany(s => s.Students);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Lessons)
                .WithMany(l => l.Students);

            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Classes)
                .WithOne(c => c.Teacher);

            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Teacher)
                .WithMany(t => t.Lessons);
        }
    }
}