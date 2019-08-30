using Blazor.Shared;
using System;
using System.Collections.Generic;

namespace BlazorApp1.Server.Stores
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
                    Price = double.Parse($"{rand.Next(0, 1001)}.{rand.Next(0, 100)}")
                });
            }

            return generatedProducts;
        }

    }
}
