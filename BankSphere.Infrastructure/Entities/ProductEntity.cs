namespace BankSphere.Infrastructure.Entities
{
    public class ProductEntity
    {
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public DateTime OpeningDate { get; set; }
        public bool Active { get; set; }
    }
}