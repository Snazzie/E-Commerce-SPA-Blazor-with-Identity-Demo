using System.Collections.Generic;
using System.Linq;
using Blazor.Shared;
using Blazor.Server.Stores;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase, IProductsApi
    {
        private readonly ProductStore m_ProductStore;

        public ProductsController(ProductStore productStore)
        {
            m_ProductStore = productStore;
        }

        [HttpGet("[action]")]
        public IEnumerable<ProductModel> Products()
        {
            return m_ProductStore.GetAll();
        }

        [HttpGet("[action]")]
        public Task<ProductModel[]> GetProducts([FromQuery]string[] skus)
        {
            var products = m_ProductStore.GetAll();
            var toReturn = new List<ProductModel>();
            var skuList = skus.ToList();
            skuList.ForEach(s =>
            {
                var product = products.Single(p => p.Sku == s);
                toReturn.Add(product);
            }
            );
            return Task.FromResult(toReturn.ToArray());
        }


        [HttpGet("[action]/{pageIndex}")]
        public Task<ProductModel[]> PaginatedProductsAsync(int pageIndex)
        {
            pageIndex--;
            return Task.FromResult(m_ProductStore.GetAll(pageIndex, 20).ToArray());
        }

        [HttpGet("[action]")]
        public int TotalPages()
        {
            return m_ProductStore.TotalPages(20);
        }
    }
}
