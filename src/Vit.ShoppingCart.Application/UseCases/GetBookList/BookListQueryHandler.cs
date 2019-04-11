using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vit.ShoppingCart.Application.Extensions;
using Vit.ShoppingCart.Domain.Books;

namespace Vit.ShoppingCart.Application.UseCases.GetBookList
{
    public class BookListQueryHandler : IRequestHandler<BookListQuery, IList<Book>>
    {
        private readonly ApplicationDbContext _dbContext;

        public BookListQueryHandler([NotNull] ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Book>> Handle([NotNull] BookListQuery request, CancellationToken cancellationToken)
        {
            return (await _dbContext.Books.ToListAsync(cancellationToken)).Shuffle();
        }
    }
}