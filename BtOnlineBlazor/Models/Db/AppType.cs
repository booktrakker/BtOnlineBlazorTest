using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class AppType
{
    public int AppTypeId { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<AppItem> Apps { get; set; } = new List<AppItem>();
}
