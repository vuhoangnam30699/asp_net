using System;
using System.Collections.Generic;

namespace WebAppMobile.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<UserRoleMapping> UserRoleMappings { get; set; } = new List<UserRoleMapping>();
}
