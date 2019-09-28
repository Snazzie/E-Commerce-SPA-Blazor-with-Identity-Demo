using Blazor.Server.Controllers;
using Blazor.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ProductModel[]> GetProducts(string[] skus)
        {
            var json = await HttpClient.GetStringAsync($"api/Products/GetProducts?skus={String.Join("&skus=", skus)}");
            return JsonConvert.DeserializeObject<ProductModel[]>(json);
        }

        public async Task<ProductModel[]> PaginatedProducts(int pageIndex)
        {

            var json = await HttpClient.GetStringAsync($"api/Products/PaginatedProducts/{pageIndex}");
            return JsonConvert.DeserializeObject<ProductModel[]>(json);

        }

        public async Task<ProductModel[]> Products()
        {
            var json = await HttpClient.GetStringAsync($"api/Products/Products");
            return JsonConvert.DeserializeObject<ProductModel[]>(json);
        }

        public async Task<int> TotalPages()
        {
            var json = await HttpClient.GetStringAsync($"api/Products/TotalPages");
            return int.Parse(json);
        }
    }
}
