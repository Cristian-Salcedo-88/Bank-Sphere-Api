using BankSphere.Api.Aplication.Commands.Client;
using BankSphere.Infrastructure.Entities;

namespace BankSphere.Api.Aplication.Mapper
{
    public static class ClientMapper
    {
        public static ClientDto ToClientDTO(ClientEntity entity)
        {
            return new ClientDto
            {
                Name = entity.Name,
                IdentificationNUmber = entity.IdentificationNumber,
                ClientId = entity.Id,
                Phone = entity.Phone,
                PersonType = entity.PersonType,
                BusinessClient = new BusinessClientCommand
                {
                    DelegateIdentificationNumber = entity.DelegateIdentificationNumber,
                    DelegateName = entity.DelegateName,
                    DelegatePhone = entity.DelegatePhone
                }
            };
        }
    }
}
