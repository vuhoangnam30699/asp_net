using System;
using System.Collections.Generic;

namespace Logging_and_Monitoring.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }
}
