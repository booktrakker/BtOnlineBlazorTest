using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class SubEventType
{
    public int SubEventTypeId { get; set; }

    public string Event { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual ICollection<SubscriptionEvent> SubscriptionEvents { get; set; } = new List<SubscriptionEvent>();
}
