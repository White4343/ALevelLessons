using System.Threading;
using Catalog.Host.Data.Entities;

namespace Catalog.UnitTests.Services;

public class CatalogItemServiceTest
{
    private readonly ICatalogItemService _catalogService;

    private readonly Mock<ICatalogItemRepository> _catalogItemRepository;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<CatalogService>> _logger;

    private readonly CatalogItem _testItem = new CatalogItem()
    {
        Name = "Name",
        Description = "Description",
        Price = 1000,
        AvailableStock = 100,
        CatalogBrandId = 1,
        CatalogTypeId = 1,
        PictureFileName = "1.png"
    };

    public CatalogItemServiceTest()
    {
        _catalogItemRepository = new Mock<ICatalogItemRepository>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<CatalogService>>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper.Setup(s => s.BeginTransactionAsync(It.IsAny<CancellationToken>())).ReturnsAsync(dbContextTransaction.Object);

        _catalogService = new CatalogItemService(_dbContextWrapper.Object, _logger.Object, _catalogItemRepository.Object);
    }

    [Fact]
    public async Task AddAsync_Success()
    {
        // arrange
        var testResult = 1;

        var item = new CatalogItem()
        {
            Name = It.IsAny<string>(),
            Description = It.IsAny<string>(),
            Price = It.IsAny<decimal>(),
            AvailableStock = It.IsAny<int>(),
            CatalogBrandId = It.IsAny<int>(),
            CatalogTypeId = It.IsAny<int>(),
            PictureFileName = It.IsAny<string>()
        };

        _catalogItemRepository.Setup(s => s.Add(item)).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.AddAsync(_testItem);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task AddAsync_Failed()
    {
        // arrange
        int? testResult = null;

        var item = new CatalogItem()
        {
            Name = It.IsAny<string>(),
            Description = It.IsAny<string>(),
            Price = It.IsAny<decimal>(),
            AvailableStock = It.IsAny<int>(),
            CatalogBrandId = It.IsAny<int>(),
            CatalogTypeId = It.IsAny<int>(),
            PictureFileName = It.IsAny<string>()
        };

        _catalogItemRepository.Setup(s => s.Add(item)).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.AddAsync(_testItem);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task Delete_Success()
    {
        // arrange
        var testResult = true;

        var id = It.IsAny<int>();

        _catalogItemRepository.Setup(s => s.Delete(id)).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.Delete(id);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task Delete_Failed()
    {
        // arrange
        var testResult = false;

        var id = It.IsAny<int>();

        _catalogItemRepository.Setup(s => s.Delete(id)).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.Delete(id);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task GetById_Success()
    {
        // arrange
        var testResult = _testItem;

        var id = It.IsAny<int>();

        _catalogItemRepository.Setup(s => s.GetById(id)).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.GetById(id);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task GetById_Failed()
    {
        // arrange
        CatalogItem? testResult = null;

        var id = It.IsAny<int>();

        _catalogItemRepository.Setup(s => s.GetById(id)).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.GetById(id);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task Update_Success()
    {
        // arrange
        var testResult = 1;

        var item = new CatalogItem()
        {
            Name = It.IsAny<string>(),
            Description = It.IsAny<string>(),
            Price = It.IsAny<decimal>(),
            AvailableStock = It.IsAny<int>(),
            CatalogBrandId = It.IsAny<int>(),
            CatalogTypeId = It.IsAny<int>(),
            PictureFileName = It.IsAny<string>()
        };

        _catalogItemRepository.Setup(s => s.Update(item)).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.Update(item);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task Update_Failed()
    {
        // arrange
        int? testResult = null;

        var item = new CatalogItem()
        {
            Name = It.IsAny<string>(),
            Description = It.IsAny<string>(),
            Price = It.IsAny<decimal>(),
            AvailableStock = It.IsAny<int>(),
            CatalogBrandId = It.IsAny<int>(),
            CatalogTypeId = It.IsAny<int>(),
            PictureFileName = It.IsAny<string>()
        };

        _catalogItemRepository.Setup(s => s.Update(item)).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.Update(item);

        // assert
        result.Should().Be(testResult);
    }
}