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
        private readonly IApiUsageService apiUsageService = Substitute.For<IApiUsageService>();

        [SetUp]
        public void Setup()
        {
            cartService = new CartService(eventsService, apiUsageService);
        }

        [Test]
        public async Task UpdateCart_ShouldCallNotifyCartUpdated()
        {
            const string Sku = "123";

            await cartService.UpdateCart(Sku, 1);
            eventsService.Received(1).NotifyCartUpdated();

            await cartService.UpdateCart(Sku, 20);
            eventsService.Received(2).NotifyCartUpdated();

            await cartService.UpdateCart(Sku, 0);
            eventsService.Received(3).NotifyCartUpdated();
        }

        [Test]
        public async Task UpdateCart_ShouldUpdateCart()
        {
            const string Sku = "123";
            const int updateQuanity = 20;

            await cartService.UpdateCart(Sku, 1);
            cartService.Cart.Keys.Should().Contain(Sku);

            await cartService.UpdateCart(Sku, updateQuanity);
            cartService.Cart[Sku].Quantity.Should().Be(updateQuanity);

            await cartService.UpdateCart(Sku, 0);
            cartService.Cart.Keys.Should().NotContain(Sku);
        }

    }
}