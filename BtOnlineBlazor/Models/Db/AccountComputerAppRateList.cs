using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class AccountComputerAppRateList
{
    public string ComputerName { get; set; } = null!;

    public string AppName { get; set; } = null!;

    public string Edition { get; set; } = null!;

    public decimal? Rate { get; set; }

    public Guid UserId { get; set; }

    public string? Version { get; set; }

    public string CurrentVersion { get; set; } = null!;
}
