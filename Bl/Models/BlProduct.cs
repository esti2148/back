using System;
using System.Collections.Generic;

namespace Bl.Models;

public partial class BlProduct
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Dscribe { get; set; }

    public int Size { get; set; }

    public double? Price { get; set; }

    public int IdPurveyor { get; set; }
    public string NamePurveyor { get; set; }
    public int? Stock { get; set; }

    public virtual List<BlItemOreder> ItemOreders { get; set; } = new List<BlItemOreder>();
}
