namespace BankSphere.Api.Aplication.Commands.Product
{
    public class CreateProductBodyCommand : IRequest<int>
    {
        public int ClientId { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public decimal? InterestRate { get; set; }
    }
}
