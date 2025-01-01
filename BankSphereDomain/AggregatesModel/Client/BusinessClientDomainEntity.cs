namespace BankSphere.Domain.AggregatesModel.Client
{
    public class BusinessClientDomainEntity
    {
        public BusinessClientDomainEntity(
            string dedlegateName,
            string delegateIdentificationNumber,
            string delegatePhone)
        {
            DelegateName = dedlegateName;
            DelegateIdentificationNumber = delegateIdentificationNumber;
            DelegatePhone = delegatePhone;
        }
        public string DelegateName { get; private set; }
        public string DelegateIdentificationNumber { get; private set; }
        public string DelegatePhone { get; private set; }
    }
}
