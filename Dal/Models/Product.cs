using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Dscribe { get; set; }

    public int Size { get; set; }

    public double? Price { get; set; }

    public int IdPurveyor { get; set; }

    public int? Stock { get; set; }

    public virtual Purveyor IdPurveyorNavigation { get; set; } = null!;

    public virtual ICollection<ItemOreder> ItemOreders { get; set; } = new List<ItemOreder>();
}
