using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class MessageLog
{
    public int MessageId { get; set; }

    public string? Message { get; set; }

    public string? Application { get; set; }

    public DateTime? TimeStamp { get; set; }
}
