using AutoMapper;
using Ingresso.Application.DTOs.CinemaDTOs;
using Ingresso.Application.DTOs.Validations.CinemaValidations;
using Ingresso.Application.Services.Interfaces;
using Ingresso.Domain.Entities;
using Ingresso.Domain.Repository;

namespace Ingresso.Application.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaRepository _cinemaRepository;
        private readonly IMapper _mapper;
        public CinemaService(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }
        public async Task<ResultService<ICollection<CinemaDTO>>> GetByCityIdAsync(int cityId)
        {
            if (cityId <= 0)
                return ResultService.Fail<ICollection<CinemaDTO>>("Id da cidade deve ser informado");

            ICollection<Cinema> cinema = await _cinemaRepository.GetByCityIdAsync(cityId);

            if (cinema == null || cinema.Count == 0)
                return ResultService.Fail<ICollection<CinemaDTO>>("Cinemas não encontrados");

            ICollection<CinemaDTO> cinemaDTOs = _mapper.Map<ICollection<CinemaDTO>>(cinema);

            return ResultService.Ok(cinemaDTOs);
        }

        public async Task<ResultService<CinemaDTO>> GetBySlugAsync(string slug)
        {
            if (string.IsNullOrEmpty(slug))
                return ResultService.Fail<CinemaDTO>("Slug deve ser informado");

            Cinema cinema = await _cinemaRepository.GetBySlugAsync(slug);

            if (cinema == null)
                return ResultService.Fail<CinemaDTO>("Cinema não encontrado");

            CinemaDTO cinemaDTO = _mapper.Map<CinemaDTO>(cinema);

            return ResultService.Ok(cinemaDTO);
        }

        public async Task<ResultService<CinemaDTO>> CreateAsync(CinemaDTO cinemaDTO)
        {
            if (cinemaDTO == null)
                return ResultService.Fail<CinemaDTO>("Objeto deve ser informado");

            var valid = new CinemaDTOValidator().Validate(cinemaDTO);
            if(!valid.IsValid)
                return ResultService.RequestError<CinemaDTO>("Algum campo do objeto invalido", valid);

            cinemaDTO.LogoImage = "URL/LOGO/TESTE";
            cinemaDTO.BannerImage = "URL/BANNER/TESTE";

            Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);

            await _cinemaRepository.CreateAsync(cinema);

            cinemaDTO = _mapper.Map<CinemaDTO>(cinema);

            return ResultService.Ok(cinemaDTO);
        }

    }
}
