using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class AppsByComputer
{
    public int AppId { get; set; }

    public int? ComputerId { get; set; }

    public string AppName { get; set; } = null!;

    public int Type { get; set; }

    public string Description { get; set; } = null!;

    public string Edition { get; set; } = null!;

    public decimal Cost { get; set; }

    public int AppLevel { get; set; }

    public Guid? AppKey { get; set; }

    public string? ActivationKey { get; set; }

    public int? AppLevelId { get; set; }

    public Guid? UserId { get; set; }

    public string? InstallName { get; set; }

    public string? FileName { get; set; }

    public string? Folder { get; set; }

    public int? Build { get; set; }

    public int? Minor { get; set; }

    public int? Major { get; set; }

    public int? AppIndex { get; set; }

    public int? TrialType { get; set; }

    public DateTime? ExpireDate { get; set; }

    public bool? TrialExpired { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public bool? Enabled { get; set; }
}
