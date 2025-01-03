using BankSphere.Api.Aplication.Commands.Client;

namespace BankSphere.Api.Aplication.DTOs
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string IdentificationNUmber { get; set; }
        public string Phone { get; set; }
        public string PersonType { get; set; }
        public BusinessClientCommand BusinessClient { get; set; }
    }
}
