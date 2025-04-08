using AutoMapper;
using Ingresso.Application.DTOs.CityDTOs;
using Ingresso.Application.DTOs.Validations.CityValidations;
using Ingresso.Application.Services.Interfaces;
using Ingresso.Domain.Entities;
using Ingresso.Domain.Repository;

namespace Ingresso.Application.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<CityDTO>> GetByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                return ResultService.Fail<CityDTO>("O nome da cidade deve ser informado");

            City city = await _cityRepository.GetByNameAsync(name);

            if (city == null)
                return ResultService.Fail<CityDTO>("A cidade não foi encontrada");

            CityDTO cityDTO = _mapper.Map<CityDTO>(city);

            return ResultService.Ok(cityDTO);
        }
        
        public async Task<ResultService<CityDTO>> GetBySlugAsync(string slug)
        {
            if (string.IsNullOrEmpty(slug))
                return ResultService.Fail<CityDTO>("O nome da cidade deve ser informado");

            City city = await _cityRepository.GetBySlugAsync(slug);

            if (city == null)
                return ResultService.Fail<CityDTO>("A cidade não foi encontrada");

            CityDTO cityDTO = _mapper.Map<CityDTO>(city);

            return ResultService.Ok(cityDTO);
        }

        public async Task<ResultService> CreateAsync(CityDTO cityDTO)
        {
            if (cityDTO == null)
                return ResultService.Fail("A cidade não foi encontrada");

            var valid = new CityDTOValidator().Validate(cityDTO);
            if (!valid.IsValid)
                return ResultService.RequestError("Campos invalidos", valid);

            City city = _mapper.Map<City>(cityDTO);

            await _cityRepository.CreateAsync(city);

            return ResultService.Ok(_mapper.Map<CityDTO>(city));
        }

    }
}
