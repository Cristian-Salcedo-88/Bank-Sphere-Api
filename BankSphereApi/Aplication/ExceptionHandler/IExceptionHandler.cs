namespace BankSphere.Api.Aplication.ExceptionHandler
{
    public interface IExceptionHandler
    {
        Task Handler(HttpContext context, Exception exception, string correlationId);
    }
}
