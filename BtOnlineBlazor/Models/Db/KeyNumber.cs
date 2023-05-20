using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class KeyNumber
{
    public string KeyNumberVal { get; set; } = null!;

    public Guid? UserId { get; set; }

    public string? KeyType { get; set; }

    public DateTime? DateStamp { get; set; }
}
