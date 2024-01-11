using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StackExchange.Redis;

namespace Infrastructure.RateLimit
{
    public class RateLimiterFilter : IRateLimiter, IAsyncActionFilter
    {
        private readonly IDatabase _redisDatabase;

        public RateLimiterFilter(
            IConnectionMultiplexer redisDatabase)
        {
            _redisDatabase = redisDatabase.GetDatabase();
        }
        
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var ipAddress = context.HttpContext.Connection.RemoteIpAddress?.ToString();
            var requestPath = context.HttpContext.Request.Path.ToString();

            var key = $"{ipAddress}:{requestPath}";

            var rateLimit = _redisDatabase.StringGet(key);

            if (rateLimit.HasValue)
            {
                var rateLimitValue = int.Parse(rateLimit.ToString());

                if (rateLimitValue > 10)
                {
                    context.Result = new StatusCodeResult(StatusCodes.Status429TooManyRequests);
                    return;
                }

                _redisDatabase.StringIncrement(key);
            }
            else
            {
                _redisDatabase.StringSet(key, 1, TimeSpan.FromMinutes(1));
            }

            await next();
        }
    }
    
}
