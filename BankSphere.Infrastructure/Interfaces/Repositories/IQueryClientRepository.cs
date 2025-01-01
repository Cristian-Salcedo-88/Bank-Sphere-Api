using BankSphere.Infrastructure.Entities;

namespace BankSphere.Infrastructure.Interfaces.Repositories
{
    public interface IQueryClientRepository
    {
        Task<ClientEntity> GetClientByIdentificationAsync(string identificationNumber);
        Task<ClientEntity> GetClienId(int clientId);
    }
}
