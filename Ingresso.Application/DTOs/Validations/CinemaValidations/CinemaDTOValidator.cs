using FluentValidation;
using Ingresso.Application.DTOs.CinemaDTOs;

namespace Ingresso.Application.DTOs.Validations.CinemaValidations
{
    public class CinemaDTOValidator : AbstractValidator<CinemaDTO>
    {
        public CinemaDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome do cinema deve ser informado");
            RuleFor(x => x.Street).NotEmpty().WithMessage("Nome da rua deve ser informado");
            RuleFor(x => x.Number).NotEmpty().WithMessage("Numero da rua deve ser informado");
            RuleFor(x => x.Neighborhood).NotEmpty().WithMessage("Nome do bairro deve ser informado");
            RuleFor(x => x.CityName).NotEmpty().WithMessage("Nome da cidade deve ser informado");
            RuleFor(x => x.Slug).NotEmpty().WithMessage("Slug do cinema deve ser informado");
            RuleFor(x => x.CityId).NotEmpty().WithMessage("Id da cidade deve ser informado");
        }
    }
}
