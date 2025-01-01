using BankSphere.Api.Aplication.Commands.Client;
using BankSphere.Api.Aplication.Queries;
using BankSphere.Infrastructure.Exceptions;

namespace BankSphere.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Crear un nuevo cliente
        /// </summary>  
        /// <returns>OK</returns>
        /// <param name="header"></param>
        /// <param name="createClient"></param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponseDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ClientResponseDto>> AddPlanConfiguration([FromBody] PostClientBodyRequestModel postClientBodyRequestModel)
        {

            CreateClientCommand postClientCommand = new()
            {
                Body = new()
                {
                    Name = postClientBodyRequestModel.Name,
                    IdentificationNumber = postClientBodyRequestModel.IdentificationNumber,
                    PersonType = postClientBodyRequestModel.PersonType,
                    Phone = postClientBodyRequestModel.Phone,
                    BusinessClient = postClientBodyRequestModel.BusinessClientModel != null ? new()
                    {
                        DelegateName = postClientBodyRequestModel.BusinessClientModel.DelegateName,
                        DelegateIdentificationNumber = postClientBodyRequestModel.BusinessClientModel.DelegateIdentificationNumber,
                        DelegatePhone = postClientBodyRequestModel.BusinessClientModel.DelegatePhone
                    } : null

                }
            };

            ClientResponseDto response = await _mediator.Send(postClientCommand);

            return Ok(response);
        }

        /// <summary>
        /// Obtiene la informaciòn de un cliente
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
