using System.Text.Json.Nodes;
using Ingresso.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Ingresso.Application.Services
{
    public class RecaptchaService : IRecaptchaService
    {
        private readonly string _googleRecaptchaEndpoint;
        private readonly string _recaptchaSecretKey;

        public RecaptchaService(IConfiguration configuration)
        {
            _recaptchaSecretKey = configuration["MySettings:RecaptchaSecretKey"];
            _googleRecaptchaEndpoint = configuration["MySettings:GoogleRecaptchaUrl"];
        }

        public async Task<ResultService> ValidateRecaptchaAsync(string recaptchaToken)
        {
            if (string.IsNullOrWhiteSpace(recaptchaToken))
                return ResultService.Fail("Token vazio ou inválido.");

            var query = $"?secret={_recaptchaSecretKey}&response={recaptchaToken}";
            var url = _googleRecaptchaEndpoint + query;

            try
            {
                var response = await HttpClientFactory.Instance.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return ResultService.Fail($"Erro ao validar o reCAPTCHA. Código de status: {response.StatusCode}");

                var json = JsonNode.Parse(await response.Content.ReadAsStringAsync());

                if ((bool)json["success"])
                    return ResultService.Ok(json);

                return ResultService.Fail(json["error-codes"].ToString() ?? "Erro desconhecido");
            }
            catch (Exception ex)
            {
                return ResultService.Fail(ex.Message);
            }
        }

    }

    public static class HttpClientFactory
    {
        public static readonly HttpClient Instance = new HttpClient();
    }
}
