using System.Drawing;

namespace CustomReCaptcha.Services.Interfaces
{
    public interface IDistortionAlgorithm
    {
        void Before(Graphics input);
        void After(Graphics input);
        Bitmap Common(Bitmap input);
    }
}