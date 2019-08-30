using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Shared;
using BlazorApp1.Server.Stores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
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

    }
}
