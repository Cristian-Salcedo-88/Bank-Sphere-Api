namespace BankSphere.Infrastructure.Entities
{
    public class ClientsHighestBalanceEntity
    {
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
    }
}
