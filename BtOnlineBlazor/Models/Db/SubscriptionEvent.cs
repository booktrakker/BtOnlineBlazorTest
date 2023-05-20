using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class SubscriptionEvent
{
    public int SubscriptionEventId { get; set; }

    public int AccountId { get; set; }

    public int? ComputerId { get; set; }

    public int SubEventTypeId { get; set; }

    public int? AppId { get; set; }

    public int? AppLevelId { get; set; }

    public DateTime Date { get; set; }

    public DateTime? TimeStamp { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Computer? Computer { get; set; }

    public virtual SubEventType SubEventType { get; set; } = null!;
}
