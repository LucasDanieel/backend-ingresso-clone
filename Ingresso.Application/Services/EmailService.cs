using brevo_csharp.Api;
using brevo_csharp.Model;
using Ingresso.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Ingresso.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _senderEmail;
        private readonly string _url;
        private readonly string _emailDirectory;

        public EmailService(IConfiguration config)
        {
            _senderEmail = config["BrevoApi:SenderEmail"];
            _url = config["MySettings:FrontEndUrl"];
            _emailDirectory = config["MySettings:EmailDirectory"];
        }

        public async System.Threading.Tasks.Task SendConfirmEmailAsync(string emailTo, string token)
        {
            string emailHtml = File.ReadAllText(_emailDirectory + "/confirm-email.html");
            emailHtml = emailHtml.Replace("{{frontendUrl}}", _url + "/minha-conta/confirmacao-de-email/" + token);

            await SendEmailAsync(emailTo, "📩 Sua conta na Ingresso-Clone.com está quase pronta!", emailHtml);
        }

        public async System.Threading.Tasks.Task SendVerificationCodeAsync(string emailTo, string code)
        {
            string emailHtml = File.ReadAllText(_emailDirectory + "/verification-code.html");
            emailHtml = emailHtml.Replace("{{code}}", code);

            await SendEmailAsync(emailTo, $"🔒 Seu código de verificação - {code}", emailHtml);
        }

        public async System.Threading.Tasks.Task SendEmailConfirmedAsync(string emailTo)
        {
            string emailHtml = File.ReadAllText(_emailDirectory + "/email-confirmed.html");
            await SendEmailAsync(emailTo, "😀 Email confirmado.", emailHtml);
        }

        private async System.Threading.Tasks.Task SendEmailAsync(string emailTo, string subject, string html)
        {
            var apiInstance = new TransactionalEmailsApi();
            SendSmtpEmailSender sender = new SendSmtpEmailSender("Lucas Ingresso Clone", _senderEmail);

            SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(emailTo, null);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(smtpEmailTo);

            try
            {
                var sendSmtpEmail = new SendSmtpEmail(sender, To, null, null, html, "TextContent", subject);
                CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
            }
            catch (Exception e)
            {
            }
        }

    }
}
