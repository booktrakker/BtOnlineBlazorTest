using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class AmzTransactionLog
{
    public int TransactionId { get; set; }

    public int? AccountId { get; set; }

    public string? AuthRef { get; set; }

    public string? CapRef { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? AuthTime { get; set; }

    public DateTime? CapTime { get; set; }

    public DateTime? FinalTime { get; set; }

    public string? Status { get; set; }

    public string? ReasonCode { get; set; }

    public string? ReasonDescription { get; set; }

    public string? AmzAuthId { get; set; }

    public string? AmzCapId { get; set; }
}
