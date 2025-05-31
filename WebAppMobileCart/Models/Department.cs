using System;
using System.Collections.Generic;

namespace WebAppMobile.Models;

public partial class Department
{
    public int DeptId { get; set; }

    public string? DepartmentName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
