using BankSphere.Api.Aplication.Mapper;
using BankSphere.Api.Aplication.Queries;
using BankSphere.Infrastructure.Entities;
using BankSphere.Infrastructure.Exceptions;
using BankSphere.Infrastructure.Interfaces.Repositories;

namespace BankSphere.Api.Aplication.Handlers.Product
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, IEnumerable<ProductDto>>
    {
        private readonly IQueryProductRepository _queryProductRepository;
        private readonly IQueryClientRepository _queryClientRepository;
        public GetProductHandler(
            IQueryProductRepository queryProductRepository,
            IQueryClientRepository queryClientRepository)
        {
            _queryProductRepository = queryProductRepository;
            _queryClientRepository = queryClientRepository;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {

            ClientEntity entity = await _queryClientRepository.GetClienId(request.Query.ClientId);
            
            if (entity == null)
            {
                throw new NotFoundException($"No se encontro cliente asociado al id {request.Query.ClientId}");
            }

            IEnumerable<ProductEntity> product = await _queryProductRepository.GetProductByClientId(request.Query.ClientId);

            if (product == default)
            {
                throw new NotFoundException($"No se encontro información del producto asociada al cliente con id: {request.Query.ClientId}");
            }

            return ProductMapper.ToProductDTO(product);
        }
    }
}
