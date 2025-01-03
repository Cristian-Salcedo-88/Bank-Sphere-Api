using Azure;

namespace BankSphere.Api.Aplication.Commands.Product
{
    public class CreateProductCommand : IRequest<GeneralResponseDto>
    {
        public CreateProductBodyCommand Body { get; set; }
    }
}
