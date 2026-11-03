using Dalilacademy.Core.Entities;
using Dalilacademy_.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy.infra.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
         public DbSet<Course>Coures=>Set<Course>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Instructor> Instructors => Set<Instructor>();

        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSeeding((context, _) =>
            {
                if (!context.Set<Student>().Any())
                {
                    context.Set<Student>().AddRange(
                        new Student { fullname = "Ali Hassan", email = "ali@example.com" },
                        new Student { fullname = "Sara Omar", email = "sara@example.com" }
                    );
                    context.SaveChanges();
                }

                if (context.Set<Instructor>().Any()) return;
                var ahmad = new Instructor { fullname = "Ahmad Ali" };
                var raghad = new Instructor { fullname = "raghad Ali" };
                context.Set<Course>().AddRange(
                    new Course { title = "C# Fundemantals", price = 50, instructor = ahmad },
                    new Course { title = "ASP.NET Core Web API", price = 120, instructor = raghad },
                    new Course { title = "DataBase `", price = 120, instructor = raghad }
                     );
                context.SaveChanges();
            });
        }

    }
}
