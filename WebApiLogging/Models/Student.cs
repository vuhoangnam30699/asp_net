using System;
using System.Collections.Generic;

namespace WebApiLogging.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int GradeId { get; set; }

        public virtual Grade Grade { get; set; } = null!;
    }
}
