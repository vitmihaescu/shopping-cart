using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vit.ShoppingCart.Application.UseCases.CreateOrder;
using Vit.ShoppingCart.Domain.Books;
using Vit.ShoppingCart.Domain.Orders;
using Vit.ShoppingCart.Domain.Products;
using Xunit;

namespace Vit.ShoppingCart.Tests.UseCases
{
    public class CreateOrderTests : TestWithDbContext
    {

        [Fact]
        public async Task Stores_NewOrders_InDatabase()
        {
            var orderItems = await CreateOrderItemsAsync();

            var handler = new CreateOrderHandler(DbContext);
            var expected = await handler.Handle(new CreateOrderCommand {OrderItems = orderItems}, CancellationToken.None);
            DbContext.DetachAllEntities();

            var actual = await DbContext.Orders.AsNoTracking()
                .Include(o => o.Items).ThenInclude(i => i.Product)
                .FirstAsync();

            Assert.NotEqual(expected, actual);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Items.Count, actual.Items.Count);
            Assert.All(expected.Items, item => Assert.Contains(actual.Items, i => i.Id == item.Id && i.Product.Id == item.Product.Id));
        }

        [Fact]
        public async Task Stores_PendingPayment()
        {
            var orderItems = await CreateOrderItemsAsync();

            var handler = new CreateOrderHandler(DbContext);
            var order = await handler.Handle(new CreateOrderCommand {OrderItems = orderItems}, CancellationToken.None);
            var payment = await DbContext.Orders.Include(o => o.Payment)
                .Select(o => o.Payment)
                .FirstOrDefaultAsync(o => o.Id == order.Id);

            Assert.NotNull(payment);
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