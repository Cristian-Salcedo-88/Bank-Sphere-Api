using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSphere.Domain.AggregatesModel.Transaction
{
    public class TransactionDomainEntity
    {
        public TransactionDomainEntity(
            int productId,
            string transactionType,
            decimal amount)
        {
            ProductId = productId;
            TransactionType = transactionType;
            Amount = amount;
        }
        public int ProductId { get; private set; }
        public string TransactionType { get; private set; }
        public decimal Amount { get; private set; }
    }
}
