namespace LMS.Middlewares
{
    public class ILoggerMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public ILoggerMiddleware(RequestDelegate next, ILogger<ILoggerMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"Incoming request(ILogger): {context.Request.Method} {context.Request.Path}\n");
            await _next(context);
            _logger.LogInformation($"Outgoing response(ILogger): {context.Response.StatusCode}\n");
        }
    }
}