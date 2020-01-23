using System.IO;

namespace CustomReCaptcha.Services.Interfaces
{
    public interface IFrameworkService
    {
        Stream GetJavascript(string lang);
    }
}