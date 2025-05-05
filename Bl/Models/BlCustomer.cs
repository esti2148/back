using System;
using System.Collections.Generic;

namespace Bl.Models;

public partial class BlCustomer
{
    public int InstituteId { get; set; }

    public string? InstituteName { get; set; }

    public string? Address { get; set; }

    public string? SellingPlace { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public decimal? OverPluseDebt { get; set; }

    public virtual List<BlOrder> Orders { get; set; } = new List<BlOrder>();
}
