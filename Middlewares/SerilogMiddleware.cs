using Serilog;

namespace LMS.Middlewares
{
    public class SerilogMiddleware
    {
        private readonly RequestDelegate _next;

        public SerilogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("from serialise");
            Log.Information($"Incoming request(Serilog): {context.Request.Method} {context.Request.Path}\n");
            await _next(context);
            Log.Information($"Outgoing response(Serilog): {context.Response.StatusCode}\n");
        }
    }
}