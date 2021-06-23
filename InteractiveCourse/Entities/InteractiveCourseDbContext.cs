using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InteractiveCourse.Entities
{
    public class InteractiveCourseDbContext : DbContext
    {
        private string _connectionString =
            "Server=(localDb)\\mssqllocaldb;Database=InteractiveCourseDb;Trusted_Connection=True;";

        public DbSet<Course> Courses { get; set; }
        public DbSet<Slide> Slides { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(x => x.Name)
                .IsRequired();

            modelBuilder.Entity<Slide>()
                .HasKey(x => new { x.Nr, x.CourseId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
