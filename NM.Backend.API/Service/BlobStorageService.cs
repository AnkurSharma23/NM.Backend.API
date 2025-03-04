using Azure.Storage.Blobs;
using NM.Backend.API.Helper;
using PropertyAPI.Domain;
using System.Text.Json;

namespace NM.Backend.API.Service
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly IConfigurationWrapper _configurationWrapper;
        private readonly ILogger<BlobStorageService> _logger;

        public BlobStorageService(IConfigurationWrapper configurationWrapper, ILogger<BlobStorageService> logger)
        {
            _configurationWrapper = configurationWrapper;
            _logger = logger;
        }

        Property[]? listOfProperties = [];

        public async Task<IEnumerable<Property>> GetPropertyDataAsync()
        {
            try
            {
                var blobStorageURI = _configurationWrapper.GetValue<string>("BlobStorageSettings:BlobStorageUri") ?? string.Empty;
                var blobStorageSASToken = _configurationWrapper.GetValue<string>("BlobStorageSettings:SASToken") ?? string.Empty;

                var containerClient = new BlobClient(new Uri(blobStorageURI), new Azure.AzureSasCredential(blobStorageSASToken));
                var blobResponse = await containerClient.DownloadContentAsync();

                listOfProperties = JsonSerializer.Deserialize<Property[]>(blobResponse.Value.Content);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching the blob : {0}", ex.Message);
                throw;
            }

            return listOfProperties ?? Enumerable.Empty<Property>();
        }
    }
}
