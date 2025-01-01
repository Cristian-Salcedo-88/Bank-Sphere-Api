using BankSphere.Domain.AggregatesModel.Client;
using BankSphere.Domain.AggregatesModel.Transaction;

namespace BankSphere.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        Task<int> CreateTransaction(TransactionDomainEntity transactionDomainEntity);
    }
}
