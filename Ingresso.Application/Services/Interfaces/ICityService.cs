using Ingresso.Application.DTOs.CityDTOs;
using Ingresso.Domain.Entities;

namespace Ingresso.Application.Services.Interfaces
{
    public interface ICityService
    {
        public Task<ResultService<CityDTO>> GetByNameAsync(string name);
        public Task<ResultService<CityDTO>> GetBySlugAsync(string slug);
        public Task<ResultService> CreateAsync(CityDTO city);
    }
}
