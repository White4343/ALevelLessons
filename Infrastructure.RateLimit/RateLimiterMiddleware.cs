using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StackExchange.Redis;

namespace Infrastructure.RateLimit
{
    public class RateLimiterMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDatabase _redisDatabase;

        public RateLimiterMiddleware(
            RequestDelegate next,
            IConnectionMultiplexer redisDatabase)
        {
            _next = next;
            _redisDatabase = redisDatabase.GetDatabase();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ipAddress = context.Connection.RemoteIpAddress?.ToString();
            var requestPath = context.Request.Path.ToString();

            var key = $"{ipAddress}:{requestPath}";

            var rateLimit = _redisDatabase.StringGet(key);

            if (rateLimit.HasValue)
            {
                var rateLimitValue = int.Parse(rateLimit.ToString());

                if (rateLimitValue > 10)
                {
                    context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                    return;
                }

                _redisDatabase.StringIncrement(key);
            }
            else
            {
                _redisDatabase.StringSet(key, 1, TimeSpan.FromMinutes(1));
            }

            await _next(context);
        }
    }
}
