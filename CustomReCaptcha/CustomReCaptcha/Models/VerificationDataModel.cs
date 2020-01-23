using System.IO;

namespace CustomReCaptcha.Models
{
    public class VerificationDataModel
    {
        public Stream Stream { get; set; }

        public string ContentType { get; set; }

        public string FileName { get; set; }
    }
}