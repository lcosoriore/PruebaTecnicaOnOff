using Microsoft.AspNetCore.Http;
using Sorteo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sorteo.Infrastructure.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IApiKeyRepository _apiKeyRepository;

        public ApiKeyMiddleware(RequestDelegate next, IApiKeyRepository apiKeyRepository)
        {
            _next = next;
            _apiKeyRepository = apiKeyRepository;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("ApiKey", out var apiKeyHeader))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("ApiKey missing.");
                return;
            }

            var apiKey = apiKeyHeader.FirstOrDefault();
            if (!_apiKeyRepository.IsValidApiKey(apiKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid ApiKey.");
                return;
            }

            await _next.Invoke(context);
        }
    }

}
