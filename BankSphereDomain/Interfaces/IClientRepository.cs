using BankSphere.Domain.AggregatesModel.Client;

namespace BankSphere.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<int> CreateClient(ClientDomainEntity clientDomainEntity);
    }
}
