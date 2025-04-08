using Ingresso.Domain.Entities;
using Ingresso.Domain.Repository;
using Ingresso.Infra.Data.ContextDb;
using Microsoft.EntityFrameworkCore;

namespace Ingresso.Infra.Data.Repository
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly ApplicationDbContext _db;
        public CinemaRepository(ApplicationDbContext db) => _db = db;

        public async Task<Cinema> GetBySlugAsync(string slug)
        {
            return await _db.Cinemas.AsNoTracking()
                        .Include(x => x.Sessions)
                            .ThenInclude(x => x.Movie)
                        .Include(x=> x.CinemaRooms)
                        .FirstOrDefaultAsync(x => x.Slug == slug);
        }

        public async Task<ICollection<Cinema>> GetByCityIdAsync(int cityId)
        {
            return await _db.Cinemas.AsNoTracking().Where(x => x.CityId == cityId).ToListAsync();
        }

        public async Task CreateAsync(Cinema cinema)
        {
            _db.Cinemas.Add(cinema);
            await _db.SaveChangesAsync();
        }
    }
}
