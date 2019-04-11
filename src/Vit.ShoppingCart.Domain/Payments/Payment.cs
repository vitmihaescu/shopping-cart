using System;
using Vit.ShoppingCart.Domain.Orders;

namespace Vit.ShoppingCart.Domain.Payments
{
    public class Payment
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; }

        public Order Order { get; set; }
    }
}