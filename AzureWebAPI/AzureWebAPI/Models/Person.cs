using System;
using System.Collections.Generic;

namespace AzureWebAPI.Models;

public partial class Person
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }
}
