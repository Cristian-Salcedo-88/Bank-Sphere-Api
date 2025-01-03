using Azure;
using BankSphere.Api.Aplication.Commands.Product;
using BankSphere.Domain.AggregatesModel.Product;
using BankSphere.Infrastructure.Entities;
using BankSphere.Infrastructure.Exceptions;
using BankSphere.Infrastructure.Interfaces.Repositories;

namespace BankSphere.Api.Aplication.Handlers.Product
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, GeneralResponseDto>
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
        public async Task<GeneralResponseDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            ProductEntity productEntity = await _queryProductRepository.GetProductById(request.Body.ProductId);

            if (productEntity == default)
            {
                throw new NotFoundException($"No se encontro el producto con id {request.Body.ProductId}");
            }

            if (request.Body.TransactionType == "RETIRO" && request.Body.Amount >  productEntity.Balance) 
            {
                throw new ArgumentException("El valor a retirar es mayor al saldo en la cuenta");
            }

            bool IsCancelation = false;

            decimal balance = productEntity.Balance;

            
            decimal newBalance = CalculateNewBalance(balance, request.Body.TransactionType, request.Body.Amount);
            
            if (request.Body.TransactionType == "CANCELACION")
            {
                IsCancelation = true;
            }

                ProductDomainEntity productDomainEntity = new(
                    productEntity.ClientId,
                    productEntity.AccountType,
                    balance
                );

            await _productRepository.UpdateProduct(newBalance, request.Body.ProductId, IsCancelation);
           
            return new GeneralResponseDto()
            {
                Response = "Usuario Creado correctamente"
            };
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
