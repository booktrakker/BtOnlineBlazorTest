using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class SubscriptionRate
{
    public int RateId { get; set; }

    public int? RateCode { get; set; }

    public int? AppId { get; set; }

    public int? AppLevelId { get; set; }

    public decimal? Rate { get; set; }

    public virtual AppItem? App { get; set; }

    public virtual AppLevel? AppLevel { get; set; }

    public virtual RateCode? RateCodeNavigation { get; set; }
}
