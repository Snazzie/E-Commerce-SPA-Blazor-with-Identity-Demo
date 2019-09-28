using Blazor.Extensions.Storage;
using Blazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Client.Services
{
    public interface ISessionStorageService
    {
        Task<Dictionary<string, CartItemModel>> GetCartFromSessionStorage();
        Task UpdateSessionStorageCart(Dictionary<string, CartItemModel> cart);
    }

    public class SessionStorageService : ISessionStorageService
    {
        private SessionStorage SessionStorage { get; }

        public SessionStorageService(SessionStorage sessionStorage)
        {
            SessionStorage = sessionStorage;
        }

        public async Task UpdateSessionStorageCart(Dictionary<string, CartItemModel> cart)
        {
            await SessionStorage.SetItem<Dictionary<string, CartItemModel>>(StaticValues.StorageCartKey, cart);
        }

        public async Task<Dictionary<string, CartItemModel>> GetCartFromSessionStorage()
        {
            return await SessionStorage.GetItem<Dictionary<string, CartItemModel>>(StaticValues.StorageCartKey);
        }
    }
}
