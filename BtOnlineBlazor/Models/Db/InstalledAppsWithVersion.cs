using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class InstalledAppsWithVersion
{
    public string? ContactName { get; set; }

    public Guid? UserId { get; set; }

    public string AppName { get; set; } = null!;

    public string? Version { get; set; }
}
