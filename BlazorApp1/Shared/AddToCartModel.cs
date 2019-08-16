using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Shared
{
    public class AddToCartModel
    {
        public string productSku { get; set; }
        public int quantity { get; set; }
    }
    public class CartItemModel
    {
        public ProductModel Product { get; set; }
        public int Quanitity { get; set; } = 0;
    }
}
