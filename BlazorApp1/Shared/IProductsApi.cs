using Blazor.Shared;
using System.Collections.Generic;

namespace Blazor.Server.Controllers
{
    public interface IProductsApi
    {
        IEnumerable<ProductModel> Products();

        IEnumerable<ProductModel> GetProducts(string[] skus);

        IEnumerable<ProductModel> PaginatedProducts(int pageIndex);

        int TotalPages();
    }
}