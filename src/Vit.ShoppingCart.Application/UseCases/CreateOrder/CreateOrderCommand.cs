using System.Collections.Generic;
using MediatR;
using Vit.ShoppingCart.Domain.Orders;

namespace Vit.ShoppingCart.Application.UseCases.CreateOrder
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public IList<OrderItem> OrderItems { get; set; }
    }
}