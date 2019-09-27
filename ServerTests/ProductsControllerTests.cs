using Blazor.Server.Controllers;
using Blazor.Server.Stores;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace ServerTests
{
    public class ProductsControllerTests
    {
        ProductStore productStore;
        ProductsController productsController;

        [SetUp]
        public void Setup()
        {
            productStore = new ProductStore();
            productsController = new ProductsController(productStore);
        }

        [Test]
        public async Task ProductsReturnAllProductsAsync()
        {
            var products = await productsController.Products();

            products.Should().BeEquivalentTo(productStore.GetAll());
        }

    }
}