using System;
using System.Threading.Tasks;
using CustomReCaptcha.Helpers.Interfaces;
using CustomReCaptcha.Models;
using CustomReCaptcha.Models.Enums;
using CustomReCaptcha.Services.Interfaces;
using Newtonsoft.Json;

namespace CustomReCaptcha.Services
{
    public class VerificationService : IVerificationService
    {
        private readonly IImageService imageService;
        private readonly IAudioService audioService;
        private readonly IClientService clientService;
        private readonly IStringHelper stringHelper;

        public VerificationService(IImageService imageService, 
            IClientService clientService, IStringHelper stringHelper, IAudioService audioService)
        {
            this.audioService = audioService;
            this.imageService = imageService;
            this.clientService = clientService;
            this.stringHelper = stringHelper;
        }

        public string Verify(string clientKey, string instance, string clientResponse)
        {
            var clientInfo = clientService.GetClient(clientKey);
            var item = clientService.GetClientValidation(clientKey, instance);
            if (item != null && item.Text == clientResponse)
            {
                var data = JsonConvert.SerializeObject(new VerificationResponse()
                {
                    Instance = instance,
                    ClientKey = clientKey,
                    DateTime = DateTime.UtcNow
                });

                item.Response = 
                    stringHelper.ToSafeBase64(
                        stringHelper.Encrypt(data, clientInfo.PrivateKey));

                return item.Response;
            }

            return null;
        }

        public VerificationDataModel Get(string clientKey, string instance, ValidationType type, string lang)
        {
            var text = GetVerificationText(clientKey, instance);
            switch (type)
            {
                case ValidationType.Image:
                    return new VerificationDataModel
                    {
                        Stream = imageService.Generate(text, lang),
                        ContentType = "image/png",
                        FileName = "image.png"
                    };

                case ValidationType.Audio:
                    return new VerificationDataModel
                    {
                        Stream = audioService.Generate(text, lang),
                        ContentType = "audio/wav",
                        FileName = "audio.wav"
                    };
                default:
                    throw new Exception("ValidationType not implemented");
            }
        }

        public void Reset(string clientKey, string instance)
        {
            clientService.ResetClientValidation(clientKey, instance);
        }

        private string GetVerificationText(string clientKey, string instance)
        {
            var item = clientService.GetClientValidation(clientKey, instance);
            return item?.Text ?? string.Empty;
        }
    }
}