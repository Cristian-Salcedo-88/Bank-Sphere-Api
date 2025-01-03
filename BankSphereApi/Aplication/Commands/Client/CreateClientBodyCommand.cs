namespace BankSphere.Api.Aplication.Commands.Client
{
    public class CreateClientBodyCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public string Phone { get; set; }
        public string PersonType { get; set; }
        public BusinessClientCommand? BusinessClient { get; set; }
    }
}
