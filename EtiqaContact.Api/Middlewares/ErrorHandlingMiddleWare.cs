using System.Net;
using System.Text.Json;

namespace EtiqaContact.Api.MiddleWares;

public class ErrorHandlingMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleWare> _logger;

    public ErrorHandlingMiddleWare(RequestDelegate next, ILogger<ErrorHandlingMiddleWare> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        _logger.LogError(exception, "An unhandled exception has occurred.");

        var statusCode = HttpStatusCode.InternalServerError;
        var response = new
        {
            error = "An unexpected error occurred. Please try again later."
        };

        if (exception is KeyNotFoundException)
        {
            statusCode = HttpStatusCode.NotFound;
            response = new
            {
                error = "Resource not found."
            };
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
