using PropertyAPI.Domain;

namespace NM.Backend.API.Service
{
    public interface IBlobStorageService
    {
        public Task<IEnumerable<Property>> GetPropertyDataAsync();
    }
}
