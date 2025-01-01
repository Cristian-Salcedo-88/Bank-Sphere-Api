namespace BankSphere.Api.Aplication.Commands.Product
{
    public class CreateProductCommand : IRequest<int>
    {
        public CreateProductBodyCommand Body { get; set; }
    }
}
