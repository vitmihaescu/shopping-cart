using System;
using MediatR;
using Vit.ShoppingCart.Domain.Payments;

namespace Vit.ShoppingCart.Application.UseCases.UpdatePayment
{
    public class UpdatePaymentCommand : IRequest
    {
        public Guid OrderId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
