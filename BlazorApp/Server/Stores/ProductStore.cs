using Blazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blazor.Server.Stores
{
    public class ProductStore : IStore<ProductModel>
    {
        private List<ProductModel> products = GenerateProducts();
        public int TotalPages(int pageSize) => (int)Math.Ceiling(decimal.Divide(products.Count, pageSize));


        public IEnumerable<ProductModel> GetAll()
        {
            return products;
        }
 
        public IEnumerable<ProductModel> GetAll(int pageIndex, int pageSize)
        {

            return products.GetRange(pageIndex * pageSize, pageSize);
        }

        public IEnumerable<ProductModel> Get(IEnumerable<string> skus)
        {
            return skus.Select(sku => products.SingleOrDefault(p => p.Sku == sku)).ToArray();
        }

        public static List<ProductModel> GenerateProducts()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            List<ProductModel> generatedProducts = new List<ProductModel>();

            for (int i = 0; i < 200; i++)
            {
                generatedProducts.Add(new ProductModel()
                {
                    Sku = i.ToString(),
                    Title = "Item " + i,
                    Price = double.Parse($"{rand.Next(0, 1001)}.{rand.Next(0, 100)}"),
                    Quantity = rand.Next(0,3000)
                });
            }

            return generatedProducts;
        }

    }
}
