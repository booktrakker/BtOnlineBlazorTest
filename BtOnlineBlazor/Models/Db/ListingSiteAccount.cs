using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class ListingSiteAccount
{
    public int ListingSiteId { get; set; }

    public int AccountId { get; set; }

    public string? Key1 { get; set; }

    public string? Key2 { get; set; }

    public string? SiteId { get; set; }

    public string? Site { get; set; }

    public string? RefreshToken { get; set; }
}
