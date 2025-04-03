using Microsoft.EntityFrameworkCore;
using ef_core_console_app.Models;
using System.ComponentModel.DataAnnotations;
namespace ef_core_console_app.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<TeacherSubjectDto> V_Teacher_Subjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Class>()
            .ToTable("Classes")
            .HasKey(e => e.Id);
        modelBuilder.Entity<Class>().HasOne(e=>e.Teacher).WithMany().HasForeignKey(e=>e.TeacherId).IsRequired(true);

        modelBuilder.Entity<Subject>().ToTable("Subjects").HasKey(e=>e.Id);

        modelBuilder.Entity<Enrollment>().HasKey(e => e.Id);
        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId);
        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Class)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.ClassId)
            .OnDelete(DeleteBehavior.NoAction);


        modelBuilder.Entity<Person>().ToTable("People").HasKey(e => e.Id);
        modelBuilder.Entity<Person>().HasDiscriminator<string>("type")
            .HasValue<Teacher>("Teacher")
            .HasValue<Student>("Student");

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Seed Subjects
        modelBuilder.Entity<Subject>().HasData(
            new Subject { Id = 1, Name = "Mathematics", Description = "Study of numbers, quantities, and shapes" },
            new Subject { Id = 2, Name = "Science", Description = "Study of the physical and natural world" },
            new Subject { Id = 3, Name = "English", Description = "Study of language and literature" },
            new Subject { Id = 4, Name = "History", Description = "Study of past events" },
            new Subject { Id = 5, Name = "Computer Science", Description = "Study of computers and computational systems" }
        );


        // Seed Teachers
        modelBuilder.Entity<Teacher>().HasData(
            new Teacher { Id = 11, FirstName = "John", LastName = "Doe", SubjectId = 1, HireDate = new DateOnly(2018, 8, 15) },
            new Teacher { Id = 12, FirstName = "Jane", LastName = "Smith", SubjectId = 2, HireDate = new DateOnly(2019, 7, 10) },
            new Teacher { Id = 13, FirstName = "Emily", LastName = "Johnson", SubjectId = 3, HireDate = new DateOnly(2017, 9, 1) },
            new Teacher { Id = 14, FirstName = "Michael", LastName = "Brown", SubjectId = 4, HireDate = new DateOnly(2020, 1, 5) },
            new Teacher { Id = 15, FirstName = "Sarah", LastName = "Davis", SubjectId = 5, HireDate = new DateOnly(2018, 3, 20) }
        );

        // Seed Students
        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, FirstName = "Alice", LastName = "Johnson", StudentNumber = "S2023001" },
            new Student { Id = 2, FirstName = "Bob", LastName = "Smith", StudentNumber = "S2023002" },
            new Student { Id = 3, FirstName = "Charlie", LastName = "Williams", StudentNumber = "S2023003" },
            new Student { Id = 4, FirstName = "Daisy", LastName = "Jones", StudentNumber = "S2023004" },
            new Student { Id = 5, FirstName = "Ethan", LastName = "Garcia", StudentNumber = "S2023005" },
            new Student { Id = 6, FirstName = "Fiona", LastName = "Martinez", StudentNumber = "S2023006" },
            new Student { Id = 7, FirstName = "George", LastName = "Hernandez", StudentNumber = "S2023007" },
            new Student { Id = 8, FirstName = "Hannah", LastName = "Lopez", StudentNumber = "S2023008" },
            new Student { Id = 9, FirstName = "Isaac", LastName = "Wilson", StudentNumber = "S2023009" },
            new Student { Id = 10, FirstName = "Jack", LastName = "Taylor", StudentNumber = "S2023010" }
        );

        // Seed Classes
        modelBuilder.Entity<Class>().HasData(
            new Class { Id = 1, Name = "Math 101", Level = "Freshman", TeacherId = 1 },
            new Class { Id = 2, Name = "Biology Basics", Level = "Freshman", TeacherId = 2 },
            new Class { Id = 3, Name = "English Composition", Level = "Sophomore", TeacherId = 3 },
            new Class { Id = 4, Name = "World History", Level = "Junior", TeacherId = 4 },
            new Class { Id = 5, Name = "Programming Fundamentals", Level = "Freshman", TeacherId = 5 },
            new Class { Id = 6, Name = "Advanced Algebra", Level = "Senior", TeacherId = 1 },
            new Class { Id = 7, Name = "Chemistry", Level = "Sophomore", TeacherId = 2 },
            new Class { Id = 8, Name = "Literature Analysis", Level = "Junior", TeacherId = 3 }
        );

        // Seed Enrollments
        modelBuilder.Entity<Enrollment>().HasData(
            // Student 1 enrollments
            new Enrollment { Id = 1, StudentId = 1, ClassId = 1, EnrollmentDate = new DateOnly(2023, 9, 1) },
            new Enrollment { Id = 2, StudentId = 1, ClassId = 2, EnrollmentDate = new DateOnly(2023, 9, 1) },
            new Enrollment { Id = 3, StudentId = 1, ClassId = 5, EnrollmentDate = new DateOnly(2023, 9, 1) },

            // Student 2 enrollments
            new Enrollment { Id = 4, StudentId = 2, ClassId = 1, EnrollmentDate = new DateOnly(2023, 9, 2) },
            new Enrollment { Id = 5, StudentId = 2, ClassId = 3, EnrollmentDate = new DateOnly(2023, 9, 2) },

            // Student 3 enrollments
            new Enrollment { Id = 6, StudentId = 3, ClassId = 3, EnrollmentDate = new DateOnly(2023, 9, 1) },
            new Enrollment { Id = 7, StudentId = 3, ClassId = 4, EnrollmentDate = new DateOnly(2023, 9, 1) },

            // Student 4 enrollments
            new Enrollment { Id = 8, StudentId = 4, ClassId = 4, EnrollmentDate = new DateOnly(2023, 9, 3) },
            new Enrollment { Id = 9, StudentId = 4, ClassId = 5, EnrollmentDate = new DateOnly(2023, 9, 3) },

            // Student 5 enrollments
            new Enrollment { Id = 10, StudentId = 5, ClassId = 6, EnrollmentDate = new DateOnly(2023, 9, 2) },
            new Enrollment { Id = 11, StudentId = 5, ClassId = 7, EnrollmentDate = new DateOnly(2023, 9, 2) },

            // Student 6 enrollments
            new Enrollment { Id = 12, StudentId = 6, ClassId = 7, EnrollmentDate = new DateOnly(2023, 9, 1) },
            new Enrollment { Id = 13, StudentId = 6, ClassId = 8, EnrollmentDate = new DateOnly(2023, 9, 1) },

            // Student 7 enrollments
            new Enrollment { Id = 14, StudentId = 7, ClassId = 5, EnrollmentDate = new DateOnly(2023, 9, 2) },
            new Enrollment { Id = 15, StudentId = 7, ClassId = 6, EnrollmentDate = new DateOnly(2023, 9, 2) },

            // Student 8 enrollments
            new Enrollment { Id = 16, StudentId = 8, ClassId = 2, EnrollmentDate = new DateOnly(2023, 9, 3) },
            new Enrollment { Id = 17, StudentId = 8, ClassId = 3, EnrollmentDate = new DateOnly(2023, 9, 3) },

            // Student 9 enrollments
            new Enrollment { Id = 18, StudentId = 9, ClassId = 1, EnrollmentDate = new DateOnly(2023, 9, 1) },
            new Enrollment { Id = 19, StudentId = 9, ClassId = 8, EnrollmentDate = new DateOnly(2023, 9, 1) },

            // Student 10 enrollments
            new Enrollment { Id = 20, StudentId = 10, ClassId = 4, EnrollmentDate = new DateOnly(2023, 9, 2) },
            new Enrollment { Id = 21, StudentId = 10, ClassId = 5, EnrollmentDate = new DateOnly(2023, 9, 2) }
        );
    }

}

public class TeacherSubjectDto
{
    [Key]
    public int? Id { get; set; }
    public int TeacherId { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateOnly HireDate { get; set; }
    public int SubjectId { get; set; }
    public string SubjectName { get; set; } = default!;
    public string SubjectDescription { get; set; } = default!;
}