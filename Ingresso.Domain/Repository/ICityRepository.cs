using Ingresso.Domain.Entities;

namespace Ingresso.Domain.Repository
{
    public interface ICityRepository
    {
        Task<City> GetByNameAsync(string name);
        Task<City> GetBySlugAsync(string slug);
        Task CreateAsync(City city);
    }
}
