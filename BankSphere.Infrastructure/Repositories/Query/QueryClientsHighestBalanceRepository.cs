using BankSphere.Infrastructure.Entities;
using BankSphere.Infrastructure.Interfaces.Repositories;
using BankSphere.Infrastructure.Repositories.Base.SQLServer;
using BankSphere.Infrastructure.Resources;
using BankSphere.Infrastructure.Settings;
using Microsoft.Extensions.Options;

namespace BankSphere.Infrastructure.Repositories.Query
{
    public class QueryClientsHighestBalanceRepository : SqlServerBase<ClientsHighestBalanceEntity>, IQueryClientsHighestBalanceRepository
    {
        public QueryClientsHighestBalanceRepository(IOptions<InfrastructureSettings> settings)
        : base(settings.Value.SqlServerSettings.ConnectionStrings.SqlServer)
        {
        }
        public async Task<IEnumerable<ClientsHighestBalanceEntity>> GetClientsHighestBalances()
        {
            string sql = sqlstatements.get_clients_highest_balance;
            IEnumerable<ClientsHighestBalanceEntity> clientsHighestBalanceEntity = await ExecuteResultWhitoutFilter<ClientsHighestBalanceEntity>(sql);

            return clientsHighestBalanceEntity;
        }
    }
}
