using System.Threading.Tasks;

namespace Blazor.Shared.Controllers
{
    public interface IProductsApi
    {
        Task<ProductModel[]> Products();

        Task<ProductModel[]> GetProducts(string[] skus);

        Task<ProductModel[]> PaginatedProducts(int pageIndex);

        Task<int> TotalPages();
    }
}