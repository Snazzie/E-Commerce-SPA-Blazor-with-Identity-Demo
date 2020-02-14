using Blazor.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Client.Services
{
    public interface ICartService
    {
        Dictionary<string, CartItemModel> Cart { get; set; }
        List<ProductModel> CartProducts { get; }

        bool CartContains(string sku);
        CartItemModel[] GetCartItems();
        Task UpdateCart(string sku, int quantity);
        Task Initialize();
        Task UpdateCartProductsCache();
        double CalculateCost();
    }

    public class CartService : ICartService
    {

        public List<ProductModel> CartProducts { get; private set; } = new List<ProductModel>();
        public Dictionary<string, CartItemModel> Cart { get; set; } = new Dictionary<string, CartItemModel>();
        public IApiUsageService ApiUsageService { get; }

        private readonly IEventService EventsService;

        public CartService(IEventService eventsService, IApiUsageService apiUsageService)
        {
            EventsService = eventsService;
            ApiUsageService = apiUsageService;

        }
        public async Task Initialize()
        {
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


            await UpdateCartProductsCache();
            EventsService.NotifyCartUpdated();
        }

        private void AddToCart(string sku, CartItemModel cartItemModel)
        {
            Cart.Add(sku, cartItemModel);
        }

        private void RemoveFromCart(string sku)
        {
            if (Cart.ContainsKey(sku))
            {
                Cart.Remove(sku);
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

    }
}
