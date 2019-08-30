using Blazor.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Stores
{
    public class ProductStore : IStore<ProductModel>
    {
        private List<ProductModel> products = new List<ProductModel> { 
            new ProductModel { Sku = "1", Title = "Knife", Price = 4.99, Quantity = 20 },
            new ProductModel { Sku = "2", Title = "Dish", Price = 8.99, Quantity = 10 },
            new ProductModel { Sku = "3", Title = "Cup", Price = 2.99, Quantity = 40 }
        };

        
        public IEnumerable<ProductModel> GetAll()
        {

            return products;
        }

    }
}
