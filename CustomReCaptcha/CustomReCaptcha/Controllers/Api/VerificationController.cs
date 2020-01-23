using System.Web.Http;
using CustomReCaptcha.Services.Interfaces;

namespace CustomReCaptcha.Controllers.Api
{
    public class VerificationController : ApiController
    {
        private readonly IVerificationService verificationService;
        private readonly IClientService clientService;

        public VerificationController(IVerificationService verificationService,
            IClientService clientService)
        {
            this.verificationService = verificationService;
            this.clientService = clientService;
        }

        [HttpGet]
        public IHttpActionResult InitializeClient(string clientKey)
        {
            var item = clientService.GetClientValidation(clientKey, string.Empty);
            return Json(new { Instance = item.Instance });
        }

        [HttpPost]
        public IHttpActionResult Validate(string clientKey, string instance, string clientResponse)
        {
            var result = verificationService.Verify(clientKey, instance, clientResponse);
            if (!string.IsNullOrEmpty(result))
            {
                return Json(new { success = true, data = result });
            }

            return Json(new { success = false });
        }
    }
}
