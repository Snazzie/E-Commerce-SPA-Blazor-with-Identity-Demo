using Blazor.Server.Controllers;
using Blazor.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blazor.Client.Services
{
    public interface IApiUsageService : IProductsApi
    {
    }

    public class ApiUsageService: IApiUsageService
    {
        HttpClient HttpClient;

        
        public ApiUsageService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public Task<ProductModel[]> GetProducts(string[] skus)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductModel[]> PaginatedProductsAsync(int pageIndex)
        {

            var json = await HttpClient.GetStringAsync($"api/Products/PaginatedProducts/{pageIndex}");
            return JsonConvert.DeserializeObject<ProductModel[]>(json);

        }

        public IEnumerable<ProductModel> Products()
        {
            throw new NotImplementedException();
        }

        public int TotalPages()
        {
            throw new NotImplementedException();
        }
    }
}
