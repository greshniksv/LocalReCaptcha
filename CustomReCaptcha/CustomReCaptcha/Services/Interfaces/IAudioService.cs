using System.IO;

namespace CustomReCaptcha.Services.Interfaces
{
    public interface IAudioService
    {
        Stream Generate(string data, string lang);
    }
}