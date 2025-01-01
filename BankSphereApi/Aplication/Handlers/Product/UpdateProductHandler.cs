using BankSphere.Api.Aplication.Commands.Product;
using BankSphere.Domain.AggregatesModel.Product;
using BankSphere.Infrastructure.Entities;
using BankSphere.Infrastructure.Exceptions;
using BankSphere.Infrastructure.Interfaces.Repositories;

namespace BankSphere.Api.Aplication.Handlers.Product
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IQueryProductRepository _queryProductRepository;
        public UpdateProductHandler(
            IProductRepository productRepository,
            IQueryProductRepository queryProductRepository)
        {
            _productRepository = productRepository;
            _queryProductRepository = queryProductRepository;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            ProductEntity productEntity = await _queryProductRepository.GetProductById(request.Body.ProductId);

            if (productEntity == default)
            {
                throw new NotFoundException($"No se encontro el producto con id {request.Body.ProductId}");
            }

            bool IsCancelation = false;

            decimal balance = productEntity.Balance;

            
            CalculateNewBalance(balance, request.Body.TransactionType, request.Body.Amount);
            
            if (request.Body.TransactionType == "CANCELACION")
            {
                IsCancelation = true;
            }

                ProductDomainEntity productDomainEntity = new(
                    productEntity.ClientId,
                    productEntity.AccountType,
                    balance
                );

            await _productRepository.UpdateProduct(productDomainEntity.Balance, request.Body.ProductId, IsCancelation);

            return Unit.Value;
        }
        private decimal CalculateNewBalance(decimal currentBalance, string transactionType, decimal? amount)
        {
            decimal effectiveAmount = amount ?? 0m;

            return transactionType switch
            {
                "DEPOSITO" => currentBalance + effectiveAmount,
                "RETIRO"=> currentBalance - effectiveAmount,
                _ => currentBalance
            };
        }
    }
}
