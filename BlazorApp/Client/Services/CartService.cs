using Blazor.Client.Pages;
using Blazor.Client.Shared;
using Blazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Client.Services
{
    public interface ICartService
    {
        List<ProductModel> CartProducts { get; }
        Dictionary<string, CartItemModel> EditableCart { get; set; }
        bool CartContains(string sku);
        CartItemModel[] GetCartItems();
        Task UpdateCart(string sku, int quantity);
        Task Initialize();
        Task UpdateCartProductsCache();
        double CalculateCost();
        int GetTotalItemsCountInCart();
        int GetItemQuantityInCart(string sku);
    }

    public class CartService : ICartService
    {

        public List<ProductModel> CartProducts { get; private set; } = new List<ProductModel>();
        private Dictionary<string, CartItemModel> Cart { get; set; } = new Dictionary<string, CartItemModel>();
        public Dictionary<string, CartItemModel> EditableCart { get; set; } = new Dictionary<string, CartItemModel>();

        public ISessionStorageService SessionStorageService { get; }
        public IApiUsageService ApiUsageService { get; }

        private readonly IEventService EventsService;

        public CartService(IEventService eventsService, ISessionStorageService sessionStorageService, IApiUsageService apiUsageService)
        {
            EventsService = eventsService;
            SessionStorageService = sessionStorageService;
            ApiUsageService = apiUsageService;
        }


        public async Task Initialize()
        {
            var result = await SessionStorageService.GetCartFromSessionStorage();
            if (result != null)
                Cart = result;
            await UpdateCartProductsCache();
        }

        public async Task UpdateCart(string sku, int quantity)
        {
            if (quantity > 0)
            {
                if (!CartContains(sku))
                {
                    AddToCart(sku, new CartItemModel() { ProductSku = sku, Quantity = quantity });
                }
                else
                {
                    Cart[sku].Quantity = quantity;
                }
            }
            else
            {
                if (CartContains(sku))
                    RemoveFromCart(sku);
            }


            await SessionStorageService.UpdateSessionStorageCart(Cart);
            await UpdateCartProductsCache();
            EventsService.NotifyCartUpdated();
        }

        public int GetItemQuantityInCart(string sku)
        {
            return Cart[sku].Quantity;
        }

        private void AddToCart(string sku, CartItemModel cartItemModel)
        {
            Cart.Add(sku, cartItemModel);
            EditableCart.Add(sku, cartItemModel);
        }

        private void RemoveFromCart(string sku)
        {
            if (Cart.ContainsKey(sku))
            {
                Cart.Remove(sku);
                EditableCart.Remove(sku);
            }
        }

        public CartItemModel[] GetCartItems()
        {
            return Cart.Values.ToArray();
        }

        public bool CartContains(string sku)
        {
            return Cart.ContainsKey(sku);
        }

        public async Task UpdateCartProductsCache()
        {
            if (Cart?.Count() > 0)
            {
                var result = await ApiUsageService.GetProducts(Cart.Values.Select(c => c.ProductSku).ToArray());
                CartProducts = result.ToList();
            }
            else
            {
                CartProducts.Clear();
            }
        }

        public double CalculateCost()
        {
            return CartProducts.Select(p => Cart[p.Sku].Quantity * p.Price).Sum();
        }

        public int GetTotalItemsCountInCart() => Cart.Values.Select(v => v.Quantity).Sum();

    }
}
