namespace ef_core_console_app.Models;

public class Subject : Base<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
}