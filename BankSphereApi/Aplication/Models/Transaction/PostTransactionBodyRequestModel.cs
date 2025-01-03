namespace BankSphere.Api.Aplication.Models.Transaction
{
    public class PostTransactionBodyRequestModel
    {
        public int ProductId { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
    }
}
