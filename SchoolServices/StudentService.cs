namespace SchoolServices;

using SchoolModel;
using SchoolContracts;

/// <summary>
/// A service for working with Student data.  Other services would also exist for non-student operations.
/// </summary>
public class StudentService : IStudentService
{

    private IStudentRepository StudentRepository {get; set;}

    public StudentService(IStudentRepository studentRepository)
    {
        this.StudentRepository = studentRepository;
    }

    public IEnumerable<StudentGradeSummaryViewModel> GetStudentGradeSummaries()
    {
        IEnumerable<Person> studentsWithGrades = this.StudentRepository.GetStudentsWithGrades();
        return studentsWithGrades.Select(student => new StudentGradeSummaryViewModel(student));
    }
}
