namespace SchoolModel
{
    public class StudentGradeSummaryViewModel
    {
        public int StudentId {get; set;}
        public string? FirstName {get; set;}
        public string? LastName { get; set;}
        public decimal? Gpa {get; set;}

        public StudentGradeSummaryViewModel(int studentId, string firstName, string lastName, decimal? gpa)
        {
            this.StudentId = studentId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gpa = gpa;
        }

        public StudentGradeSummaryViewModel(Person person)
        {
            if (person.Discriminator != PersonDiscriminatorValues.Student)
            {
                throw new WrongPersonTypeException("Cannot initialize StudentGradeSummaryViewModel with a person who is not a student.");
            }

            this.StudentId = person.PersonId;
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
            this.Gpa = this.CalculateGpa(person.StudentGrades);
        }

        /// <summary>
        /// Calculates a gpa from a collection of StudentGrade entities.
        /// </summary>
        /// <param name="grades"></param>
        /// <returns>The average GPA</returns>
        private decimal? CalculateGpa(IEnumerable<StudentGrade> grades)
        {
            // (1) Only grades with a non-null Grade value count towards your GPA.
            // (2) Assumption: At least one valid grade is required to calculate a GPA.  If there are no non-null grades (or no grades period),
            // then your GPA is also null.
            // NOTE:  In a real world project, i would clarify the assumption with the product owner to make sure it is valid.

            IEnumerable<decimal> nonNullGrades = grades
              .Where(g => g.Grade != null)
              .Select(g => g.Grade)
              .OfType<decimal>();

            if (nonNullGrades.Any()) 
            {
                return nonNullGrades.Sum() / nonNullGrades.Count();
            }
            else
            {
                return null;
            }
        }
    }
}
