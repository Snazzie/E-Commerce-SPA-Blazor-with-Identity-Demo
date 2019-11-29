using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Shared
{
    public class OrderFormModel
    {
        public BillingShippingDetails ShippingDetails { get; set; } = new BillingShippingDetails();
        public BillingShippingDetails BillingDetails { get; set; } = new BillingShippingDetails();
        public CartItemModel[] Cart { get; set; }

    }

    public class BillingShippingDetails
    {
        public string FullName { get; set; }
        public string FirstLine { get; set; }
        public string SecondLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string ContactNumber { get; set; }
    }
}
