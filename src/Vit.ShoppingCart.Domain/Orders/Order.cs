using System;
using System.Collections.Generic;
using Vit.ShoppingCart.Domain.Payments;

namespace Vit.ShoppingCart.Domain.Orders
{
    public class Order
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get; set; }

        public IList<OrderItem> Items { get; set; }
        public Payment Payment { get; set; }
    }
}