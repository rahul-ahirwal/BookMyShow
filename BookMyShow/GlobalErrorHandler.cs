using BookMyShow.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace BookMyShow
{
    public class GlobalErrorHandler : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            Error error = new Error();
            error.StatusCode = (httpContext.Response?.StatusCode != null) ? httpContext.Response.StatusCode : StatusCodes.Status500InternalServerError;
            error.Message = exception.Message;
            error.CorrelationId = Guid.Parse(httpContext.TraceIdentifier);
            return ValueTask.FromResult(true);
        }
    }
}
