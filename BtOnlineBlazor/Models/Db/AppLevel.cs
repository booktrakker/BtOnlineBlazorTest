using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class AppLevel
{
    public int AppLevelId { get; set; }

    public int AppId { get; set; }

    public int AppLevel1 { get; set; }

    public string Edition { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Cost { get; set; }

    public decimal? MarginalCost { get; set; }

    public virtual AppItem App { get; set; } = null!;

    public virtual ICollection<InstalledApp> InstalledApps { get; set; } = new List<InstalledApp>();

    public virtual ICollection<SubscriptionRate> SubscriptionRates { get; set; } = new List<SubscriptionRate>();
}
