using BankSphere.Api.Aplication.Commands.Transaction;
using BankSphere.Domain.AggregatesModel.Transaction;

namespace BankSphere.Api.Aplication.Handlers.Transaction
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, int>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IProductRepository _productRepository;
        public CreateTransactionHandler(
            ITransactionRepository transactionRepository,
            IProductRepository productRepository)
        {
            _transactionRepository = transactionRepository;
            _productRepository = productRepository;
        }
        public async Task<int> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            TransactionDomainEntity transactionDomainEntity = new(
                request.Body.ProductId,
                request.Body.TransactionType,
                request.Body.Amount
            );

            int transactionId = await _transactionRepository.CreateTransaction(transactionDomainEntity);

            return transactionId;
        }
    }
}
