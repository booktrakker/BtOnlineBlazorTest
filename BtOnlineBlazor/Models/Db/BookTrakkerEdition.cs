using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class BookTrakkerEdition
{
    public int AppLevelId { get; set; }

    public int AppLevel { get; set; }

    public string Edition { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Cost { get; set; }

    public decimal? MarginalCost { get; set; }
}
