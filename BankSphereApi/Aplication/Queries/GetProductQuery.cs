using BankSphere.Api.Aplication.Models.Product;

namespace BankSphere.Api.Aplication.Queries
{
    public class GetProductQuery : IRequest<IEnumerable<ProductDto>>
    {
        public QueryProductModel Query { get; set; }
        public GetProductQuery(QueryProductModel filter)
        {
            Query = filter;
        }

    }
}
