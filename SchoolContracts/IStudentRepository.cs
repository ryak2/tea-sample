namespace SchoolContracts;

using SchoolModel;

public interface IStudentRepository
{
    public IEnumerable<Person> GetStudentsWithGrades();
}
