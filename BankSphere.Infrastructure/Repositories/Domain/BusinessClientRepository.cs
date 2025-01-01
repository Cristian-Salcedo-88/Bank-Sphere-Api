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
    public class BusinessClientRepository : SqlServerBase<BusinessClientEntity>, IBusinessClientRepository
    {
        public BusinessClientRepository(IOptions<InfrastructureSettings> settings)
        : base(settings.Value.SqlServerSettings.ConnectionStrings.SqlServer)
        {
        }
        public async Task CreateBusinessClient(int clientId, BusinessClientDomainEntity businessClientDomainEntity)
        {
            var parameters = new
            {
                ClientId = clientId,
                businessClientDomainEntity.DelegateName,
                businessClientDomainEntity.DelegateIdentificationNumber,
                businessClientDomainEntity.DelegatePhone 
            };

            string sql = sqlstatements.create_business_client;

            await SingleInsertWith(sql, parameters);
        }
    }
}
    