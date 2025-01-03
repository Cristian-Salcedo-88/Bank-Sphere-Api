namespace BankSphere.Api.Aplication.Queries
{
    public class GetClientQuery : IRequest<ClientDto>
    {
        public QueryClientModel Query { get; set; }
        public GetClientQuery(QueryClientModel filter)
        {
            Query = filter;
        }

    }
}
