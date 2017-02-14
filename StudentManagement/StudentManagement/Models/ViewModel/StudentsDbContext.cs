using System.Data.Entity;

namespace StudentManagement.Models.ViewModel
{
    public class StudentsDbContext : DbContext
    {
        public StudentsDbContext() : base("name=StudentsDB")
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().Property(s => s.FirstName)
               .HasMaxLength(225)
               .IsRequired();
            modelBuilder.Entity<Student>().Property(s => s.FirstName)
                           .HasMaxLength(225)
                           .IsRequired();
            modelBuilder.Entity<Student>().Property(s => s.LastName)
                .HasMaxLength(225)
                .IsRequired();
            modelBuilder.Entity<Student>().Property(s => s.DateOfBirth)
                .IsRequired();
            modelBuilder.Entity<Student>().Property(s => s.Gender)
                .IsRequired();
            modelBuilder.Entity<Student>().Property(s => s.Address)
                .HasMaxLength(2000)
                .IsRequired();
            modelBuilder.Entity<Student>().Property(s => s.PhoneNumber).
                HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Student>().Property(s => s.EnrollmentDate)
                .IsRequired();

            modelBuilder.Entity<Course>().Property(c => c.CourseName)
                .IsRequired();



        }

    }
}