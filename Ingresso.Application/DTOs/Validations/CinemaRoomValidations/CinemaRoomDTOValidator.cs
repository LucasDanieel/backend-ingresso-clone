
using FluentValidation;
using Ingresso.Application.DTOs.CinemaRoomDTOs;

namespace Ingresso.Application.DTOs.Validations.CinemaRoomValidations
{
    class CinemaRoomDTOValidator : AbstractValidator<CinemaRoomDTO>
    {
        public CinemaRoomDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome da sala deve ser informado");
            RuleFor(x => x.CinemaId).Must(x => x > 0).WithMessage("Id do cinema deve ser informado");
        }
    }
}
