using System;

namespace Vit.ShoppingCart.Web.Api.Models
{
    public class OrderItem
    {
        public Guid ProductId { get; set; }
        public int Count { get; set; }
    }
}
