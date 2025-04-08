using Ingresso.Application.DTOs.CinemaDTOs;

namespace Ingresso.Application.Services.Interfaces
{
    public interface ICinemaService
    {
        Task<ResultService<CinemaDTO>> GetBySlugAsync(string slug);
        Task<ResultService<ICollection<CinemaDTO>>> GetByCityIdAsync(int cityId);
        Task<ResultService<CinemaDTO>> CreateAsync(CinemaDTO cinemaDTO);

    }
}
