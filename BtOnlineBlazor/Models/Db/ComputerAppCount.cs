using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class ComputerAppCount
{
    public string ComputerName { get; set; } = null!;

    public int? NumApps { get; set; }

    public Guid UserId { get; set; }

    public int ComputerId { get; set; }
}
