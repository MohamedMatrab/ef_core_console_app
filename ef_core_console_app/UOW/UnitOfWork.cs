using ef_core_console_app.Data;
using ef_core_console_app.Models;
using ef_core_console_app.Repositories;

namespace ef_core_console_app.UOW;

public class UnitOfWork(AppDbContext dbContext)
{
    public AppDbContext DbContext { get; set; } = dbContext;
    public IRepository<Class, int> ClassRepository { get; set; } = new Repository<Class, int>(dbContext);
    public IRepository<Enrollment, int> EnrollmentRepository { get; set; } = new Repository<Enrollment, int>(dbContext);
    public IRepository<Person, int> PeopleRepository { get; set; } = new Repository<Person, int>(dbContext);
    public IRepository<Student, int> StudentRepository { get; set; } = new Repository<Student, int>(dbContext);
    public IRepository<Subject, int> SubjectRepository { get; set; } = new Repository<Subject,int>(dbContext);
    public IRepository<Teacher, int> TeacherRepository { get; set; } = new Repository<Teacher, int>(dbContext);

    public IReadOnlyRepository<Class, int> ClassRORepository { get; set; } = new ReadOnlyRepository<Class, int>(dbContext);
    public IReadOnlyRepository<Enrollment, int> EnrollmentRORepository { get; set; } = new ReadOnlyRepository<Enrollment, int>(dbContext);
    public IReadOnlyRepository<Person, int> PeopleRORepository { get; set; } = new ReadOnlyRepository<Person, int>(dbContext);
    public IReadOnlyRepository<Student, int> StudentRORepository { get; set; } = new ReadOnlyRepository<Student, int>(dbContext);
    public IReadOnlyRepository<Subject, int> SubjectRORepository { get; set; } = new ReadOnlyRepository<Subject, int>(dbContext);
    public IReadOnlyRepository<Teacher, int> TeacherRORepository { get; set; } = new ReadOnlyRepository<Teacher, int>(dbContext);
}