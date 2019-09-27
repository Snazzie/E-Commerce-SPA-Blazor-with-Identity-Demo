using Blazor.Client.Services;
using NSubstitute;
using NUnit.Framework;

namespace ClientTests
{
    public class CartServiceTests
    {
        private CartService cartService;
        private readonly IEventService eventsService = Substitute.For<IEventService>();

        [SetUp]
        public void Setup()
        {
            cartService = new CartService(eventsService);
        }

        [Test]
        public void AddToCartAndRemoveFromCartCallsNotifyCartUpdated()
        {
            const string Sku = "123";

            cartService.AddToCart(Sku, new Blazor.Shared.CartItemModel());
            eventsService.Received(1).NotifyCartUpdated();

            cartService.RemoveFromCart(Sku);
            eventsService.Received(2).NotifyCartUpdated();
        }

    }
}