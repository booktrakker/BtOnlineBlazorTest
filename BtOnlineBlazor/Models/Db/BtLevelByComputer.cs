using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class BtLevelByComputer
{
    public int AppId { get; set; }

    public int? ComputerId { get; set; }

    public int AppLevel { get; set; }

    public int? AppLevelId { get; set; }
}
