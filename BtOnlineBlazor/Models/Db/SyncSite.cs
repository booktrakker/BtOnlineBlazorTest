using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class SyncSite
{
    public int SiteId { get; set; }

    public int AccountId { get; set; }

    public string SiteName { get; set; } = null!;

    public string SiteCode { get; set; } = null!;

    public int? AddressId { get; set; }

    public int SiteRateId { get; set; }
}
