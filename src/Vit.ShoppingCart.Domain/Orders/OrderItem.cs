using System;
using Vit.ShoppingCart.Domain.Products;

namespace Vit.ShoppingCart.Domain.Orders
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public int Count { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}