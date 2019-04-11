using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vit.ShoppingCart.Domain.Orders;
using Vit.ShoppingCart.Domain.Payments;

namespace Vit.ShoppingCart.Application.UseCases.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateOrderHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> Handle([NotNull] CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var totalAmount = request.OrderItems
                .Join(_dbContext.Books, item => item.Product.Id, book => book.Id, (item, book) => item.Count * book.Price).Sum();
            var order = new Order
            {
                Items = request.OrderItems,
                TotalAmount = totalAmount,
                Payment = new Payment { Amount = totalAmount }
            };

            await _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return order;
        }
    }
}