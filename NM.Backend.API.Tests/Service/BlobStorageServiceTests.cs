using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Logging;
using Moq;
using NM.Backend.API.Helper;
using NM.Backend.API.Service;
using PropertyAPI.Domain;
using System.Text.Json;
using Xunit;
using Response = Azure.Response;

namespace NM.Backend.API.Tests.Service
{
    public class BlobStorageServiceTests
    {
        private readonly Mock<IConfigurationWrapper> _mockConfigurationWrapper;
        private readonly Mock<ILogger<BlobStorageService>> _mockLogger;
        private readonly BlobStorageService _blobStorageService;

        public BlobStorageServiceTests()
        {
            _mockConfigurationWrapper = new Mock<IConfigurationWrapper>();
            _mockLogger = new Mock<ILogger<BlobStorageService>>();
            _blobStorageService = new BlobStorageService(_mockConfigurationWrapper.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetPropertyDataAsync_ThrowsException_WhenBlobDownloadFails()
        {
            // Arrange
            var blobStorageUri = "https://example.com/blob";
            var sasToken = "sasToken";

            _mockConfigurationWrapper.Setup(c => c.GetValue<string>("BlobStorageSettings:BlobStorageUri")).Returns(blobStorageUri);
            _mockConfigurationWrapper.Setup(c => c.GetValue<string>("BlobStorageSettings:SASToken")).Returns(sasToken);

            var mockBlobClient = new Mock<BlobClient>(new Uri(blobStorageUri), new AzureSasCredential(sasToken));
            mockBlobClient.Setup(b => b.DownloadContentAsync(It.IsAny<CancellationToken>())).ThrowsAsync(new Exception("Blob download failed"));

            // Act & Assert
            await Assert.ThrowsAsync<RequestFailedException>(() => _blobStorageService.GetPropertyDataAsync());
        }
    }
}
