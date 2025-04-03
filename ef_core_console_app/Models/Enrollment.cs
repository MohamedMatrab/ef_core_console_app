namespace ef_core_console_app.Models;

public class Enrollment : Base<int>
{
    public int StudentId { get; set; }
    public int ClassId { get; set; }
    public DateOnly EnrollmentDate { get; set; }

    public virtual Student Student { get; set; } = default!;
    public virtual Class Class { get; set; } = default!;
}