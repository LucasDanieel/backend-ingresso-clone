using Microsoft.AspNetCore.Http;

namespace Ingresso.Domain.Integrations
{
    public interface ISaveCloudinary
    {
        Task<string> SaveImageAsync(string slug, string publicId, IFormFile file);
        Task DeleteMovieImageAsync(string[] publicId);
    }
}
