namespace BankSphere.Api.Aplication.Models.Product
{
    public class UpdateProductModel
    {
        public int ProductId { get; set; }
        public string TransactionType { get; set; }
        public decimal? Amount { get; set; }
    }
}
