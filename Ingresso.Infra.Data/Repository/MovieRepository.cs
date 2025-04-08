using Ingresso.Domain.Entities;
using Ingresso.Domain.Repository;
using Ingresso.Infra.Data.ContextDb;
using Microsoft.EntityFrameworkCore;

namespace Ingresso.Infra.Data.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _db;
        public MovieRepository(ApplicationDbContext db) => _db = db;

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _db.Movies.Include(x => x.MovieDescription).FirstOrDefaultAsync(x => x.Id == id);
        }
        
        //public async Task<Movie> TestGetByIdAsync(int id)
        //{
        //    var bond = _db.Cities.Where(x => x.Id != id).AsQueryable();

        //    var sessions = await _db.Sessions.Include(x => x.Cinema).Include(x => x.Movie)
        //        .Where(x => bond.Any(b => x.Cinema.CityId == b.Id))
        //        .ToListAsync();
        //}
        
        public async Task<Movie> GetBySlugAsync(string slug)
        {
            return await _db.Movies.AsNoTracking().FirstOrDefaultAsync(x => x.Slug == slug);
        }
        
        public async Task<Movie> GetBySlugWithDescriptionAsync(string slug)
        {
            return await _db.Movies.Include(x => x.MovieDescription).AsNoTracking().FirstOrDefaultAsync(x => x.Slug == slug);
        }
        
        public async Task<bool> MovieExistAsync(string name, string slug)
        {
            Movie movieExist = await _db.Movies.AsNoTracking()
                .Where(x => x.Slug == slug || x.Name == name)
                .Select(x => new Movie(x.Id))
                .FirstOrDefaultAsync();

            if (movieExist != null)
                return true;

            return false;
        }

        public async Task CreateAsync(Movie movie)
        {
            _db.Movies.Add(movie);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Movie movie)
        {
            _db.Movies.Remove(movie);
            await _db.SaveChangesAsync();
        }
    }
}
