using BankSphere.Api.Aplication.Queries;
using BankSphere.Infrastructure.Exceptions;

namespace BankSphere.Api.Controllers
{
    public class ReporterController : Controller
    {
        IMediator _mediator;
        public ReporterController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Obtiene la informaciòn los 10 clientes 
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundException))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponseDTO))]
        public async Task<ActionResult<ClientDto>> GetVehicleStatus([FromQuery] QueryClientModel filter)
        {
            GetClientQuery Query = new(filter);
            ClientDto client = await _mediator.Send(Query);
            return Ok(client);
        }
    }
}
