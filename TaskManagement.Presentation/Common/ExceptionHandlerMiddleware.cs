using System.Diagnostics;

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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var response = new { message = "An unexpected error occurred. Please try again later." };
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
