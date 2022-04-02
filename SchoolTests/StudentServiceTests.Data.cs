namespace SchoolTests;

using System.Collections.Generic;
using SchoolModel;

public partial class StudentServiceTests
{
    private Person GetFakeStudent()
    {
        return new Person()
        {
            Discriminator = PersonDiscriminatorValues.Student,
            PersonId = 1,
            FirstName = "john",
            LastName = "smith",
            StudentGrades = new StudentGrade[3] 
            { 
                new StudentGrade() 
                {
                    Grade = 2

                },
                new StudentGrade() 
                {
                    Grade = 3

                },
                new StudentGrade() 
                {
                    Grade = null
                }
            }
        };
    }

    private IEnumerable<Person> GetFakeStudentList()
    {
        return new Person[1]
        {
            GetFakeStudent()
        };
    }
}