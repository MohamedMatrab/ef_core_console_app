namespace ef_core_console_app.Models;

public class Person : Base<int>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}