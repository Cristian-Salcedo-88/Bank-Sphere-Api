namespace BankSphere.Api.Aplication.Commands.Client
{
    public class CreateClientCommand : IRequest<ClientResponseDto>
    {
        public CreateClientBodyCommand Body { get; set; }
    }
}
