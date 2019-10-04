using Blazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Client.Services
{
    public interface ICheckoutService
    {
        Task Checkout();
        OrderFormModel OrderForm { get; set; }
    }

    public class CheckoutService : ICheckoutService
    {
        private ICartService CartService { get; }
        public OrderFormModel OrderForm { get; set; }

        public CheckoutService(ICartService cartService)
        {
            CartService = cartService;
            OrderForm = new OrderFormModel();
        }

        public Task Checkout()
        {
            //do something
            return Task.CompletedTask;
        }
    }
}
