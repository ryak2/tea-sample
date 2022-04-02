namespace SchoolContracts;

using SchoolModel;

public interface IStudentService
{
    IEnumerable<StudentGradeSummaryViewModel> GetStudentGradeSummaries();
}