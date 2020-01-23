using System;

namespace CustomReCaptcha.Models
{
    public class VerificationResponse
    {
        public string ClientKey { get; set; }

        public string Instance { get; set; }

        public DateTime DateTime { get; set; }
    }
}