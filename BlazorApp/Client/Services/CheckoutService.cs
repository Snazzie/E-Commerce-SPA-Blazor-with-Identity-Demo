using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Client.Services
{
    public interface ICheckoutService
    {
        Task Checkout();
    }

    public class CheckoutService : ICheckoutService
    {
        private ICartService CartService { get; }

        public CheckoutService(ICartService cartService)
        {
            CartService = cartService;
        }

        public Task Checkout()
        {
            //do something
            return Task.CompletedTask;
        }
    }
}
