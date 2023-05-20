using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class VwAspnetProfile
{
    public Guid UserId { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public int? DataSize { get; set; }
}
