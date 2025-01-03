namespace BankSphere.Api.Aplication.Commands.Client
{
    public class CreateClientCommand : IRequest<GeneralResponseDto>
    {
        public CreateClientBodyCommand Body { get; set; }
    }
}
