namespace ef_core_console_app.Models;

public class Class : Base<int>
{
    public string Name { get; set; } = default!;
    public string Level { get; set; } = default!;
    public int TeacherId { get; set; }
    public virtual Teacher Teacher { get; set; } = default!;
    public ICollection<Enrollment> Enrollments { get; set; } = default!;
}