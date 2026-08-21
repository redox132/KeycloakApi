using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace PeopleForce.Api.Expections;

public class GlobalExceptionsHanlder : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {

        var exceptionResponse = new ExceptionResponse()
        {
            StatusCode = StatusCodes.Status500InternalServerError,
            Title = "Unexpected Error Occured",
            ExceptionMessage = exception.Message,
            ExceptionDateTime = DateTime.UtcNow, 
            StackTrace = exception.StackTrace ?? "No Stack Trace Found"
        };

        var jsonResponse = JsonSerializer.Serialize(exceptionResponse);

        httpContext.Response.StatusCode = exceptionResponse.StatusCode;
        httpContext.Response.ContentType = "application/problem+json; charset=utf-8";

        await httpContext.Response.WriteAsync(jsonResponse);

        return true;
    }
}