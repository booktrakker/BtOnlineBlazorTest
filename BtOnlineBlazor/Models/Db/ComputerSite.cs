using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class ComputerSite
{
    public Guid UserId { get; set; }

    public string ComputerName { get; set; } = null!;

    public string SiteName { get; set; } = null!;

    public string? SiteType { get; set; }

    public decimal? SiteRate { get; set; }
}
