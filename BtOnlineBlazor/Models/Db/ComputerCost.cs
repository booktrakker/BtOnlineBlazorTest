using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class ComputerCost
{
    public Guid UserId { get; set; }

    public int? AppId { get; set; }

    public int? AppLevelId { get; set; }

    public string Edition { get; set; } = null!;

    public int? RateCode { get; set; }

    public decimal? Rate { get; set; }

    public int AppLevel { get; set; }

    public string? ComputerKey { get; set; }

    public int ComputerId { get; set; }

    public string AccountName { get; set; } = null!;

    public int AccountId { get; set; }

    public string ComputerName { get; set; } = null!;

    public string? WindowsVersion { get; set; }

    public int? SiteId { get; set; }
}
