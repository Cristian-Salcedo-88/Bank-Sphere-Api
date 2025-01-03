namespace BankSphere.Api.Aplication.Models.Product
{
    public class PostProductBodyRequestModel
    {
        public int ClientId { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public decimal? InterestRate { get; set; }
    }
}
