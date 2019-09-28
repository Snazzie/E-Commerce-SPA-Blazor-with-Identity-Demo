using Blazor.Client.Services;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;

namespace ClientTests
{
    public class CartServiceTests
    {
        private CartService cartService;
        private readonly IEventService eventsService = Substitute.For<IEventService>();
        private readonly ISessionStorageService sessionStorageService = Substitute.For<ISessionStorageService>();
        private readonly IApiUsageService apiUsageService = Substitute.For<IApiUsageService>();

        [SetUp]
        public void Setup()
        {
            cartService = new CartService(eventsService, sessionStorageService, apiUsageService);
        }

        [Test]
        public async Task UpdateCart_UpdateAndRemove_ShouldCallNotifyCartUpdated()
        {
            const string Sku = "123";

            await cartService.UpdateCart(Sku, 1);
            eventsService.Received(1).NotifyCartUpdated();

            await cartService.UpdateCart(Sku, 0);
            eventsService.Received(2).NotifyCartUpdated();
        }

        [Test]
        public async Task UpdateCart_UpdateAndRemove_ShouldUpdateCart()
        {
            const string Sku = "123";

            await cartService.UpdateCart(Sku, 1);
            cartService.Cart.Keys.Should().Contain(Sku);

            await cartService.UpdateCart(Sku, 0);
            cartService.Cart.Keys.Should().NotContain(Sku);
        }

    }
}