using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NM.Backend.API.Controllers;
using NM.Backend.API.Resource;
using PropertyAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NM.Backend.API.Tests.Controller
{
    public class PropertyControllerTests
    {
        private readonly Mock<IPropertyResource> _mockPropertyResource;
        private readonly PropertyController _propertyController;

        public PropertyControllerTests()
        {
            _mockPropertyResource = new Mock<IPropertyResource>();
            _propertyController = new PropertyController(_mockPropertyResource.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithListOfProperties()
        {
            // Arrange
            var properties = new List<PropertyDto>
            {
                new PropertyDto { PropertyId = "1", PropertyName = "Property1" },
                new PropertyDto { PropertyId = "2", PropertyName = "Property2" }
            };
            _mockPropertyResource.Setup(pr => pr.GetPropertyDataFromBlobStorageAsync()).ReturnsAsync(properties);

            // Act
            var result = await _propertyController.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnProperties = Assert.IsType<List<PropertyDto>>(okResult.Value);
            Assert.Equal(2, returnProperties.Count);
        }

        [Fact]
        public async Task GetAll_ReturnsNotFound_WhenNoPropertiesFound()
        {
            // Arrange
            _mockPropertyResource.Setup(pr => pr.GetPropertyDataFromBlobStorageAsync()).ReturnsAsync((IEnumerable<PropertyDto>)null);

            // Act
            var result = await _propertyController.GetAll();

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
