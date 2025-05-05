using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class ItemOreder
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int? Qty { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
