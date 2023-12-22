using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Infrastructure.Services;

namespace Catalog.UnitTests.Services;

public class CatalogBrandServiceTest
{
    private readonly Mock<ICatalogBrandRepository> _catalogBrandRepositoryMock;
    private readonly Mock<ILogger<BaseDataService<ApplicationDbContext>>> _loggerMock;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapperMock;

    private readonly ICatalogBrandService _catalogBrandService;

    public CatalogBrandServiceTest()
    {
        _catalogBrandRepositoryMock = new Mock<ICatalogBrandRepository>();
        _loggerMock = new Mock<ILogger<BaseDataService<ApplicationDbContext>>>();
        _dbContextWrapperMock = new Mock<IDbContextWrapper<ApplicationDbContext>>();

        _catalogBrandService = new CatalogBrandService(_dbContextWrapperMock.Object, _loggerMock.Object, _catalogBrandRepositoryMock.Object);
    }

    [Fact]
    public async Task Add_Success()
    {
        // arrange
        var testResult = 1;

        var item = new CatalogBrand()
        {
            Brand = It.IsAny<string>()
        };

        _catalogBrandRepositoryMock.Setup(s => s.Add(item)).ReturnsAsync(testResult);

        // act
        var result = await _catalogBrandService.Add(item);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task Add_Failed()
    {
        // arrange
        var testResult = 0;

        var item = new CatalogBrand()
        {
            Brand = It.IsAny<string>()
        };

        _catalogBrandRepositoryMock.Setup(s => s.Add(item)).ReturnsAsync(testResult);

        // act
        var result = await _catalogBrandService.Add(item);

        // assert
        result.Should().NotBe(testResult);
    }

    [Fact]
    public async Task Delete_Success()
    {
        // arrange
        var testResult = true;

        var id = It.IsAny<int>();

        _catalogBrandRepositoryMock.Setup(s => s.Delete(id)).ReturnsAsync(testResult);

        // act
        var result = await _catalogBrandService.Delete(id);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task Delete_Failed()
    {
        // arrange
        var testResult = false;

        var id = It.IsAny<int>();

        _catalogBrandRepositoryMock.Setup(s => s.Delete(id)).ReturnsAsync(testResult);

        // act
        var result = await _catalogBrandService.Delete(id);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task Update_Success()
    {
        // arrange
        var testResult = 1;

        var item = new CatalogBrand()
        {
            Brand = It.IsAny<string>()
        };

        _catalogBrandRepositoryMock.Setup(s => s.Update(item)).ReturnsAsync(testResult);

        // act
        var result = await _catalogBrandService.Update(item);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task Update_Failed()
    {
        // arrange
        var testResult = 0;

        var item = new CatalogBrand()
        {
            Brand = It.IsAny<string>()
        };

        _catalogBrandRepositoryMock.Setup(s => s.Update(item)).ReturnsAsync(testResult);

        // act
        var result = await _catalogBrandService.Update(item);

        // assert
        result.Should().NotBe(testResult);
    }
}