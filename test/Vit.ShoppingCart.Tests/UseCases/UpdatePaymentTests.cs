using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vit.ShoppingCart.Application.UseCases.CreateOrder;
using Vit.ShoppingCart.Application.UseCases.UpdatePayment;
using Vit.ShoppingCart.Domain.Books;
using Vit.ShoppingCart.Domain.Orders;
using Vit.ShoppingCart.Domain.Payments;
using Vit.ShoppingCart.Domain.Products;
using Xunit;

namespace Vit.ShoppingCart.Tests.UseCases
{
    public class UpdatePaymentTests : TestWithDbContext
    {
        [Fact]
        public async Task Updates_PaymentStatus_InDatabase()
        {
            var orderHandler = new CreateOrderHandler(DbContext);
            var orderItems = await CreateOrderItemsAsync();
            var order = await orderHandler.Handle(new CreateOrderCommand { OrderItems = orderItems }, CancellationToken.None);

            var handler = new UpdatePaymentHandler(DbContext);
            await handler.Handle(
                new UpdatePaymentCommand { OrderId = order.Id, PaymentStatus = PaymentStatus.Authorized },
                CancellationToken.None);
            DbContext.DetachAllEntities();

            var actual = await DbContext.Payments.Where(p => p.Order.Id == order.Id).FirstAsync();

            Assert.Equal(PaymentStatus.Authorized, actual.Status);
        }

        private async Task<IList<OrderItem>> CreateOrderItemsAsync()
        {
            return await DbContext.Books
                .Take(2)
                .Select(b => new OrderItem { Product = new Book { Id = b.Id }, Count = 1 })
                .ToListAsync();
        }
    }
}