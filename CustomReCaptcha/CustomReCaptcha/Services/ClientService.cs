using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CustomReCaptcha.Helpers.Interfaces;
using CustomReCaptcha.Models;
using CustomReCaptcha.Services.Interfaces;
using Newtonsoft.Json;

namespace CustomReCaptcha.Services
{
    public class ClientService : IClientService
    {
        private readonly IAppSettingsHelper appSettingsHelper;
        private readonly IStringHelper stringHelper;
        private readonly Dictionary<string, ClientItem> clientItems;
        private readonly Dictionary<string, List<ValidationItem>> validationItems;
        private readonly string pathToFile;

        public ClientService(IHostingHelper hostingHelper, IStringHelper stringHelper,
            IAppSettingsHelper appSettingsHelper)
        {
            this.appSettingsHelper = appSettingsHelper;
            this.stringHelper = stringHelper;
            validationItems = new Dictionary<string, List<ValidationItem>>();
            pathToFile = hostingHelper.GetRootPath("App_Data\\clients.json");

            using (TextReader reader = new StreamReader(pathToFile, Encoding.UTF8))
            {
                clientItems = 
                    JsonConvert.DeserializeObject<Dictionary<string, ClientItem>>(reader.ReadToEnd());
            }
        }

        public ClientItem GetClient(string clientKey)
        {
            if (clientItems.ContainsKey(clientKey))
            {
                return clientItems[clientKey];
            }

            return null;
        }

        public ValidationItem GetClientValidation(string clientKey, string instance)
        {
            if (validationItems.ContainsKey(clientKey) && !string.IsNullOrEmpty(instance))
            {
                return validationItems[clientKey].FirstOrDefault(x=>x.Instance == instance);
            }

            if (string.IsNullOrEmpty(instance))
            {
                instance = Guid.NewGuid().ToString();
            }

            return ResetClientValidation(clientKey, instance);
        }

        public ValidationItem ResetClientValidation(string clientKey, string instance)
        {
            if (validationItems.ContainsKey(clientKey))
            {
                validationItems[clientKey].RemoveAll(
                    x => x.Instance == instance);
            }
            else
            {
                validationItems.Add(clientKey, new List<ValidationItem>());
            }

            ValidationItem item = new ValidationItem
            {
                Text = stringHelper.RandomNumber(7),
                Instance = instance
            };

            validationItems[clientKey].Add(item);
            return item;
        }

        public CaptchaResponse Verify(string privateKey, string secret)
        {
            var response = new CaptchaResponse();
            var client = clientItems.FirstOrDefault(x 
                => x.Value.PrivateKey == privateKey).Value;
            if (client == null)
            {
                response.AddError("Validation fail #001");
            }
            else
            {
                VerificationResponse verificationResponse = null;
                try
                {
                    var secretReal = stringHelper.FromSafeBase64(secret);
                    var data = stringHelper.Decrypt(secretReal, privateKey);
                    verificationResponse = JsonConvert.DeserializeObject<VerificationResponse>(data);

                    if (!validationItems.ContainsKey(client.Id))
                    {
                        response.AddError("Validation fail #007");
                    }

                    if (validationItems.ContainsKey(client.Id) && validationItems[client.Id].FirstOrDefault(
                            x => x.Instance == verificationResponse.Instance)?.Response == secret)
                    {
                        // success
                    }
                    else
                    {
                        response.AddError("Validation fail #101");
                    }
                }
                catch (Exception)
                {
                    response.AddError("Validation fail #404");
                }
            }

            return response;
        }

        public ClientItem GenerateNewClient(string password)
        {
            var validPassword = appSettingsHelper.Get("Password");
            if (validPassword != password)
            {
                return null;
            }

            ClientItem item = new ClientItem
            {
                Id = Guid.NewGuid().ToString(),
                PrivateKey = stringHelper.RandomString(70, 120)
            };

            clientItems.Add(item.Id, item);

            FileInfo fileInfo = new FileInfo(pathToFile);
            using (TextWriter writer = new StreamWriter(fileInfo.Open(FileMode.Truncate), Encoding.UTF8))
            {
                writer.Write(JsonConvert.SerializeObject(clientItems, Formatting.Indented));
            }

            return item;
        }
    }
}