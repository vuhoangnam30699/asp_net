using System;
using System.Collections.Generic;

namespace ConsoleAppTransaction.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Balance { get; set; }
}
