using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Shared
{
    public class AddToCartModel
    {
        public string ProductSku { get; set; }
        public int Quantity { get; set; }
    }
    public class CartItemModel
    {
        public ProductModel Product { get; set; }
        public int Quantity { get; set; } = 0;
    }
}
