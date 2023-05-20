using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class RemoteConnection
{
    public int ConnectionId { get; set; }

    public string RemoteId { get; set; } = null!;

    public int? AccountId { get; set; }

    public string? ComputerName { get; set; }

    public string? ContactName { get; set; }

    public string? Message { get; set; }

    public string? Phone { get; set; }

    public DateTime TimeStamp { get; set; }
}
