using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class SiteRate
{
    public int SiteRateId { get; set; }

    public string? SiteType { get; set; }

    public decimal? SiteRate1 { get; set; }
}
