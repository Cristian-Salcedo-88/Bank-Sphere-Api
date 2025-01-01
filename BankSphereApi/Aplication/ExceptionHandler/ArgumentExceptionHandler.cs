using System.Net;

namespace BankSphere.Api.Aplication.ExceptionHandler
{
    public class ArgumentExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handler(HttpContext context, Exception exception, string correlationId)
        {
            var ex = exception as ArgumentException;
            return SetResult(context, new string[] { ex.Message }, HttpStatusCode.BadRequest, correlationId);
        }
    }
}
