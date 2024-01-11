using System.Security.Claims;
using Basket.Host.Models;
using Basket.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Basket.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class BasketBffController : ControllerBase
{
    private readonly ILogger<BasketBffController> _logger;
    private readonly IBasketService _basketService;

    public BasketBffController(
        ILogger<BasketBffController> logger,
        IBasketService basketService)
    {
        _logger = logger;
        _basketService = basketService;
    }
    
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public IActionResult TestGet()
    {
        return Ok("log any test message");
    }

    [HttpGet("/userId")]
    [ProducesResponseType(typeof(TestGetResponse), (int)HttpStatusCode.OK)]
    public IActionResult TestGetId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        return Ok(userId);
    }
}