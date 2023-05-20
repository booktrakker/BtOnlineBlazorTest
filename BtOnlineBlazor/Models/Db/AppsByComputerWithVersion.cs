using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class AppsByComputerWithVersion
{
    public string? ComputerName { get; set; }

    public string AppName { get; set; } = null!;

    public string? Edition { get; set; }

    public Guid UserId { get; set; }

    public string? Version { get; set; }

    public int ComputerId { get; set; }

    public decimal? Rate { get; set; }
}
