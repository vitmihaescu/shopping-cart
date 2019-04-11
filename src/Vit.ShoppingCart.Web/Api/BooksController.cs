using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vit.ShoppingCart.Application.UseCases.GetBookList;
using Vit.ShoppingCart.Domain.Books;

namespace Vit.ShoppingCart.Web.Api
{
    /// <summary>
    /// ShoppingCart API for Books
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/books
        [HttpGet]
        [ProducesResponseType(typeof(IList<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<Book>>> Get()
        {
            return Ok(await _mediator.Send(new BookListQuery()));
        }
    }
}