using BankSphere.Api.Aplication.Commands.Client;
using BankSphere.Infrastructure.Entities;
using BankSphere.Infrastructure.Interfaces.Repositories;

namespace BankSphere.Api.Aplication.Handlers.Client
{
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, GeneralResponseDto>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IBusinessClientRepository _businessClientRepository;
        private readonly IQueryClientRepository _queryClientRepository;

        public CreateClientHandler(
            IClientRepository clientRepository,
            IBusinessClientRepository businessClientRepository,
            IQueryClientRepository queryClientRepository)
        {
            _clientRepository = clientRepository;
            _businessClientRepository = businessClientRepository;
            _queryClientRepository = queryClientRepository;
        }

        public async Task<GeneralResponseDto> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {

            ClientEntity client = await _queryClientRepository.GetClientByIdentificationAsync(request.Body.IdentificationNumber);
            if (client != null)
            {
                throw new ArgumentException("El cliente ya se encuentra registrado.");
            }

            if (client == default)
            {
                ClientDomainEntity clientDomainEntity = new(
                    request.Body.Name,
                    request.Body.IdentificationNumber,
                    request.Body.Phone,
                    request.Body.PersonType,
                    request.Body.PersonType == "JURIDICO"
                        ? new(
                            request.Body.BusinessClient.DelegateName,
                            request.Body.BusinessClient.DelegateIdentificationNumber,
                            request.Body.BusinessClient.DelegatePhone)
                        : null
                );

                int clientId = await _clientRepository.CreateClient(clientDomainEntity);

                if (request.Body.PersonType == "JURIDICO" && request.Body.BusinessClient != null)
                {
                    await _businessClientRepository.CreateBusinessClient(clientId, clientDomainEntity.BusinessClient);
                }

                return new GeneralResponseDto()
                {
                    Response = "Usuario Creado correctamente"
                };
            }
            else
            {
                throw new Exception("El Cliente ya se encuentra registrado");
            }
        }
    }
}
