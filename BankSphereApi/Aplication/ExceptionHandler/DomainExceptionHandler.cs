using BankSphere.Domain.Exceptions;
using System.Net;

namespace BankSphere.Api.Aplication.ExceptionHandler
{
    public class DomainExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handler(HttpContext context, Exception exception, string correlationId)
        {
            var ex = exception as DomainException;
            return SetResult(context, new string[] { ex.Message }, HttpStatusCode.Conflict, correlationId);
        }
    }
}
