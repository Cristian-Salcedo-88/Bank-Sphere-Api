using BankSphere.Infrastructure.Entities;

namespace BankSphere.Api.Aplication.Mapper
{
    public static class ClientsHighestBalanceMapper
    {
            public static IEnumerable<ClientsHighestBalanceDto> ToClientsHighestBalanceDto(IEnumerable<ClientsHighestBalanceEntity> clientsHighestBalanceEntity)
            {
                IEnumerable<ClientsHighestBalanceDto> clientsDto = (from entity in clientsHighestBalanceEntity
                                                      select new ClientsHighestBalanceDto()
                                                      {
                                                          IdentificationNumber = entity.IdentificationNumber,
                                                          Name = entity.Name,
                                                          AccountType = entity.AccountType,
                                                          Balance = entity.Balance
                                                      });
                return clientsDto;
            }
    }
}
