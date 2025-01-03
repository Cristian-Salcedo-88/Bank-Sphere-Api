using Azure;
using BankSphere.Api.Aplication.Models.Product;

namespace BankSphere.Api.Aplication.Commands.Product
{
    public class UpdateProductCommand : IRequest<GeneralResponseDto>
    {
        public UpdateProductModel Body { get; set; }
    }
}
