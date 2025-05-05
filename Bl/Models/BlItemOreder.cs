using System;
using System.Collections.Generic;

namespace Bl.Models;

public partial class BlItemOreder
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Dscribe { get; set; }
    public int Size { get; set; }
    public int? Qty { get; set; }
    public double? TempSum { get; set; }


}
