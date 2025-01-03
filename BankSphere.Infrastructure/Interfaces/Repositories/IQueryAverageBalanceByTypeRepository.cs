using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSphere.Infrastructure.Entities;

namespace BankSphere.Infrastructure.Interfaces.Repositories
{
    public interface IQueryAverageBalanceByTypeRepository
    {
        Task<IEnumerable<AverageBalanceByTypeEntity>> GetAverageBalanceByTypeAsync();
    }
}
