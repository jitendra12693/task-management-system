using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace TaskManagement.Presentation.Common
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        public ExceptionHandlerMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                Stopwatch sw = Stopwatch.StartNew();
                _logger.LogInformation("Handling request: {Method} {Path}", context.Request.Method, context.Request.Path);
                await _next(context);
                sw.Stop();
                _logger.LogInformation("Finished handling request. Status Code: {StatusCode}. Time taken: {ElapsedMilliseconds} ms", context.Response.StatusCode, sw.ElapsedMilliseconds);
            }
            catch (UnauthorizedAccessException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    status = context.Response.StatusCode,
                    error = "Unauthorized",
                    message = ex.Message
                }));
            }
            catch (KeyNotFoundException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    status = context.Response.StatusCode,
                    error = "Not Found",
                    message = ex.Message
                }));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new
                {
                    status = context.Response.StatusCode,
                    error = "Internal Server Error",
                    message = ex.Message
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));

            }
        }
    }
}
