using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class PaymentProcessor
{
    public int ProcessorId { get; set; }

    public string ProcessorName { get; set; } = null!;
}
