using NM.Backend.API.Converters;
using NM.Backend.API.Service;
using PropertyAPI.Models;

namespace NM.Backend.API.Resource
{
    public class PropertyResource : IPropertyResource
    {
        private readonly IBlobStorageService _blobStorageService;
        private readonly ILogger<PropertyResource> _logger;

        public PropertyResource(IBlobStorageService blobStorageService, ILogger<PropertyResource> logger)
        {
            _blobStorageService = blobStorageService;
            _logger = logger;
        }

        public async Task<IEnumerable<PropertyDto>?> GetPropertyDataFromBlobStorageAsync()
        {
            try
            {
                var blobResponse = await _blobStorageService.GetPropertyDataAsync();

                if (blobResponse == null)
                {
                    _logger.LogError("Error fetching the blob");
                    return null;
                }

                var propertyData = blobResponse.Select(Mapper.Map);
                return propertyData;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching the blob : {0}", ex.Message);
                throw;
            }
        }
    }
}
