using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class VwAspnetWebPartStateShared
{
    public Guid PathId { get; set; }

    public int? DataSize { get; set; }

    public DateTime LastUpdatedDate { get; set; }
}
