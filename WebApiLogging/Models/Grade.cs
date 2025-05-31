using System;
using System.Collections.Generic;

namespace WebApiLogging.Models
{
    public partial class Grade
    {
        public Grade()
        {
            Students = new HashSet<Student>();
        }

        public int GradeId { get; set; }
        public string GradeName { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
    }
}
