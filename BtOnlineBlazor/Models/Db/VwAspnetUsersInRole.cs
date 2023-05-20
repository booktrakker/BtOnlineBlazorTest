using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class VwAspnetUsersInRole
{
    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }
}
