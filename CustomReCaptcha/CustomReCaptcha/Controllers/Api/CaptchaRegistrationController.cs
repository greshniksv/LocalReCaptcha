using System.Net;
using System.Web.Http;
using CustomReCaptcha.Models;
using CustomReCaptcha.Services.Interfaces;

namespace CustomReCaptcha.Controllers.Api
{
    public class CaptchaRegistrationController : ApiController
    {
        private readonly IClientService clientService;

        public CaptchaRegistrationController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpPost]
        public IHttpActionResult Generate(string password)
        {
            ClientItem response = clientService.GenerateNewClient(password);
            if (response == null)
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }

            return Json(response);
        }
    }
}
