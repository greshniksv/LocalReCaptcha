using CustomReCaptcha.Models;
using CustomReCaptcha.Models.Enums;

namespace CustomReCaptcha.Services.Interfaces
{
    public interface IVerificationService
    {
        string Verify(string clientKey, string instance, string clientResponse);

        VerificationDataModel Get(string clientKey, string instance, ValidationType type, string lang);

        void Reset(string clientKey, string instance);
    }
}