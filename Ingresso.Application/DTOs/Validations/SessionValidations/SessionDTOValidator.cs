using FluentValidation;
using Ingresso.Application.DTOs.SessionDTOs;

namespace Ingresso.Application.DTOs.Validations.SessionValidations
{
    public class SessionDTOValidator : AbstractValidator<SessionDTO>
    {
        public SessionDTOValidator()
        {
            RuleFor(x => x.Date).Must(x => x >= DateTime.MinValue || x <= DateTime.MaxValue).WithMessage("Data da sessão deve ser informada");
            RuleFor(x => x.Type).Must(x => x.Count > 0).WithMessage("Tipo da sessão deve ser informado");
            RuleFor(x => x.CinemaId).Must(x => x > 0).WithMessage("Id do cinema deve ser informado");
            RuleFor(x => x.MovieId).Must(x => x > 0).WithMessage("Id do filme deve ser informado");
            RuleFor(x => x.CinemaRoomId).Must(x => x > 0).WithMessage("Id da sala do cinema deve ser informado");
        }
    }
}
