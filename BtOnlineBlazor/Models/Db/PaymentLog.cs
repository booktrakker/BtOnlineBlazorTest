using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class PaymentLog
{
    public int TransactionId { get; set; }

    public int AccountId { get; set; }

    public string? AmzTransId { get; set; }

    public string? AmzRequestId { get; set; }

    public string? CallerRequestId { get; set; }

    public decimal? ChargeAmount { get; set; }

    public string? StatusCode { get; set; }

    public string? StatusMessage { get; set; }

    public string? TransactionStatus { get; set; }

    public string? CallerReference { get; set; }

    public DateTime? TimeStamp { get; set; }

    public virtual Account Account { get; set; } = null!;
}
