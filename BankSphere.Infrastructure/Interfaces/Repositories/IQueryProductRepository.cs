using BankSphere.Infrastructure.Entities;

namespace BankSphere.Infrastructure.Interfaces.Repositories
{
    public interface IQueryProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetProductByFilters(int clientId, string accountType);
        Task<IEnumerable<ProductEntity>> GetProductByClientId(int clientId);
        Task<ProductEntity> GetProductById(int productId);
    }
}
