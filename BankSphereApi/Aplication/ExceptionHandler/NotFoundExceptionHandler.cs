using BankSphere.Infrastructure.Exceptions;
using System.Net;

namespace BankSphere.Api.Aplication.ExceptionHandler
{
    public class NotFoundExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handler(HttpContext context, Exception exception, string correlationId)
        {
            var ex = exception as NotFoundException;
            return SetResult(context, new string[] { ex.Message }, HttpStatusCode.NotFound, correlationId);
        }
    }
}
