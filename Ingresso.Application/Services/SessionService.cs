using AutoMapper;
using Ingresso.Application.DTOs.SessionDTOs;
using Ingresso.Application.DTOs.Validations.SessionValidations;
using Ingresso.Application.Services.Interfaces;
using Ingresso.Domain.Entities;
using Ingresso.Domain.Repository;

namespace Ingresso.Application.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IMapper _mapper;
        public SessionService(ISessionRepository sessionRepository, IMapper mapper)
        {
            _sessionRepository = sessionRepository;
            _mapper = mapper;   

        }

        public async Task<ResultService<ICollection<SessionDTO>>> GetAsync()
        {
            var sessions = await _sessionRepository.GetAsync();

            return ResultService.Ok(_mapper.Map<ICollection<SessionDTO>>(sessions));
        }

        public async Task<ResultService> CreateAsync(SessionDTO sessionDTO)
        {
            if (sessionDTO == null)
                return ResultService.Fail("Objeto deve ser informado");

            var valid = new SessionDTOValidator().Validate(sessionDTO);
            if(!valid.IsValid)
                return ResultService.RequestError("Campos do objeto invalidos", valid);

            Session session = _mapper.Map<Session>(sessionDTO);  

            await _sessionRepository.CreateAsync(session);

            return ResultService.Ok(_mapper.Map<SessionDTO>(session));
        }

    }
}
