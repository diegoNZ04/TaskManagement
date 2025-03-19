using System.Net;
using System.Text.Json;
using TaskManagement.Application.Exceptions;

namespace TaskManagement.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
            _logger.LogError(ex, "An unhandled exception occurred.");

            var response = context.Response;
            response.ContentType = "application/json";

            var (statusCode, errorMessage) = ex switch
            {
                NotFoundException => (HttpStatusCode.NotFound, ex.Message),
                BadRequestException => (HttpStatusCode.BadRequest, ex.Message),
                ValidationException ve => (HttpStatusCode.UnprocessableEntity, JsonSerializer.Serialize(ve.Errors)),
                _ => (HttpStatusCode.InternalServerError, "An unexpected error occurred. Please try again later.")
            };

            response.StatusCode = (int)statusCode;
            await response.WriteAsync(JsonSerializer.Serialize(new { error = errorMessage }));

        }
    }
}