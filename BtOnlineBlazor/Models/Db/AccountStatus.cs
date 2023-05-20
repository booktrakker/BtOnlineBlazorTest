using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class AccountStatus
{
    public int StatusId { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
