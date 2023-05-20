﻿using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class ActiveAppsByComputer
{
    public int AppLevelId { get; set; }

    public int AppId { get; set; }

    public int? ComputerId { get; set; }

    public string AppName { get; set; } = null!;

    public string Edition { get; set; } = null!;

    public Guid? UserId { get; set; }

    public int AppLevel { get; set; }

    public Guid? AppKey { get; set; }

    public string? ActivationKey { get; set; }

    public int? Major { get; set; }

    public int? Minor { get; set; }

    public int? Build { get; set; }

    public string? Folder { get; set; }

    public string? FileName { get; set; }

    public string? InstallName { get; set; }

    public int? AppIndex { get; set; }
}
