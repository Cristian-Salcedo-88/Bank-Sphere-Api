using BankSphere.Domain.AggregatesModel.Product;

namespace BankSphere.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<int> CreateProduct(ProductDomainEntity productDomainEntity);
        Task UpdateProduct(decimal balance, int productId, bool IsCancelation);
    }
}