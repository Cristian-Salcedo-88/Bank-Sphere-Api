namespace BankSphere.Infrastructure.Entities
{
    public class ClientEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public string PersonType { get; set; }
        public string Phone { get; set; }
        public string? DelegateName { get; set; }
        public string? DelegateIdentificationNumber { get; set; }
        public string? DelegatePhone { get; set; }
    }
}
