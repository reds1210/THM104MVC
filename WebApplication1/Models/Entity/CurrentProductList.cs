﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models.Entity;

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}
