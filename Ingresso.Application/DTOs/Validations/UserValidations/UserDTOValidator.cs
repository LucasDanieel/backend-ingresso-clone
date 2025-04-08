using FluentValidation;
using Ingresso.Application.DTOs.UserDTOs;

namespace Ingresso.Application.DTOs.Validations.UserValidations
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome precisa ser informado");
            RuleFor(x => x.CPF).NotEmpty().WithMessage("CPF precisa ser informado");
            RuleFor(x => x.PhoneDdd).NotEmpty().WithMessage("Informe o ddd do telefone");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Informe o numero do telefone");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email precisa ser informado");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).WithMessage("Senha precisa ser informada");
            RuleFor(x => x.ReceiveNotification).Must(x => x == false || x == true).WithMessage("Informe as preferencias para receber notificações");
        }
    }
}
