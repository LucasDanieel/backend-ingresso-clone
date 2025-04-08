using Ingresso.Domain.Entities;
using Ingresso.Domain.Repository;
using Ingresso.Infra.Data.ContextDb;
using Microsoft.EntityFrameworkCore;

namespace Ingresso.Infra.Data.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _db;
        public CityRepository(ApplicationDbContext db) => _db = db;

        public async Task<City> GetByNameAsync(string name)
        {
            return await _db.Cities.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);
        }
        
        public async Task<City> GetBySlugAsync(string slug)
        {
            return await _db.Cities.AsNoTracking().FirstOrDefaultAsync(x => x.Slug == slug);
        }

        public async Task CreateAsync(City city)
        {
            _db.Cities.Add(city);
            await _db.SaveChangesAsync();
        }
    }
}
