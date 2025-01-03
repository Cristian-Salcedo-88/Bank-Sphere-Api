using BankSphere.Domain.Interfaces;
using BankSphere.Infrastructure.Entities;
using BankSphere.Infrastructure.Exceptions;
using BankSphere.Infrastructure.Repositories.Base.SQLServer;
using BankSphere.Infrastructure.Resources;
using BankSphere.Infrastructure.Settings;
using Microsoft.Extensions.Options;

namespace BankSphere.Infrastructure.Repositories.Domain
{
    public class AccountRepository : SqlServerBase<AccountEntity>, IAccountRepository
    {
        public AccountRepository(IOptions<InfrastructureSettings> settings)
        : base(settings.Value.SqlServerSettings.ConnectionStrings.SqlServer)
        {
        }
        public async Task CreateCDTAccount(int productId, decimal? interestRate)
        {
            var parameters = new
            {
                ProductId = productId,
                InterestRate = interestRate / 100
            };

            string sql = sqlstatements.create_cdt_account;

            await SingleInsertWith(sql, parameters);
        }

        public async Task CreateCheckingAccount(int productId)
        {
            var parameters = new
            {
                ProductId = productId
            };

            string sql = sqlstatements.create_checking_account;

            await SingleInsertWith(sql, parameters);
        }

        public async Task CreateSavingAccount(int productId)
        {
            try
            {

                var parameters = new
                {
                    ProductId = productId,
                    InterestRate = 0.04
                };

                string sql = sqlstatements.create_saving_account;

                await SingleInsertWith(sql, parameters);
            }
            catch (Exception e)
            {

                throw new InfraestructureException(e.Message);
            }
        }
    }
}
