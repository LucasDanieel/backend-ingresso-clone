using Ingresso.Domain.Entities;

namespace Ingresso.Domain.Repository
{
    public interface IMovieRepository
    {
        Task<Movie> GetByIdAsync(int id);
        //Task<Movie> TestGetByIdAsync(int id);
        Task<Movie> GetBySlugAsync(string slug);
        Task<Movie> GetBySlugWithDescriptionAsync(string slug);
        Task<bool> MovieExistAsync(string name, string slug);
        Task CreateAsync(Movie movie);
        Task DeleteAsync(Movie movie);
    }
}
