using System;
using System.Collections.Generic;

namespace Logging_and_Monitoring.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public string GradeName { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
