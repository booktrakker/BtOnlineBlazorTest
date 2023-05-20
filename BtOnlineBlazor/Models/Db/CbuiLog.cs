using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class CbuiLog
{
    public int CbuiId { get; set; }

    public int? AccountId { get; set; }

    public string? CallerReference { get; set; }

    public string? TokenId { get; set; }

    public DateTime? TimeStamp { get; set; }

    public string? Status { get; set; }

    public decimal? Amount { get; set; }

    public string? CancelReference { get; set; }

    public DateTime? CancelTime { get; set; }

    public virtual Account? Account { get; set; }
}
