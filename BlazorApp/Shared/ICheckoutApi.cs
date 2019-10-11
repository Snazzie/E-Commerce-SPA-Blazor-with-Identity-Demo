using Blazor.Shared;
using System.Threading.Tasks;

namespace Blazor.Shared.Controllers
{
    public interface ICheckoutApi
    {
        Task<string> PlaceOrder(OrderFormModel orderForm);
    }
}