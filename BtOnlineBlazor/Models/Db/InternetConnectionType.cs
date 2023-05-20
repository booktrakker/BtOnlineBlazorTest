using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class InternetConnectionType
{
    public int ConnectionTypeId { get; set; }

    public string ConnectionType { get; set; } = null!;
}
