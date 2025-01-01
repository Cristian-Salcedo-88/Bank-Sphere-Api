using BankSphere.Infrastructure.Entities;

namespace BankSphere.Infrastructure.Interfaces.Repositories
{
    public interface IQueryProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetProductByFilters(int clientId);
        Task<ProductEntity> GetProductById(int productId);
    }
}
