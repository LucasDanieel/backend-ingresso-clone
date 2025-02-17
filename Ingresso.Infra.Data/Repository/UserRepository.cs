using Ingresso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Ingresso.Domain.Repository;
using Ingresso.Infra.Data.ContextDb;

namespace Ingresso.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) => _db = db;

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByCPFAsync(string cpf)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.CPF == cpf);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
        
        public async Task<User> GetByCPFOrEmailAsync(string? cpf, string? email)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.CPF == cpf || x.Email == email);
        }

        public async Task CreateAsync(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }
        
        public async Task<bool> UpdateUserAsync(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();

            return true;
        }

    }
}
