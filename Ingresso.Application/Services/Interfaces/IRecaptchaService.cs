namespace Ingresso.Application.Services.Interfaces
{
    public interface IRecaptchaService
    {
        Task<ResultService> ValidateRecaptchaAsync(string recaptchaToken);
    }
}
