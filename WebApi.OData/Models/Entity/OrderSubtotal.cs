﻿using System;
using System.Collections.Generic;

namespace WebApi.OData.Models.Entity;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
