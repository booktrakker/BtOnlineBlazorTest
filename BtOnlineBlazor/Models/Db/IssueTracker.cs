using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class IssueTracker
{
    public int IssueId { get; set; }

    public string Subject { get; set; } = null!;

    public string PageLink { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Date { get; set; }
}
