using System;
using System.Collections.Generic;

namespace WebApp6.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public string GradeName { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
