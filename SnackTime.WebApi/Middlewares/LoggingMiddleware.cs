using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace SnackTime.WebApi.Middlewares
{
    public static class LoggingMiddlewareeExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }

    public class LoggingMiddleware
    {
        private readonly RequestDelegate            _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (LogContext.PushProperty("CustomRequestId", Guid.NewGuid().ToString("N")))
            using (LogContext.PushProperty("Method", context.Request.Method))
            using (LogContext.PushProperty("Endpoint", context.Request.Path))
            {
                var watch = Stopwatch.StartNew();
                await _next(context);
                _logger.LogTrace($"Request took {watch.Elapsed.TotalMilliseconds:0} ms, Code {context.Response.StatusCode}");
            }
        }
    }
}