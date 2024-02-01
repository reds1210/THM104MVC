using System;
using System.Collections.Generic;

namespace WebApi.Models.Entity;

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}
