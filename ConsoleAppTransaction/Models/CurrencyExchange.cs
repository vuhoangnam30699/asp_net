using System;
using System.Collections.Generic;

namespace ConsoleAppTransaction.Models;

public partial class CurrencyExchange
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public double Currency { get; set; }
}
