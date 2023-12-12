using Microsoft.AspNetCore.Mvc;

namespace PracticeCatalog.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
            "Pasta", "Pillow", "Knife", "C# Book", "F# Book"
        };

        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ILogger<CatalogController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCatalog")]
        public IEnumerable<CatalogItem> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new CatalogItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Names[Random.Shared.Next(Names.Length)]
                })
                .ToArray();
        }
    }
}