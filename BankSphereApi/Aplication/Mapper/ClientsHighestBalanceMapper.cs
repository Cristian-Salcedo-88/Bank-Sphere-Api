using BankSphere.Infrastructure.Entities;

namespace BankSphere.Api.Aplication.Mapper
{
    public static class ClientsHighestBalanceMapper
    {
            public static IEnumerable<ClientsHighestBalanceDto> ToClientsHighestBalanceDTO(IEnumerable<ClientsHighestBalanceEntity> clientsHighestBalanceEntity)
            {
                IEnumerable<ClientsHighestBalanceDto> productDto = (from entity in clientsHighestBalanceEntity
                                                      select new ClientsHighestBalanceDto()
                                                      {
                                                          IdentificationNumber = entity.IdentificationNumber,
                                                          Name = entity.Name,
                                                          AccountType = entity.AccountType,
                                                          Balance = entity.Balance
                                                      });
                return productDto;
            }
    }
}
