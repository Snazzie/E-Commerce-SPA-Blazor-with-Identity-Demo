using System.Linq;
using Blazor.Shared;
using Blazor.Server.Stores;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Blazor.Shared.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase, IProductsApi
    {
        private readonly IStore<ProductModel> m_ProductStore;

        public ProductsController(IStore<ProductModel> productStore)
        {
            m_ProductStore = productStore;
        }

        [HttpGet("[action]")]
        public Task<ProductModel[]> Products()
        {
            return Task.FromResult(m_ProductStore.GetAll().ToArray());
        }

        [HttpGet("[action]")]
        public Task<ProductModel[]> GetProducts([FromQuery]string[] skus)
        {
            return Task.FromResult(m_ProductStore.Get(skus).ToArray());
        }

        [HttpGet("[action]/{pageIndex}")]
        public Task<ProductModel[]> PaginatedProducts(int pageIndex)
        {
            pageIndex--;
            return Task.FromResult(m_ProductStore.GetAll(pageIndex, 20).ToArray());
        }

        [HttpGet("[action]")]
        public Task<int> TotalPages()
        {
            return Task.FromResult(m_ProductStore.TotalPages(20));
        }
    }
}
