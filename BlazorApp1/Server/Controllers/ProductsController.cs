using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        [HttpGet("[action]")]
        public IEnumerable<ProductModel> GetProducts([FromQuery]string[] skus)
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
            return toReturn;
        }


        [HttpGet("[action]/{pageIndex}")]
        public IEnumerable<ProductModel> PaginatedProducts(int pageIndex)
        {
            pageIndex--;
            return m_ProductStore.GetAll(pageIndex, 20);
        }

        [HttpGet("[action]")]
        public int TotalPages()
        {
            return m_ProductStore.TotalPages(20);
        }
    }
}
