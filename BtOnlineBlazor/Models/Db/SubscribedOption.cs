using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class SubscribedOption
{
    public int SubscribedOptionId { get; set; }

    public int AccountId { get; set; }

    public int OptionId { get; set; }
}
