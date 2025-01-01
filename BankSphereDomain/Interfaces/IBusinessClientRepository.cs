using BankSphere.Domain.AggregatesModel.Client;

namespace BankSphere.Domain.Interfaces
{
    public interface IBusinessClientRepository
    {
        Task CreateBusinessClient(int clientId, BusinessClientDomainEntity businessClientDomainEntity);
    }
}
