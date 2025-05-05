using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int InstituteId { get; set; }

    public int? ToatlSum { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? SupplyDate { get; set; }

    public virtual Customer Institute { get; set; } = null!;

    public virtual ICollection<ItemOreder> ItemOreders { get; set; } = new List<ItemOreder>();
}
