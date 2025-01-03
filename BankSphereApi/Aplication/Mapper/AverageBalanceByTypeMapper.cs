using BankSphere.Infrastructure.Entities;

namespace BankSphere.Api.Aplication.Mapper
{
    public static class AverageBalanceByTypeMapper
    {
        public static IEnumerable<AverageBalanceByTypeDto> ToAverageBalanceByTypeDto(IEnumerable<AverageBalanceByTypeEntity> averageBalanceByTypeEntity)
        {
            IEnumerable<AverageBalanceByTypeDto> averageDto = (from entity in averageBalanceByTypeEntity
                                                               select new AverageBalanceByTypeDto()
                                                                {
                                                                   AccountType = entity.AccountType,
                                                                   AverageBalance = entity.AverageBalance
                                                                });
            return averageDto;
        }
    }
}
