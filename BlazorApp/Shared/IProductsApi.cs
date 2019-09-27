using Blazor.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.Server.Controllers
{
    public interface IProductsApi
    {
        Task<ProductModel[]> Products();

        Task<ProductModel[]> GetProducts(string[] skus);

        Task<ProductModel[]> PaginatedProductsAsync(int pageIndex);

        int TotalPages();
    }
}