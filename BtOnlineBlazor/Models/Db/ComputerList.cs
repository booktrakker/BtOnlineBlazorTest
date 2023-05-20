using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class ComputerList
{
    public int ComputerId { get; set; }

    public string? ComputerKey { get; set; }

    public string AccountName { get; set; } = null!;

    public int AccountId { get; set; }

    public Guid UserId { get; set; }

    public string ComputerName { get; set; } = null!;

    public int? RateCode { get; set; }

    public string? WindowsVersion { get; set; }

    public int? AppId { get; set; }

    public int AppLevel { get; set; }

    public string Edition { get; set; } = null!;

    public decimal? Total { get; set; }
}
