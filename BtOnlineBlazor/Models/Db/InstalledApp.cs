using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class InstalledApp
{
    public int InstalledAppId { get; set; }

    public Guid? UserId { get; set; }

    public int? ComputerId { get; set; }

    public int? AppId { get; set; }

    public int? AppLevelId { get; set; }

    public string? ActivationKey { get; set; }

    public DateTime? ExpireDate { get; set; }

    public bool? TrialExpired { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public string? Version { get; set; }

    public virtual AppItem? App { get; set; }

    public virtual AppLevel? AppLevel { get; set; }

    public virtual Computer? Computer { get; set; }
}
