using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class RateCode
{
    public int RateCode1 { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Computer> Computers { get; set; } = new List<Computer>();

    public virtual ICollection<SubscriptionRate> SubscriptionRates { get; set; } = new List<SubscriptionRate>();
}
