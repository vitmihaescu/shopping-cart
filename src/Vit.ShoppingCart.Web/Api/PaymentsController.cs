using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vit.ShoppingCart.Application.UseCases.UpdatePayment;
using Vit.ShoppingCart.Web.Api.Models;

namespace Vit.ShoppingCart.Web.Api
{
    /// <summary>
    /// ShoppingCart API for Payments
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // PUT api/payments
        [HttpPut]
        [ProducesResponseType(202)]
        [ProducesResponseType(404)]
        //[Consumes("application/json")]
        public async Task<ActionResult> Post([FromBody] Payment model)
        {
            await _mediator.Send(new UpdatePaymentCommand { OrderId = model.OrderId, PaymentStatus = model.Status });

            return Accepted();
        }
    }
}