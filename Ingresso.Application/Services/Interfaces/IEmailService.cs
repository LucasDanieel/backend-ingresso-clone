namespace Ingresso.Application.Services.Interfaces
{
    public interface IEmailService
    {
        public Task SendConfirmEmailAsync(string emailTo, string token);
        public Task SendVerificationCodeAsync(string emailTo, string code);
        public Task SendEmailConfirmedAsync(string emailTo);
    }
}
