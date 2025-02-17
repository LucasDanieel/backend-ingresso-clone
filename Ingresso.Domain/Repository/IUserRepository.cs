using Ingresso.Domain.Entities;

namespace Ingresso.Domain.Repository
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByCPFAsync(string cpf);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByCPFOrEmailAsync(string? cpf, string? email);
        Task CreateAsync(User user);
        Task<bool> UpdateUserAsync(User user);
    }
}
