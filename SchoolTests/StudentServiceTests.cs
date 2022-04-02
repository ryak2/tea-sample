using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using SchoolModel;
using SchoolServices;

namespace SchoolTests;

[TestClass]
public partial class StudentServiceTests
{

    [TestMethod]
    public void SchoolService_GetStudentsWithGrades_ReturnsData()
    {
        var studentRepository = GetStudentRepository();
        var service = new StudentService(studentRepository);

        var studentsWithGrades = service.GetStudentGradeSummaries();

        Assert.IsTrue(studentsWithGrades.Any(), "At least one student should be returned.");
    }

    [TestMethod]
    public void StudentGradeSummaryViewModel_CalculatesGpaProperly()
    {
        var person = this.GetFakeStudent();

        var viewModel = new StudentGradeSummaryViewModel(person);

        Assert.AreEqual(viewModel.Gpa, (decimal)2.5);
    }

    [TestMethod]
    [ExpectedException(typeof(WrongPersonTypeException))]
    public void StudentGradeSummaryViewModel_ThrowsIfNotStudent()
    {
        var person = this.GetFakeStudent();
        person.Discriminator = PersonDiscriminatorValues.Instructor;

        var viewModel = new StudentGradeSummaryViewModel(person);

    }
}