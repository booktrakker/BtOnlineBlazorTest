using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class ErrorLog
{
    public int ErrorId { get; set; }

    public string? AppName { get; set; }

    public string? Message { get; set; }

    public string? InnerException { get; set; }

    public string? StackTrace { get; set; }

    public string? Source { get; set; }

    public string? TargetSite { get; set; }

    public string? Comment { get; set; }

    public string? FileName { get; set; }

    public DateTime? TimeStamp { get; set; }
}
