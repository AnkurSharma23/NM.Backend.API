using PropertyAPI.Models;

namespace NM.Backend.API.Resource
{
    public interface IPropertyResource
    {
        Task<IEnumerable<PropertyDto>?> GetPropertyDataFromBlobStorageAsync();
    }
}
