using System;
using System.Collections.Generic;

namespace Bl.Models;

public partial class BlOrder
{
    public int OrderId { get; set; }

    public int InstituteId { get; set; }

    public int? ToatlSum { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? SupplyDate { get; set; }

    public  List<BlItemOreder> ItemOreders { get; set; } = new List<BlItemOreder>();
}
