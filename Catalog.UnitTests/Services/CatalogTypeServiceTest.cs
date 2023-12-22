using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Infrastructure.Services;

namespace Catalog.UnitTests.Services
{
    public class CatalogTypeServiceTest
    {
        private readonly Mock<ICatalogTypeRepository> _catalogTypeRepositoryMock;
        private readonly Mock<ILogger<BaseDataService<ApplicationDbContext>>> _loggerMock;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapperMock;
        private readonly ICatalogTypeService _catalogTypeService;

        public CatalogTypeServiceTest()
        {
            _catalogTypeRepositoryMock = new Mock<ICatalogTypeRepository>();
            _loggerMock = new Mock<ILogger<BaseDataService<ApplicationDbContext>>>();
            _dbContextWrapperMock = new Mock<IDbContextWrapper<ApplicationDbContext>>();

            _catalogTypeService = new CatalogTypeService(_dbContextWrapperMock.Object, _loggerMock.Object, _catalogTypeRepositoryMock.Object);
        }

        [Fact]
        public async Task Add_Success()
        {
            // arrange
            var testResult = 1;

            var item = new CatalogType()
            {
                Type = It.IsAny<string>()
            };

            _catalogTypeRepositoryMock.Setup(s => s.Add(item)).ReturnsAsync(testResult);

            // act
            var result = await _catalogTypeService.Add(item);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task Add_Failed()
        {
            // arrange
            var testResult = 0;

            var item = new CatalogType()
            {
                Type = It.IsAny<string>()
            };

            _catalogTypeRepositoryMock.Setup(s => s.Add(item)).ReturnsAsync(testResult);

            // act
            var result = await _catalogTypeService.Add(item);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task GetByTypeByPageAsync_Success()
        {
            // arrange
            var testPageIndex = 0;
            var testPageSize = 4;
            var testTotalCount = 12;

            var pagingPaginatedItemsSuccess = new PaginatedItems<CatalogType>()
            {
                Data = new List<CatalogType>()
                {
                    new CatalogType()
                    {
                        Type = "TestType",
                    },
                },
                TotalCount = testTotalCount,
            };

            var catalogTypeSuccess = new CatalogType()
            {
                Type = "TestType"
            };

            var catalogTypeDtoSuccess = new CatalogTypeDto()
            {
                Type = "TestType"
            };

            _catalogTypeRepositoryMock.Setup(s => s.GetByTypeByPageAsync(
                               It.Is<int>(i => i == testPageIndex), It.Is<int>(i => i == testPageSize))).ReturnsAsync(pagingPaginatedItemsSuccess);

            // act
            var result = await _catalogTypeService.GetByTypeByPageAsync(testPageIndex, testPageSize);

            // assert
            result.Should().BeEquivalentTo(pagingPaginatedItemsSuccess);
        }

        [Fact]
        public async Task GetByTypeByPageAsync_Failed()
        {
            // arrange
            var testPageIndex = 1000;
            var testPageSize = 10000;
            PaginatedItems<CatalogType> item = null!;

            _catalogTypeRepositoryMock.Setup(s => s.GetByTypeByPageAsync(
                                              It.Is<int>(i => i == testPageIndex), It.Is<int>(i => i == testPageSize))).ReturnsAsync(item);

            // act
            var result = await _catalogTypeService.GetByTypeByPageAsync(testPageIndex, testPageSize);

            // assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task Delete_Success()
        {
            // arrange
            var testResult = true;

            var id = It.IsAny<int>();

            _catalogTypeRepositoryMock.Setup(s => s.Delete(id)).ReturnsAsync(testResult);

            // act
            var result = await _catalogTypeService.Delete(id);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task Delete_Failed()
        {
            // arrange
            var testResult = false;

            var id = It.IsAny<int>();

            _catalogTypeRepositoryMock.Setup(s => s.Delete(id)).ReturnsAsync(testResult);

            // act
            var result = await _catalogTypeService.Delete(id);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task Update_Success()
        {
            // arrange
            var testResult = 1;

            var item = new CatalogType()
            {
                Type = It.IsAny<string>()
            };

            _catalogTypeRepositoryMock.Setup(s => s.Update(item)).ReturnsAsync(testResult);

            // act
            var result = await _catalogTypeService.Update(item);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task Update_Failed()
        {
            // arrange
            var testResult = 0;

            var item = new CatalogType()
            {
                Type = It.IsAny<string>()
            };

            _catalogTypeRepositoryMock.Setup(s => s.Update(item)).ReturnsAsync(testResult);

            // act
            var result = await _catalogTypeService.Update(item);

            // assert
            result.Should().Be(testResult);
        }
    }
}
