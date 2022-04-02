namespace SchoolTests;

using SchoolContracts;
using Moq;

public partial class StudentServiceTests
{
    private IStudentRepository GetStudentRepository()
    {
        var mock = new Mock<IStudentRepository>();  
        mock.Setup(p => p.GetStudentsWithGrades()).Returns(GetFakeStudentList());
        return mock.Object;
    }
}