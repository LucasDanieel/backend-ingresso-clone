using Ingresso.Domain.Entities;
using Ingresso.Domain.Repository;
using Ingresso.Infra.Data.ContextDb;
using Microsoft.EntityFrameworkCore;

namespace Ingresso.Infra.Data.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ApplicationDbContext _db;
        public SessionRepository(ApplicationDbContext db) => _db = db;

        public async Task<ICollection<Session>> GetAsync()
        {
            return await _db.Sessions.ToListAsync();
        }

        public async Task CreateAsync(Session session)
        {
            _db.Sessions.Add(session);
            await _db.SaveChangesAsync();
        }
    }
}
