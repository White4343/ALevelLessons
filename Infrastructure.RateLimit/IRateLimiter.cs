using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Infrastructure.RateLimit
{
    internal interface IRateLimiter
    {
        Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next);
    }
}
