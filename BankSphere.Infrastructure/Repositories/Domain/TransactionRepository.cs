using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSphere.Domain.AggregatesModel.Client;
using BankSphere.Domain.AggregatesModel.Transaction;
using BankSphere.Domain.Interfaces;
using BankSphere.Infrastructure.Entities;
using BankSphere.Infrastructure.Repositories.Base.SQLServer;
using BankSphere.Infrastructure.Resources;
using BankSphere.Infrastructure.Settings;
using Microsoft.Extensions.Options;

namespace BankSphere.Infrastructure.Repositories.Domain
{
    internal class TransactionRepository : SqlServerBase<BusinessClientEntity>, ITransactionRepository
    {
        public TransactionRepository(IOptions<InfrastructureSettings> settings)
        : base(settings.Value.SqlServerSettings.ConnectionStrings.SqlServer)
        {
        }
        public async Task<int> CreateTransaction(TransactionDomainEntity transactionDomainEntity)
        {
            var parameters = new
            {
                transactionDomainEntity.ProductId,
                transactionDomainEntity.TransactionType,
                transactionDomainEntity.Amount
            };

            string sql = sqlstatements.create_transaction;

            int transactionId = await SingleInsertWithReturnId(sql, parameters);

            return transactionId;
        }
    }
}
