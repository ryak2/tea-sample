using System.ComponentModel.DataAnnotations;

namespace SchoolModel
{
    public partial class OnsiteCourse
    {
        public OnsiteCourse()
        {
            this.Location = "";
            this.Days = "";
        }

        [Key]
        public int CourseId { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Days { get; set; }
        public TimeSpan Time { get; set; }

        public virtual Course? Course { get; set; }
    }
}
