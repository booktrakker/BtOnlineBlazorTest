using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class Account
{
    public int AccountId { get; set; }

    public string AccountName { get; set; } = null!;

    public Guid UserId { get; set; }

    public string? ContactName { get; set; }

    public string? Notes { get; set; }

    public int Status { get; set; }

    public string? BusinessName { get; set; }

    public string? Phone { get; set; }

    public string? Cell { get; set; }

    public DateTime? RenewDate { get; set; }

    public bool? Active { get; set; }

    public int? PaymentMethod { get; set; }

    public DateTime? RateExpire { get; set; }

    public int? NextRate { get; set; }

    public bool? Ioba { get; set; }

    public bool? Abaa { get; set; }

    public bool? Colorado { get; set; }

    public int? UserType { get; set; }

    public DateTime? BtpurchaseDate { get; set; }

    public int? RateCodeLevel { get; set; }

    public string? NetworkServerKey { get; set; }

    public string? AmzCallerReference { get; set; }

    public string? PrimaryComputerKey { get; set; }

    public decimal? ChargeAmount { get; set; }

    public int? ChargeStatus { get; set; }

    public int? AmzReferenceIndex { get; set; }

    public int? SubscriptionTerm { get; set; }

    public int ImageIt { get; set; }

    public int? PaymentProcessorId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<CbuiLog> CbuiLogs { get; set; } = new List<CbuiLog>();

    public virtual ICollection<PaymentLog> PaymentLogs { get; set; } = new List<PaymentLog>();

    public virtual AccountStatus StatusNavigation { get; set; } = null!;

    public virtual ICollection<SubscriptionEvent> SubscriptionEvents { get; set; } = new List<SubscriptionEvent>();

    public virtual AspnetUser User { get; set; } = null!;
}
