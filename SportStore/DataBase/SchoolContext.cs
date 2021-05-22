using Microsoft.EntityFrameworkCore;
using SportStore.Entities;

namespace SportStore.DataBase
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(c => c.Classes)
                .WithMany(s => s.Students);

            modelBuilder.Entity<Teacher>()
                .HasMany(c => c.Classes)
                .WithOne(t => t.Teacher);
        }
    }
}
