
namespace Ingresso.Application.Caching.Interfaces
{
    public interface ICachingService
    {
        Task<string> GetAsync(string key);
        Task PostAsync(string key, string value);
        Task DeleteAsync(string key);
    }
}
