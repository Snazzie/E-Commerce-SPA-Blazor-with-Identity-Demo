using Blazor.Server.Controllers;
using Blazor.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace BlazorApp1.Client.Services
{
    public interface IApiUsageService : IProductsApi
    {
    }

    /// <summary>
    /// Currently there is a bug where you cant DI HttpClient made by blazor. It causes a deadlock in UI. A bug has been filed. will have to wait for the bug to be fixed....
    /// https://github.com/aspnet/AspNetCore/issues/12349
    /// </summary>
    public class ApiUsageService: IApiUsageService
    {
        HttpClient HttpClient;

        
        public ApiUsageService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public IEnumerable<ProductModel> GetProducts(string[] skus)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductModel> PaginatedProducts(int pageIndex)
        {

            var json = HttpClient.GetStringAsync($"api/Products/PaginatedProducts/{pageIndex}").Result;
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
