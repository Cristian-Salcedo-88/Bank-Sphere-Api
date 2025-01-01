using BankSphere.Api.Aplication.Models.Reporter;
using BankSphere.Api.Aplication.Queries;
using BankSphere.Infrastructure.Exceptions;

namespace BankSphere.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReporterController : Controller
    {
        IMediator _mediator;
        public ReporterController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Obtiene la informaciòn los 10 clientes con mas saldo en sus cuentas
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundException))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponseDTO))]
        public async Task<ActionResult<IEnumerable<ClientsHighestBalanceDto>>> GetVehicleStatus()
        {
            IEnumerable<ClientsHighestBalanceDto> clientsHighestBalanceDto = await _mediator.Send(new GetClientsHighestBalanceQuery());
            return Ok(clientsHighestBalanceDto);
        }
    }
}
