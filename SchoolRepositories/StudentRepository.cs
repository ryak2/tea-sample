namespace SchoolRepositories;

using SchoolContracts;
using SchoolModel;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// A repository for saving and loading student data.
/// 
/// This is named StudentRepository, not SchoolRepository, because I think it makes sense to break up the School entities into multiple repositories.
/// In the real world, this project would also contain other repositories: InstructorRepository, ClassRepository, etc.
/// </summary>
public class StudentRepository : IStudentRepository
{
    private readonly SchoolContext SchoolContext;

    public StudentRepository(SchoolContext schoolContext)
    {
        this.SchoolContext = schoolContext;
    }

    public IEnumerable<Person> GetStudentsWithGrades()
    {
        // In the 'traditional' way of managing DBContext, it would be instantiated here in a using block.  However, it is a best practice
        // in .net Core apps to instead use Dependency Injection to manage the lifetime of your DBContext and set the lifetime equal to the
        // duration of a single HTTP request.

        // See:  https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/#dbcontext-in-dependency-injection-for-aspnet-core

        return SchoolContext.People
            .Where(p => p.Discriminator == PersonDiscriminatorValues.Student) // I like to use enums when possible, but here we need to string compare for Linq2Sql
            .Include(p => p.StudentGrades)
            .OrderBy(p=> p.PersonId)
            .ToArray(); // We want to materialize the IEnumerable into objects here to isolate further Linq operations from Linq2Sql
    }

}
