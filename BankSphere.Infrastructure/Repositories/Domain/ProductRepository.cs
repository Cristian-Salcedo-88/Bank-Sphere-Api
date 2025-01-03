using System;
using BankSphere.Domain.AggregatesModel.Client;
using BankSphere.Domain.AggregatesModel.Product;
using BankSphere.Domain.Interfaces;
using BankSphere.Infrastructure.Entities;
using BankSphere.Infrastructure.Exceptions;
using BankSphere.Infrastructure.Interfaces.Repositories;
using BankSphere.Infrastructure.Repositories.Base.SQLServer;
using BankSphere.Infrastructure.Resources;
using BankSphere.Infrastructure.Settings;
using Microsoft.Extensions.Options;

namespace BankSphere.Infrastructure.Repositories.Domain
{
    public class ProductRepository : SqlServerBase<ProductEntity>, IProductRepository, IQueryProductRepository
    {   
        public ProductRepository(IOptions<InfrastructureSettings> settings)
        : base(settings.Value.SqlServerSettings.ConnectionStrings.SqlServer)
        {
        }

        public async Task<int> CreateProduct(ProductDomainEntity productDomainEntity)
        {
            var parameters = new
            {
                productDomainEntity.ClientId,
                productDomainEntity.AccountType,
                productDomainEntity.Balance
            };

            string sql = sqlstatements.create_product;
            int ProductId = await SingleInsertWithReturnId(sql, parameters);

            return ProductId;
        }

        public async Task<IEnumerable<ProductEntity>> GetProductByClientId(int clientId)
        {
            var parameters = new
            {
                ClientId = clientId,
                Active = true
            };
            string sql = sqlstatements.get_product_by_client_id;
            IEnumerable<ProductEntity> productEntity = await ExecuteResult<ProductEntity>(sql, parameters);

            return productEntity;
        }

        public async Task<IEnumerable<ProductEntity>> GetProductByFilters(int clientId, string accountType)
        {
            var parameters = new
            {
                ClientId = clientId,
                AccountType = accountType,
                Active = true
            };
            string sql = sqlstatements.get_product_by_filters;
            IEnumerable<ProductEntity> productEntity = await ExecuteResult<ProductEntity>(sql, parameters);

            return productEntity;
        }

        public async Task<ProductEntity> GetProductById(int productId)
        {
            var parameters = new
            {
                ProductId = productId
            };
            string sql = sqlstatements.get_product_by_id;
            ProductEntity productEntity = await ExecuteSingleAsync(sql, parameters);

            return productEntity;
        }

        public async Task UpdateProduct(decimal balance, int productId, bool IsCancelation)
        {
            try
            {
                var parameters = new
                {
                    Balance = balance,
                    Active = IsCancelation ? 0 : 1,
                    ProductId = productId,
                };
                string sql = sqlstatements.update_product;
                int affectRows = await SingleUpDate(sql, parameters);
            }
            catch (Exception e)
            {

                throw new InfraestructureException(e.Message);
            }
        }
    }
}
