using System.ComponentModel.DataAnnotations;

namespace SchoolModel
{
    public partial class Person
    {
        public Person()
        {
            StudentGrades = new HashSet<StudentGrade>();
            Courses = new HashSet<Course>();

            FirstName = "";
            LastName = "";
            Discriminator = PersonDiscriminatorValues.Student;
        }

        [Key]
        public int PersonId { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public DateTime? HireDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }

        [Required]
        public string Discriminator { get; set; }

        public virtual OfficeAssignment? OfficeAssignment { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
