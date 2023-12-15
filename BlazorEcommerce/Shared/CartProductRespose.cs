﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared
{
    public class CartProductRespose
    {
        public int ProductId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;
        public int ProductTypeId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
