using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class Option
{
    public int OptionId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Rate { get; set; }
}
