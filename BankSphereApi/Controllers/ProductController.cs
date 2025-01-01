using BankSphere.Api.Aplication.Commands.Product;
using BankSphere.Api.Aplication.Handlers.Product;
using BankSphere.Api.Aplication.Models.Product;
using BankSphere.Api.Aplication.Queries;

namespace BankSphere.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Crear un nuevo producto
        /// </summary>  
        /// <returns>OK</returns>
        /// <param name="header"></param>
        /// <param name="createProduct"></param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponseDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddPlanConfiguration([FromBody] PostProductBodyRequestModel postProductBodyRequestModel)
        {

            CreateProductCommand postProductCommand = new()
            {
                Body = new()
                {
                   ClientId = postProductBodyRequestModel.ClientId,
                   AccountType = postProductBodyRequestModel.AccountType,
                   Balance = postProductBodyRequestModel.Balance,
                   InterestRate  = postProductBodyRequestModel.InterestRate != null 
                   ? postProductBodyRequestModel.InterestRate : null

                }
            };

            int statusCode = await _mediator.Send(postProductCommand);

            return StatusCode(statusCode);
        }

        /// <summary>
        /// Obtiene la informaciòn de un producto
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BadRequestResponseDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponseDTO))]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetVehicleStatus([FromQuery] QueryProductModel filter)
        {
            GetProductQuery Query = new(filter);
            IEnumerable<ProductDto> product = await _mediator.Send(Query);

            return Ok(product);
        }

        /// <summary>
        /// Deposita, retira o cancela un producto
        /// </summary>
        /// <param name="header"></param>
        /// <param name="productId"></param>
        /// <returns>ok</returns>
        /// <response code="204">Returns success</response> 
        /// <response code="404">Not found</response>  
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateProduct(UpdateProductModel updateProductModel)
        {
            UpdateProductCommand Command = new()
            {
                Body = new()
                {
                    ProductId = updateProductModel.ProductId,
                    Amount = updateProductModel.Amount,
                    TransactionType = updateProductModel.TransactionType
                }
            };
            await _mediator.Send(Command);
            return StatusCode(StatusCodes.Status204NoContent);
        }

    }
}
