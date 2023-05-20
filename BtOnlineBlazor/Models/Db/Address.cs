using System;
using System.Collections.Generic;

namespace BTOnlineBlazor.Models.Db;

public partial class Address
{
    public int AddressId { get; set; }

    public int AccountId { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }

    public string? Address4 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public int? AddressType { get; set; }

    public virtual Account Account { get; set; } = null!;
}
