using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SignUpSystem.WebApi.Middleware
{
    public class ExceptionLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionLoggerMiddleware(RequestDelegate next, ILogger logger)
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
                _logger.LogError(ex, "");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
        }
    }

    public static class ExceptionLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionLoggerMiddleware(this IApplicationBuilder builder) =>
            builder.UseMiddleware<ExceptionLoggerMiddleware>();
    }
}
