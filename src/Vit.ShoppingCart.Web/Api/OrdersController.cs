using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vit.ShoppingCart.Application.UseCases.CreateOrder;
using Vit.ShoppingCart.Domain.Products;
using Vit.ShoppingCart.Web.Api.Models;

namespace Vit.ShoppingCart.Web.Api
{
    /// <summary>
    ///     ShoppingCart API for Orders
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/orders
        [HttpPost]
        [ProducesResponseType(typeof(Order), (int) HttpStatusCode.Accepted)]
        [ProducesResponseType((int) HttpStatusCode.Conflict)]
        public async Task<ActionResult<Order>> Post([FromBody] OrderItem[] items)
        {
            var orderItems = items.Select(item =>
                new Domain.Orders.OrderItem
                {
                    Product = new Product {Id = item.ProductId},
                    Count = item.Count
                }).ToList();
            var order = await _mediator.Send(new CreateOrderCommand {OrderItems = orderItems});
            var orderInfo = new Order
            {
                OrderCode = order.Id.ToString("N"),
                Amount = order.TotalAmount
            };

            return Accepted(orderInfo);
        }
    }
}