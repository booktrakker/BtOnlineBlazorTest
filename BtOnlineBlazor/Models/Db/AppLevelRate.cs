using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class AppLevelRate
{
    public string? Name { get; set; }

    public string? RateDescription { get; set; }

    public int AppId { get; set; }

    public int AppLevelId { get; set; }

    public int AppLevelVal { get; set; }

    public string Edition { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal? Cost { get; set; }

    public int? RateCode { get; set; }

    public decimal? MarginalCost { get; set; }
}
