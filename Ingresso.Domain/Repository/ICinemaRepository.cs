using Ingresso.Domain.Entities;

namespace Ingresso.Domain.Repository
{
    public interface ICinemaRepository
    {
        Task<Cinema> GetBySlugAsync(string slug);
        Task<ICollection<Cinema>> GetByCityIdAsync(int cityId);
        Task CreateAsync(Cinema cinema);
    }
}
