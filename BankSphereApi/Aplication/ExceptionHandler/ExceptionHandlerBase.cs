using System.Net;

namespace BankSphere.Api.Aplication.ExceptionHandler
{
    public class ExceptionHandlerBase
    {
        private const string _RESPONSE_TITLE = "Error";
        private const string _RESPONSE_CONTENT_TYPE = "application/json";
        private const string _RESPONSE_TYPE = "Exception";

        public async Task SetResult(HttpContext context, string[] errorMessage, HttpStatusCode httpStatusCode, string correlationId)
        {
            int status = (int)httpStatusCode;
            var errorDto = new BadRequestResponseDTO
            {
                Title = _RESPONSE_TITLE,
                Status = status,
                Type = _RESPONSE_TYPE,
                TraceId = correlationId,
                Errors = new Dictionary<string, string[]>()
                {
                    { _RESPONSE_TITLE, errorMessage }
                },
            };
            context.Response.ContentType = _RESPONSE_CONTENT_TYPE;
            var response = JsonConvert.SerializeObject(errorDto);
            context.Response.StatusCode = status;
            context.Response.ContentType = _RESPONSE_CONTENT_TYPE;
            await context.Response.WriteAsync(response);
        }
    }
}
