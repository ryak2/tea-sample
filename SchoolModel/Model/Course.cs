using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolModel
{
    public partial class Course
    {
        public Course()
        {
            StudentGrades = new HashSet<StudentGrade>();
            People = new HashSet<Person>();
            Title = "";
        }

        public int CourseId { get; set; }

        [Required]
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
        public virtual OnlineCourse? OnlineCourse { get; set; }
        public virtual OnsiteCourse? OnsiteCourse { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
