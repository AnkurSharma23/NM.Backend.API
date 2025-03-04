using Moq;
using NM.Backend.API.Resource;
using NM.Backend.API.Service;
using PropertyAPI.Models;
using Microsoft.Extensions.Logging;
using Xunit;
using PropertyAPI.Domain;

namespace NM.Backend.API.Tests.Resource
{
    public class PropertyResourceTests
    {
        private readonly Mock<IBlobStorageService> _mockBlobStorageService;
        private readonly Mock<ILogger<PropertyResource>> _mockLogger;
        private readonly PropertyResource _propertyResource;

        public PropertyResourceTests()
        {
            _mockBlobStorageService = new Mock<IBlobStorageService>();
            _mockLogger = new Mock<ILogger<PropertyResource>>();
            _propertyResource = new PropertyResource(_mockBlobStorageService.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetPropertyDataFromBlobStorageAsync_ReturnsPropertyData_WhenBlobResponseIsNotNull()
        {
            // Arrange
            var propertyList = new List<Property>
            {
                new Property { PropertyId = "1", PropertyName = "Property1" },
                new Property { PropertyId = "2", PropertyName = "Property2" }
            };
            _mockBlobStorageService.Setup(s => s.GetPropertyDataAsync()).ReturnsAsync(propertyList);

            // Act
            var result = await _propertyResource.GetPropertyDataFromBlobStorageAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetPropertyDataFromBlobStorageAsync_ReturnsNull_WhenBlobResponseIsNull()
        {
            // Arrange
            _mockBlobStorageService.Setup(s => s.GetPropertyDataAsync()).ReturnsAsync((IEnumerable<Property>?)null);

            // Act
            var result = await _propertyResource.GetPropertyDataFromBlobStorageAsync();

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetPropertyDataFromBlobStorageAsync_ThrowsException_WhenBlobServiceThrowsException()
        {
            // Arrange
            _mockBlobStorageService.Setup(s => s.GetPropertyDataAsync()).ThrowsAsync(new Exception("Blob service error"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _propertyResource.GetPropertyDataFromBlobStorageAsync());
        }
    }
}
