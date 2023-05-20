using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BTOnlineBlazor.Models.Db;

[Table("Apps")]
public partial class AppItem
{
    [Key]
    [Column("App_ID")]
    public int AppId { get; set; }

    public int? AppIndex { get; set; }

    [StringLength(50)]
    public string AppName { get; set; } = null!;

    [StringLength(255)]
    public string Description { get; set; } = null!;

    /// <summary>
    /// 0 for AppManger, 1 for BookTrakker, 2 for Discrete Level App, 3 for BitMap Level App
    /// </summary>
    public int Type { get; set; }

    [Column(TypeName = "money")]
    public decimal Cost { get; set; }

    public int Policy { get; set; }

    public Guid? AppKey { get; set; }

    public int? Major { get; set; }

    public int? Minor { get; set; }

    public int? Build { get; set; }

    [StringLength(100)]
    public string? Folder { get; set; }

    [StringLength(50)]
    public string? FileName { get; set; }

    [StringLength(100)]
    public string? InstallName { get; set; }

    public int? TrialType { get; set; }

    public bool? Enabled { get; set; }

    [InverseProperty("App")]
    public virtual ICollection<AppDescription> AppDescriptions { get; } = new List<AppDescription>();

    [InverseProperty("App")]
    public virtual ICollection<AppLevel> AppLevels { get; } = new List<AppLevel>();

    [InverseProperty("App")]
    public virtual ICollection<InstalledApp> InstalledApps { get; } = new List<InstalledApp>();

    [InverseProperty("App")]
    public virtual ICollection<SubscriptionRate> SubscriptionRates { get; } = new List<SubscriptionRate>();

    [ForeignKey("Type")]
    [InverseProperty("Apps")]
    public virtual AppType TypeNavigation { get; set; } = null!;
}
