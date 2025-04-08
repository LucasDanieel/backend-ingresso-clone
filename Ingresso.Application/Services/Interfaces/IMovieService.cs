using Ingresso.Application.DTOs.MovieDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ingresso.Application.Services.Interfaces
{
    public interface IMovieService
    {
        Task<ResultService<MovieDTO>> GetBySlugAsync(string slug);
        Task<ResultService<MovieDTO>> GetBySlugWithDescriptionAsync(string slug);
        Task<ResultService> CreateAsync(MovieDTO movieDTO, IFormFile PosterImage, IFormFile BannerImage);
        Task<ResultService> DeleteAsync(int movieId);
    }
}
