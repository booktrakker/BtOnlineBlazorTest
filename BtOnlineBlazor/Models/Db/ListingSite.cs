using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class ListingSite
{
    public int ListingSiteId { get; set; }

    public string SiteName { get; set; } = null!;

    public decimal Rate { get; set; }

    public string? SiteKey { get; set; }
}
