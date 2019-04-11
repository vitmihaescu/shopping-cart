using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vit.ShoppingCart.Application.Exceptions;

namespace Vit.ShoppingCart.Application.UseCases.UpdatePayment
{
    public class UpdatePaymentHandler : IRequestHandler<UpdatePaymentCommand>
    {
        private readonly ApplicationDbContext _dbContext;

        public UpdatePaymentHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _dbContext.Payments
                    .Where(p => p.Order.Id == request.OrderId)
                    .FirstOrDefaultAsync(cancellationToken)
                ?? throw new ObjectNotFoundException(string.Format(Messages.PaymentNotFound, request.OrderId));

            payment.Status = request.PaymentStatus;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}