using System;
using Vit.ShoppingCart.Domain.Payments;

namespace Vit.ShoppingCart.Web.Api.Models
{
    public class Payment
    {
        public Guid OrderId { get; set; }
        public PaymentStatus Status { get; set; }
    }
}