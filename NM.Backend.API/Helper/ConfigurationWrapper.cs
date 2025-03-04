namespace NM.Backend.API.Helper
{
    public class ConfigurationWrapper : IConfigurationWrapper
    {
        private readonly IConfiguration _configuration;

        public ConfigurationWrapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public T GetValue<T>(string value) => _configuration.GetValue<T>(value);
    }
}
