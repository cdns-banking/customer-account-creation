using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customer_account_creation.API.InterceptorMiddleware
{
    public class InterceptorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public InterceptorMiddleware(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;

            _logger = logFactory.CreateLogger("MyMiddleware");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("MyMiddleware executing..");

            await _next(httpContext); // calling next middleware

        }
    }

    public static class InterceptorMiddlewareExtensions
    {
        public static IApplicationBuilder UseInterceptorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<InterceptorMiddleware>();
        }
    }
}
