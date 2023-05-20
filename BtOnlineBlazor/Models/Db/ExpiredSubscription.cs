using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class ExpiredSubscription
{
    public int AccountId { get; set; }

    public int? PaymentCount { get; set; }

    public string? ContactName { get; set; }

    public Guid UserId { get; set; }

    public int? SubscriptionTerm { get; set; }
}
