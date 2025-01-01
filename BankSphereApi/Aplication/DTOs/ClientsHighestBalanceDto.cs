namespace BankSphere.Api.Aplication.DTOs
{
    public class ClientsHighestBalanceDto
    {
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
    }
}
