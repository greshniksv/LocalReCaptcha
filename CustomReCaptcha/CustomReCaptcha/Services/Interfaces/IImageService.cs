using System.IO;

namespace CustomReCaptcha.Services.Interfaces
{
    public interface IImageService
    {
        Stream Generate(string captcha, string lang);
    }
}