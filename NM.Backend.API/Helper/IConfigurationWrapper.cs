namespace NM.Backend.API.Helper
{
    public interface IConfigurationWrapper
    {
        T GetValue<T>(string value);
    }
}
