using FluentValidation;
using Ingresso.Application.DTOs.MovieDTOs;

namespace Ingresso.Application.DTOs.Validations.MovieValidations
{
    public class MovieDTOValidator : AbstractValidator<MovieDTO>
    {
        public MovieDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome do filme precisa ser informado");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Genero do filme precisa ser informado");
            RuleFor(x => x.PremiereDate).Must(x => x >= DateOnly.MinValue && x <= DateOnly.MaxValue).WithMessage("Data de estreia precisa ser informado");
            RuleFor(x => x.Slug).NotEmpty().WithMessage("Slug do filme precisa ser informado");
            RuleFor(x => x.MovieDescriptionDTO.Description).NotEmpty().WithMessage("Descrição do filme deve ser informado");
            RuleFor(x => x.MovieDescriptionDTO.OriginalName).NotEmpty().WithMessage("Nome original do filme deve ser informado");
        }
    }
}
