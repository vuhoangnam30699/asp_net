using System;
using System.Collections.Generic;

namespace WebAppMobile.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public int? Age { get; set; }

    public string? Position { get; set; }

    public string? Office { get; set; }

    public DateTime? HireDate { get; set; }

    public int? Salary { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
