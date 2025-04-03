using ef_core_console_app.Data;
using ef_core_console_app.Models;
using ef_core_console_app.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleInjector;
using SimpleInjector.Lifestyles;

var container = new Container();
container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
optionsBuilder.UseSqlServer(configuration.GetConnectionString("Database"));

container.Register(() => optionsBuilder.Options, Lifestyle.Singleton);
container.Register<AppDbContext>(Lifestyle.Scoped);
container.Register<UnitOfWork>(Lifestyle.Scoped);

container.Verify();

using (AsyncScopedLifestyle.BeginScope(container))
{
    var unitOfWork = container.GetInstance<UnitOfWork>();
    try
    {
        string studentNumber = "S2023001";
        var students2 = unitOfWork.DbContext.Set<Student>()
                     .FromSqlRaw("EXEC [GetStudentByStudentNumber] @p0", studentNumber)
                     .AsEnumerable();

        var student = students2.FirstOrDefault();

        if (student != null) Console.WriteLine(student?.FirstName);
        else Console.WriteLine("No student found.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    try
    {
        var teacherSubjects = await unitOfWork.DbContext.V_Teacher_Subjects.ToListAsync();

        foreach (var teacherSubject in teacherSubjects)
        {
            Console.WriteLine($"Teacher: {teacherSubject.FirstName} {teacherSubject.LastName} - Subject: {teacherSubject.SubjectName}");
        }
    }catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}