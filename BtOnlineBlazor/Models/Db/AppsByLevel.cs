using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class AppsByLevel
{
    public string AppName { get; set; } = null!;

    public string AppDescription { get; set; } = null!;

    public string Edition { get; set; } = null!;

    public decimal Cost { get; set; }

    public string Description { get; set; } = null!;

    public int AppLevelId { get; set; }

    public int AppLevel { get; set; }

    public int? Major { get; set; }

    public int? Minor { get; set; }

    public int? Build { get; set; }

    public string? Folder { get; set; }

    public string? FileName { get; set; }

    public int AppId { get; set; }
}
