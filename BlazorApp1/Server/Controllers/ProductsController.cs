using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static ProductModel[] ProductList = new[]
   {
            new ProductModel{Sku="1", Title="Spoon", Price= 2.0},
            new ProductModel{Sku="2", Title="Fork", Price= 2.0},
            new ProductModel{Sku="3", Title="Knife", Price= 2.0},
            new ProductModel{Sku="4", Title="Plate", Price= 6.0}
        };

        [HttpGet("[action]")]
        public IEnumerable<ProductModel> Products()
        {
            return ProductList;
        }

    }
}
