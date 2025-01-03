using BankSphere.Api.Aplication.Mapper;
using BankSphere.Api.Aplication.Queries;
using BankSphere.Infrastructure;
using BankSphere.Infrastructure.Entities;
using BankSphere.Infrastructure.Exceptions;
using BankSphere.Infrastructure.Interfaces.Repositories;

namespace BankSphere.Api.Aplication.Handlers.Client
{
    public class GetClientHandler : IRequestHandler<GetClientQuery, ClientDto>
    {
        private readonly IQueryClientRepository _queryClientRepository;
        public GetClientHandler(IQueryClientRepository queryClientRepository)
        {
            _queryClientRepository = queryClientRepository;
        }
        public async Task<ClientDto> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            ClientEntity client = await _queryClientRepository.GetClientByIdentificationAsync(request.Query.IdentificationNumber);


            if (client == default)
            {
                throw new NotFoundException($"No se encontro el cliente con identificacion: {request.Query.IdentificationNumber}");
            }

            return ClientMapper.ToClientDTO(client);
        }
    }
}
