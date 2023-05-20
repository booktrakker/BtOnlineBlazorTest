using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class Message
{
    public int MessageId { get; set; }

    public string? Subject { get; set; }

    public string? Message1 { get; set; }

    public DateTime? Date { get; set; }
}
