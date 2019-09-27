using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Shared
{
    public class CartItemModel
    {
        public string ProductSku { get; set; }

        public int Quantity { get; set; } = 0;
    }
}
