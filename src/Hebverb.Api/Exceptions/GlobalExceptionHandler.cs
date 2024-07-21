using Hebverb.Api.Model;
using Hebverb.Services;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Hebverb.Api.Exceptions;

public class GlobalExceptionHandler(ILoggerManager logger) : IExceptionHandler
{
    private readonly ILoggerManager _logger = logger;

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        httpContext.Response.ContentType = "application/json";
        
        _logger.LogError($"Something went wrong: {exception.Message}");

        var message = exception switch
        {
            AccessViolationException => "Access violation error",
            _ => "Internal Server Error"
        };

        await httpContext.Response.WriteAsync(
            new ErrorDetails()
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message,
            }.ToString(),
            cancellationToken: cancellationToken);

        return true;
    }
}
