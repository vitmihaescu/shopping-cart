using System.Collections.Generic;
using MediatR;
using Vit.ShoppingCart.Domain.Books;

namespace Vit.ShoppingCart.Application.UseCases.GetBookList
{
    public class BookListQuery : IRequest<IList<Book>>
    {
    }
}