using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class Computer
{
    public int ComputerId { get; set; }

    public Guid UserId { get; set; }

    public string ComputerName { get; set; } = null!;

    public string WinProdKey { get; set; } = null!;

    public string? Notes { get; set; }

    public string? WindowsVersion { get; set; }

    public string? ComputerKey { get; set; }

    public int? RateCode { get; set; }

    public int? SiteId { get; set; }

    public virtual ICollection<InstalledApp> InstalledApps { get; set; } = new List<InstalledApp>();

    public virtual RateCode? RateCodeNavigation { get; set; }

    public virtual ICollection<SubscriptionEvent> SubscriptionEvents { get; set; } = new List<SubscriptionEvent>();

    public virtual AspnetUser User { get; set; } = null!;
}
