using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolModel
{
    public partial class OnlineCourse
    {
        public OnlineCourse()
        {
            Url = "";
        }

        public int CourseId { get; set; }

        [Required]
        public string Url { get; set; }

        public virtual Course? Course { get; set; }
    }
}
