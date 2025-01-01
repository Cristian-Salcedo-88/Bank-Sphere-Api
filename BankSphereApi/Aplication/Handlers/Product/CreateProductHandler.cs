using BankSphere.Api.Aplication.Commands.Product;
using BankSphere.Domain.AggregatesModel.Product;
using BankSphere.Infrastructure.Entities;
using BankSphere.Infrastructure.Interfaces.Repositories;

namespace BankSphere.Api.Aplication.Handlers.Product
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IQueryProductRepository _queryProductRepository;
        private readonly IProductRepository _productRepository;
        private readonly IAccountRepository _accountRepository;
        public CreateProductHandler(
            IQueryProductRepository queryProductRepository,
            IProductRepository productRepository,
            IAccountRepository accountRepository)
        {
            _queryProductRepository = queryProductRepository;
            _productRepository = productRepository;
            _accountRepository = accountRepository;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<ProductEntity> productEntity = await _queryProductRepository.GetProductByFilters(request.Body.ClientId);

            if (productEntity == null)
            {
                ProductDomainEntity productDomainEntity = new(
                    request.Body.ClientId,
                    request.Body.AccountType,
                    request.Body.Balance,
                    request.Body.InterestRate
                );

                int productId = await _productRepository.CreateProduct(productDomainEntity);

                await CreateAccount(request.Body.AccountType, productId, request.Body.InterestRate);

                return productId;
            }
            else
            {
                throw new Exception($"El Cliente ya contiene un producto de tipo : {request.Body.AccountType}");
            }
        }

        private async Task CreateAccount(string accountType, int productId, decimal? interestRate)
        {
            if (accountType == "AHORROS")
            {
                await _accountRepository.CreateSavingAccount(productId);
            }
            else if (accountType == "CORRIENTE")
            {
                await _accountRepository.CreateCheckingAccount(productId);
            }
            else
            {
                await _accountRepository.CreateCDTAccount(productId, interestRate);
            }
        }
    }
}
