using Microsoft.AspNetCore.Mvc;
using SchoolModel;
using SchoolContracts;

namespace SchoolApi.Controllers;

/// <summary>
/// A RESTful controller for Student data
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly ILogger<StudentsController> Logger;
    private readonly IStudentService StudentService;

    /// <summary>
    /// Constructor with dependency injection
    /// </summary>
    /// <param name="logger">A logger</param>
    /// <param name="studentService">Service for retrieving student data</param>
    public StudentsController(ILogger<StudentsController> logger, IStudentService studentService)
    {
        Logger = logger;
        StudentService = studentService;
    }

    /// <summary>
    /// Gets all students with their GPA information.
    /// </summary>
    /// <returns>A collection of StudentGradeSummaryViewModels.</returns>
    [HttpGet(Name = "GetAllStudents")]
    public IEnumerable<StudentGradeSummaryViewModel> GetAllStudents()
    {
        return StudentService.GetStudentGradeSummaries();
    }
}
