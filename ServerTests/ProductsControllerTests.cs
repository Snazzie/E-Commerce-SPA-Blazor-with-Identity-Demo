using Blazor.Server.Controllers;
using BlazorApp1.Server.Stores;
using FluentAssertions;
using NUnit.Framework;

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
        public void ProductsReturnAllProducts()
        {
            var products = productsController.Products();

            products.Should().BeEquivalentTo(productStore.GetAll());
        }
    }
}