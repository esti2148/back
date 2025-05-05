using System;
using System.Collections.Generic;

namespace Bl.Models;

public partial class BlPurveyor
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual List<BlProduct> Products { get; set; } = new List<BlProduct>();
}
