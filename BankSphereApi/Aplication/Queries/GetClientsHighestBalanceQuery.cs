using MediatR;
using Microsoft.AspNetCore.Components.Routing;

namespace BankSphere.Api.Aplication.Queries
{
    public class GetClientsHighestBalanceQuery : IRequest<IEnumerable<ClientsHighestBalanceDto>>
    {
    }
}
