using BankSphere.Infrastructure.Entities;

namespace BankSphere.Infrastructure.Interfaces.Repositories
{
    public interface IQueryClientsHighestBalanceRepository
    {
        Task<IEnumerable<ClientsHighestBalanceEntity>> GetClientsHighestBalances();
    }
}