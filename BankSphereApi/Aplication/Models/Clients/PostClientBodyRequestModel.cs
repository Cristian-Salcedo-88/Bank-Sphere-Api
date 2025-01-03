namespace BankSphere.Api.Aplication.Models.Clients
{
    public class PostClientBodyRequestModel
    {
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public string Phone { get; set; }
        public string PersonType { get; set; }
        public BusinessClientModel? BusinessClientModel { get; set; }
    }
}
