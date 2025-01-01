using BankSphere.Domain.Exceptions;
using BankSphere.Domain.Interfaces;

namespace BankSphere.Domain.AggregatesModel.Client
{
    public class ClientDomainEntity
    {
        public ClientDomainEntity(
            string name,
            string identificacionNumber,
            string phone,
            string personType,
            BusinessClientDomainEntity? businessClient = null)
        {
            Name = name;
            IdentificationNumber = identificacionNumber;
            Phone = phone;
            PersonType = personType;
            BusinessClient = businessClient;
            Validate();
        }
        public string Name { get; private set; }
        public string IdentificationNumber { get; private set; }
        public string Phone { get; private set; }
        public string PersonType { get; private set; }
        public BusinessClientDomainEntity BusinessClient { get; private set; }

        private void Validate()
        {
            if (PersonType == "JURIDICO" && BusinessClient == null)
            {
                throw new DomainException("La información del representante legal es requerida.");
            }
        }
    }
}
