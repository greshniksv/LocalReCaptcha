using CustomReCaptcha.Models;

namespace CustomReCaptcha.Services.Interfaces
{
    public interface IClientService
    {
        ClientItem GetClient(string clientKey);

        ValidationItem GetClientValidation(string clientKey, string instance);

        ValidationItem ResetClientValidation(string clientKey, string instance);

        CaptchaResponse Verify(string privateKey, string secret);

        ClientItem GenerateNewClient(string password);
    }
}