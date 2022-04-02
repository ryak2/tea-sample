using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolModel
{
    public partial class OfficeAssignment
    {
        public OfficeAssignment()
        {
            Location = "";
            Timestamp = DateTime.UtcNow;
        }

        public int InstructorId { get; set; }
        
        [Required]
        public string Location { get; set; }
        public DateTime Timestamp { get; set; }

        public virtual Person? Instructor { get; set; }
    }
}
