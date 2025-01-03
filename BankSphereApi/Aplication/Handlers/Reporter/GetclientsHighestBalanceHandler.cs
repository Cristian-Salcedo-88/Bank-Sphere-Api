using BankSphere.Api.Aplication.DTOs;
using BankSphere.Api.Aplication.Mapper;
using BankSphere.Api.Aplication.Queries;
using BankSphere.Infrastructure.Entities;
using BankSphere.Infrastructure.Exceptions;
using BankSphere.Infrastructure.Interfaces.Repositories;

namespace BankSphere.Api.Aplication.Handlers.Reporter
{
    public class GetClientsHighestBalanceHandler : IRequestHandler<GetClientsHighestBalanceQuery, IEnumerable<ClientsHighestBalanceDto>>
    {
        private readonly IQueryClientsHighestBalanceRepository _queryClientsHighestBalanceRepository;
        public GetClientsHighestBalanceHandler(IQueryClientsHighestBalanceRepository queryClientsHighestBalanceRepository)
        {
            _queryClientsHighestBalanceRepository = queryClientsHighestBalanceRepository;
        }
        public async Task<IEnumerable<ClientsHighestBalanceDto>> Handle(GetClientsHighestBalanceQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ClientsHighestBalanceEntity> clientsHighestBalanceEntity = await _queryClientsHighestBalanceRepository.GetClientsHighestBalances();

            if (clientsHighestBalanceEntity == default)
            {
                throw new NotFoundException($"no se encontraron clientes con cuentas creadas");
            }

            return ClientsHighestBalanceMapper.ToClientsHighestBalanceDto(clientsHighestBalanceEntity);
        }
    }
}
