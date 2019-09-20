using Blazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Services
{
    public class CartService
    {

        public List<ProductModel> CartProducts { get; set; } = new List<ProductModel>();

        public Dictionary<string, CartItemModel> Cart { get; set; } = new Dictionary<string, CartItemModel>();
        private EventsService _EventsService { get; }

        public CartService(EventsService eventsService)
        {
            _EventsService = eventsService;
        }

        public void AddToCart(string sku, CartItemModel cartItemModel)
        {
            Cart.Add(sku, cartItemModel);
            _EventsService.NotifyCartUpdated();
        }

        public void RemoveFromCart(string sku)
        {
            if (Cart.ContainsKey(sku))
            {
                Cart.Remove(sku);
                _EventsService.NotifyCartUpdated();
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



    }
}
