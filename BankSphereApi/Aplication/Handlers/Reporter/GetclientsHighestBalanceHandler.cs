using BankSphere.Api.Aplication.DTOs;
using BankSphere.Api.Aplication.Mapper;
using BankSphere.Api.Aplication.Queries;
using BankSphere.Infrastructure.Entities;
using BankSphere.Infrastructure.Exceptions;
using BankSphere.Infrastructure.Interfaces.Repositories;
using Microsoft.AspNetCore.Components.Routing;

namespace BankSphere.Api.Aplication.Handlers.Reporter
{
    public class GetclientsHighestBalanceHandler : IRequestHandler<GetClientsHighestBalanceQuery, IEnumerable<ClientsHighestBalanceDto>>
    {
        private readonly IQueryClientsHighestBalanceRepository _queryClientsHighestBalanceRepository;
        public GetclientsHighestBalanceHandler(IQueryClientsHighestBalanceRepository queryClientsHighestBalanceRepository)
        {
            _queryClientsHighestBalanceRepository = queryClientsHighestBalanceRepository;
        }
        public async Task<IEnumerable<ClientsHighestBalanceDto>> Handle(GetClientsHighestBalanceQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ClientsHighestBalanceEntity> clientsHighestBalanceDto = await _queryClientsHighestBalanceRepository.GetClientsHighestBalances();

            if (clientsHighestBalanceDto == default)
            {
                throw new NotFoundException($"no se encontraron clientes con cuentas creadas");
            }

            return ClientsHighestBalanceMapper.ToClientsHighestBalanceDTO(clientsHighestBalanceDto);
        }
    }
}
