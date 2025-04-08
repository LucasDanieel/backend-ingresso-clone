using Ingresso.Application.DTOs.SessionDTOs;

namespace Ingresso.Application.Services.Interfaces
{
    public interface ISessionService
    {
        Task<ResultService<ICollection<SessionDTO>>> GetAsync();
        Task<ResultService> CreateAsync(SessionDTO sessionDTO);
    }
}
