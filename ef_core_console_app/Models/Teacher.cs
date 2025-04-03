namespace ef_core_console_app.Models;

public class Teacher : Person
{
    public DateOnly HireDate { get; set; }
    public int SubjectId { get; set; }
    public virtual Subject Subject { get; set; } = default!;
}