namespace BankSphere.Api.Aplication.Commands.Transaction
{
    public class CreateTransactionBodyCommand : IRequest<int>
    {
        public int ProductId { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
    }
}
