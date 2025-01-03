using System;
using BankSphere.Domain.AggregatesModel.Product;
using BankSphere.Infrastructure.Entities;
using BankSphere.Infrastructure.Exceptions;
using BankSphere.Infrastructure.Interfaces.Repositories;
using BankSphere.Infrastructure.Repositories.Base.SQLServer;
using BankSphere.Infrastructure.Resources;
using BankSphere.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using static Dapper.SqlMapper;

namespace BankSphere.Infrastructure.Repositories.Query
{
    public class QueryAverageBalanceByTypeRepository : SqlServerBase<AverageBalanceByTypeEntity>, IQueryAverageBalanceByTypeRepository
    {
        public QueryAverageBalanceByTypeRepository(IOptions<InfrastructureSettings> settings)
        : base(settings.Value.SqlServerSettings.ConnectionStrings.SqlServer)
        {
        }
        public async Task<IEnumerable<AverageBalanceByTypeEntity>> GetAverageBalanceByTypeAsync()
        {
            try
            {
                var parameters = new
                {
                    Active = true
                };
                string sql = sqlstatements.get_average_balance_by_type;
                IEnumerable<AverageBalanceByTypeEntity> averageBalanceByTypeEntity = await ExecuteResult<AverageBalanceByTypeEntity>(sql, parameters);

                return averageBalanceByTypeEntity;
            }
            catch (Exception e)
            {

                throw new InfraestructureException(e.Message);
            }
        }
    }
}
