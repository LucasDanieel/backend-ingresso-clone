using Ingresso.Application.DTOs.CinemaRoomDTOs;

namespace Ingresso.Application.Services.Interfaces
{
    public interface ICinemaRoomService
    {
        Task<ResultService> CreateAsync(CinemaRoomDTO roomDTO);
    }
}
