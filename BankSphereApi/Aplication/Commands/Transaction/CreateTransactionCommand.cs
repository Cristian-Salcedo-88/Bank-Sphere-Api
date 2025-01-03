namespace BankSphere.Api.Aplication.Commands.Transaction
{
    public class CreateTransactionCommand : IRequest<int>
    {
        public CreateTransactionBodyCommand Body { get; set; }
    }
}
