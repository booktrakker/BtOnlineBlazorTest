using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class AppDescriptionType
{
    public int AppDescTypeId { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<AppDescription> AppDescriptions { get; set; } = new List<AppDescription>();
}
