using Ingresso.Domain.Entities;

namespace Ingresso.Domain.Repository
{
    public interface ICinemaRoomRepository
    {
        Task CreateAsync(CinemaRoom room);
    }
}
