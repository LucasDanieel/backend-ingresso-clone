
using Ingresso.Domain.Entities;
using Ingresso.Domain.Repository;
using Ingresso.Infra.Data.ContextDb;

namespace Ingresso.Infra.Data.Repository
{
    public class CinemaRoomRepository : ICinemaRoomRepository
    {
        private readonly ApplicationDbContext _db;
        public CinemaRoomRepository(ApplicationDbContext db) => _db = db;  
        
        public async Task CreateAsync(CinemaRoom room)
        {
            _db.CinemaRooms.Add(room);
            await _db.SaveChangesAsync();
        }
    }
}
