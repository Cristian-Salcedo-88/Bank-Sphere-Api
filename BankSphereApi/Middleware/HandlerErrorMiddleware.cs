using BankSphere.Api.Aplication.ExceptionHandler;
using System.Net;

namespace BankSphere.Api.Middleware
{
    public class HandlerErrorMiddleware
    {
        public const string SERVER_ERROR = "Ocurrió un error inesperado. Contacte al administrador del sistema.";

        private readonly RequestDelegate _next;
        private readonly ILogger<HandlerErrorMiddleware> _logger;
        private readonly IDictionary<Type, IExceptionHandler> _exceptionHandlers;

        public HandlerErrorMiddleware(
            RequestDelegate next,
            ILogger<HandlerErrorMiddleware> logger,
            IDictionary<Type, IExceptionHandler> exceptionHandlers)
        {
            _next = next;
            _logger = logger;
            _exceptionHandlers = exceptionHandlers;
        }

        public async Task Invoke(HttpContext context)
        {
            string correlationId = context.Request.Headers["correlationId"].FirstOrDefault();

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandlerExceptionAsync(context, ex, correlationId);
            }
        }

        private Task HandlerExceptionAsync(HttpContext context, Exception ex, string correlationId)
        {
            _logger.LogError(ex, ex.Message);
            Task taskResult;
            Type exptionType = ex.GetType();
            if (_exceptionHandlers.TryGetValue(exptionType, out IExceptionHandler exceptionHandler))
            {
                taskResult = exceptionHandler.Handler(context, ex, correlationId);
            }
            else
            {
                taskResult = new ExceptionHandlerBase()
                    .SetResult(
                    context,
                    new string[] { SERVER_ERROR },
                    HttpStatusCode.InternalServerError,
                    correlationId);
            }

            return taskResult;
        }
    }
}
