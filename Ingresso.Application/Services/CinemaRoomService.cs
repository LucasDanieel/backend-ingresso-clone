using AutoMapper;
using Ingresso.Application.DTOs.CinemaRoomDTOs;
using Ingresso.Application.DTOs.Validations.CinemaRoomValidations;
using Ingresso.Application.Services.Interfaces;
using Ingresso.Domain.Entities;
using Ingresso.Domain.Repository;

namespace Ingresso.Application.Services
{
    public class CinemaRoomService : ICinemaRoomService
    {
        private readonly ICinemaRoomRepository _cinemaRoomRepository;
        private readonly IMapper _mapper;
        public CinemaRoomService(ICinemaRoomRepository cinemaRoomRepository, IMapper mapper)
        {
            _cinemaRoomRepository = cinemaRoomRepository;
            _mapper = mapper;
        }

        public async Task<ResultService> CreateAsync(CinemaRoomDTO roomDTO)
        {
            if (roomDTO == null)
                return ResultService.Fail("Objeto deve ser informado");

            var valid = new CinemaRoomDTOValidator().Validate(roomDTO);
            if(!valid.IsValid)
                return ResultService.RequestError("Algum campo do objeto invalido", valid);

            CinemaRoom room = _mapper.Map<CinemaRoom>(roomDTO);

            await _cinemaRoomRepository.CreateAsync(room);

            return ResultService.Ok("Sala criada");
        }
    }
}
