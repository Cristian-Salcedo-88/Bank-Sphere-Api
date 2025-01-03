
using BankSphere.Domain.Exceptions;

namespace BankSphere.Domain.AggregatesModel.Product
{
    public class ProductDomainEntity
    {
        public ProductDomainEntity(
            int clientId,
            string accountType,
            decimal balance)
        {
            ClientId = clientId;
            AccountType = accountType;
            Balance = balance;
        }
        public ProductDomainEntity(
            int clientId,
            string accountType,
            decimal balance,
            decimal? interestRate)
        {
            ClientId = clientId;
            AccountType = accountType;
            Balance = balance;
            InterestRate = interestRate;
            Validate();
        }
        public int ClientId { get; private set; }
        public string AccountType { get; private set; }
        public decimal Balance { get; private set; }
        public decimal? InterestRate { get; set; }

        private void Validate()
        {
            if (AccountType == "CDT" && InterestRate == null)
            {
                throw new DomainException("EL campo tasa de interes es requerido");
            }
        }
    }
}
