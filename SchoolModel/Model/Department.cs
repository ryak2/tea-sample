using System.ComponentModel.DataAnnotations;

namespace SchoolModel
{
    public partial class Department
    {
        public Department()
        {
            Courses = new HashSet<Course>();
            Name = "";
        }

        [Key]
        public int DepartmentId { get; set; }
        
        [Required]
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? Administrator { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
