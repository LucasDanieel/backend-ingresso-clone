using Ingresso.Domain.Entities;

namespace Ingresso.Domain.Repository
{
    public interface ISessionRepository
    {
        Task<ICollection<Session>> GetAsync();
        Task CreateAsync(Session session);
    }
}
