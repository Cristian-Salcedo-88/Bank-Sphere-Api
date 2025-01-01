using BankSphere.Api.Aplication.Commands.Client;
using BankSphere.Infrastructure.Entities;
using static Dapper.SqlMapper;

namespace BankSphere.Api.Aplication.Mapper
{
    public static class ProductMapper
    {
        public static IEnumerable<ProductDto> ToProductDTO(IEnumerable<ProductEntity> productEntity)
        {
            IEnumerable<ProductDto> productDto = (from entity in productEntity
                                                  select new ProductDto()
                                                  {
                                                      ProductId = entity.ProductId,
                                                      ClientId = entity.ClientId,
                                                      AccountType = entity.AccountType,
                                                      Balance = entity.Balance,
                                                      OpeningDate = entity.OpeningDate,
                                                      Active = entity.Active
                                                  });
            return productDto;
        }
    }
}
