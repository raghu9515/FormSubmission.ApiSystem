using FluentValidation;
using System.Net;
using System.Text.Json;
namespace FormSubmission.Api.Middleware;
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next; private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger) { _next = next; _logger = logger; }
    public async Task InvokeAsync(HttpContext context)
    {
        try { await _next(context); }
        catch (ValidationException ex) { await Write(context, HttpStatusCode.BadRequest, string.Join("; ", ex.Errors.Select(e=>e.ErrorMessage))); }
        catch (UnauthorizedAccessException ex) { await Write(context, HttpStatusCode.Unauthorized, ex.Message); }
        catch (KeyNotFoundException ex) { await Write(context, HttpStatusCode.NotFound, ex.Message); }
        catch (Exception ex) { _logger.LogError(ex,"Unhandled exception"); await Write(context, HttpStatusCode.InternalServerError, "Unexpected server error."); }
    }
    private static async Task Write(HttpContext context, HttpStatusCode code, string msg) { context.Response.StatusCode=(int)code; context.Response.ContentType="application/json"; await context.Response.WriteAsync(JsonSerializer.Serialize(new { error = msg })); }
}
