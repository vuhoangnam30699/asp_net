﻿using System;
using System.Collections.Generic;

namespace WebAppMobile.Models;

public partial class UserRoleMapping
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }

    public virtual User? User { get; set; }
}
