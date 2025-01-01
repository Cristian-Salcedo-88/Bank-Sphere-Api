using BankSphere.Infrastructure.Exceptions;
using System.Net;

namespace BankSphere.Api.Aplication.ExceptionHandler
{
    public class InfraestructureExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handler(HttpContext context, Exception exception, string correlationId)
        {
            var ex = exception as InfraestructureException;
            return SetResult(context, new string[] { ex.Message }, HttpStatusCode.InternalServerError, correlationId);
        }
    }
}
