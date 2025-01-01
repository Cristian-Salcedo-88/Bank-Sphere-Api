using BankSphere.Api.Aplication.Commands.Product;
using BankSphere.Api.Aplication.Commands.Transaction;
using BankSphere.Api.Aplication.Models.Product;
using BankSphere.Api.Aplication.Models.Transaction;

namespace BankSphere.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        IMediator _mediator;
        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Registrar una transacción
        /// </summary>  
        /// <returns>OK</returns>
        /// <param name="header"></param>
        /// <param name="createTransaction"></param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost("Transaction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponseDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddPlanConfiguration([FromBody] PostTransactionBodyRequestModel postTransactionBodyRequestModel)
        {

            CreateTransactionCommand postTransactionCommand = new()
            {
                Body = new()
                {
                    ProductId = postTransactionBodyRequestModel.ProductId,
                    TransactionType = postTransactionBodyRequestModel.TransactionType,
                    Amount = postTransactionBodyRequestModel.Amount
                }
            };

            int statusCode = await _mediator.Send(postTransactionCommand);

            return StatusCode(statusCode);
        }

    }
}
