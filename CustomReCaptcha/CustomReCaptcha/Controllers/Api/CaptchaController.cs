using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using CustomReCaptcha.Models;
using CustomReCaptcha.Services.Interfaces;

namespace CustomReCaptcha.Controllers.Api
{
    public class CaptchaController : ApiController
    {
        private readonly IClientService clientService;
        private readonly IFrameworkService frameworkService;

        public CaptchaController(IClientService clientService,
            IFrameworkService frameworkService)
        {
            this.frameworkService = frameworkService;
            this.clientService = clientService;
        }

        [HttpGet]
        public HttpResponseMessage GetFramework(string language)
        {
            Stream stream = frameworkService.GetJavascript(language);
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(stream)
            };

            response.Content.Headers.ContentType = 
                new MediaTypeHeaderValue("application/javascript");

            return response;
        }

        [HttpPost]
        public IHttpActionResult Verify(string privateKey, string secret)
        {
            var response = clientService.Verify(privateKey, secret);
            return Json(response);
        }
    }
}
