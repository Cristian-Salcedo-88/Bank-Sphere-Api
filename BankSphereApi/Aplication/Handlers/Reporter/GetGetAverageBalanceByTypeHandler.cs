using BankSphere.Api.Aplication.Mapper;
using BankSphere.Api.Aplication.Queries;
using BankSphere.Infrastructure.Entities;
using BankSphere.Infrastructure.Exceptions;
using BankSphere.Infrastructure.Interfaces.Repositories;

namespace BankSphere.Api.Aplication.Handlers.Reporter
{
    public class GetGetAverageBalanceByTypeHandler : IRequestHandler<GetAverageBalanceByTypeQuery, IEnumerable<AverageBalanceByTypeDto>>
    {
        private readonly IQueryAverageBalanceByTypeRepository _queryAverageBalanceByTypeRepository;
        public GetGetAverageBalanceByTypeHandler(IQueryAverageBalanceByTypeRepository queryAverageBalanceByTypeRepository)
        {
            _queryAverageBalanceByTypeRepository = queryAverageBalanceByTypeRepository;
        }
        public async Task<IEnumerable<AverageBalanceByTypeDto>> Handle(GetAverageBalanceByTypeQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<AverageBalanceByTypeEntity> averageBalanceByTypeEntity = await _queryAverageBalanceByTypeRepository.GetAverageBalanceByTypeAsync();

            if (averageBalanceByTypeEntity == default)
            {
                throw new NotFoundException($"no se encontraron productos creados");
            }

            return AverageBalanceByTypeMapper.ToAverageBalanceByTypeDto(averageBalanceByTypeEntity);
        }
    }
}
