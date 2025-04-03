namespace ef_core_console_app.Models;

public class Student : Person
{
    public string StudentNumber { get; set; } = default!;
    public ICollection<Enrollment> Enrollments { get; set; } = default!;
}