using System;
using System.Threading.Tasks;
using Blazor.Shared;
using Blazor.Shared.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CheckoutController : ControllerBase, ICheckoutApi
    {

        [HttpPost("[Action]")]
        public Task<string> PlaceOrder(OrderFormModel orderForm)
        {

            return Task.FromResult(Guid.NewGuid().ToString());
        }
    }
}