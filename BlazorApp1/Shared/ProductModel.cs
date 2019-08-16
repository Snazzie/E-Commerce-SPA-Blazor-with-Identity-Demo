using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Shared
{
    public class ProductModel
    {
        public string Sku { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
