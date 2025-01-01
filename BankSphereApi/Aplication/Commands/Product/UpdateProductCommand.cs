using BankSphere.Api.Aplication.Models.Product;

namespace BankSphere.Api.Aplication.Commands.Product
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public UpdateProductModel Body { get; set; }
    }
}
