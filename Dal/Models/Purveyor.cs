using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Purveyor
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
