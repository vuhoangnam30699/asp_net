using System;
using System.Collections.Generic;

namespace WebAppMobile.Models;

public partial class MobileDetail
{
    public int Slno { get; set; }

    public int? MobileId { get; set; }

    public string? Features { get; set; }

    public string? Model { get; set; }

    public string? Color { get; set; }

    public string? SimType { get; set; }

    public virtual Mobile? Mobile { get; set; }
}
