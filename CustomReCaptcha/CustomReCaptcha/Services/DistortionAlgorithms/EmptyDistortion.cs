using System.Drawing;
using CustomReCaptcha.Services.Interfaces;

namespace CustomReCaptcha.Services.DistortionAlgorithms
{
    public class EmptyDistortion : IDistortionAlgorithm
    {
        public void Before(Graphics input)
        {
            
        }

        public void After(Graphics input)
        {
            
        }

        public Bitmap Common(Bitmap input)
        {
            return input;
        }
    }
}