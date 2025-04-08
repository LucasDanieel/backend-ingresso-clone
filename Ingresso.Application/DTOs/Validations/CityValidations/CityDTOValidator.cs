using FluentValidation;
using Ingresso.Application.DTOs.CityDTOs;

namespace Ingresso.Application.DTOs.Validations.CityValidations
{
    public class CityDTOValidator : AbstractValidator<CityDTO>
    {
        public CityDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O nome da cidade deve ser informado");
            RuleFor(x => x.State).NotEmpty().WithMessage("O nome do estado deve ser informado");
            RuleFor(x => x.UF).NotEmpty().WithMessage("O codigo do estado deve ser informado");
            RuleFor(x => x.Slug).NotEmpty().WithMessage("O slug deve ser informado");
        }
    }
}
