using System.Collections.Generic;
using System.Linq;

namespace CustomReCaptcha.Models
{
    public class CaptchaResponse
    {
        private readonly List<string> errorCodes = new List<string>();

        public bool Success => !errorCodes.Any();

        public string[] ErrorCodes => errorCodes.ToArray();

        public void AddError(string error)
        {
            errorCodes.Add(error);
        }
    }
}