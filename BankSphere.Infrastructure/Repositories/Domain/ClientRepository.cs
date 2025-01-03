using BankSphere.Domain.AggregatesModel.Client;
using BankSphere.Domain.Interfaces;
using BankSphere.Infrastructure.Entities;
using BankSphere.Infrastructure.Interfaces.Repositories;
using BankSphere.Infrastructure.Repositories.Base.SQLServer;
using BankSphere.Infrastructure.Resources;
using BankSphere.Infrastructure.Settings;
using Microsoft.Extensions.Options;

namespace BankSphere.Infrastructure.Repositories.Domain
{
    public class ClientRepository : SqlServerBase<ClientEntity>, IClientRepository, IQueryClientRepository
    {
        public ClientRepository(IOptions<InfrastructureSettings> settings)
        : base(settings.Value.SqlServerSettings.ConnectionStrings.SqlServer)
        {
        }
        public async Task<int> CreateClient(ClientDomainEntity clientDomainEntity)
        {
            string CountryCode = "+57";
            var parameters = new
            {
               clientDomainEntity.IdentificationNumber,
               clientDomainEntity.Name,
               clientDomainEntity.PersonType,
               clientDomainEntity.Phone,
               CountryCode
            };

            string sql = sqlstatements.create_client;
            int ClientId = await SingleInsertWithReturnId(sql, parameters);
            return ClientId;
        }

        public async Task<ClientEntity> GetClienId(int clientId)
        {
            var parameters = new
            {
                ClientId = clientId
            };
            string sql = sqlstatements.get_client_by_id;
            ClientEntity clientEntity = await ExecuteSingleAsync(sql, parameters);
            return clientEntity;
        }

        public async Task<ClientEntity> GetClientByIdentificationAsync(string identificationNumber)
        {
            var parameters = new
            {
                IdentificationNumber = identificationNumber
            };
            string sql = sqlstatements.get_client_by_identification;
            ClientEntity clientEntity = await ExecuteSingleAsync(sql, parameters);
            return clientEntity;
        }
    }
}
