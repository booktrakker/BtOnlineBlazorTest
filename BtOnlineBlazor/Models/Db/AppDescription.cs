using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class AppDescription
{
    public int AppDescriptionId { get; set; }

    public int AppId { get; set; }

    public int Type { get; set; }

    public string Description { get; set; } = null!;

    public virtual AppItem App { get; set; } = null!;

    public virtual AppDescriptionType TypeNavigation { get; set; } = null!;
}
