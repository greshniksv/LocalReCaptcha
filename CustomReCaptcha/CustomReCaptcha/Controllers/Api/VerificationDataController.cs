using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using CustomReCaptcha.Models.Enums;
using CustomReCaptcha.Services.Interfaces;

namespace CustomReCaptcha.Controllers.Api
{
    public class VerificationDataController : ApiController
    {
        private readonly IVerificationService verificationService;

        public VerificationDataController(IVerificationService verificationService)
        {
            this.verificationService = verificationService;
        }

        [HttpGet]
        public HttpResponseMessage Get(string clientKey, string instance, 
            ValidationType type, string lang, string t)
        {
            var model = verificationService.Get(clientKey, instance, type, lang);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(model.Stream)
            };

            result.Content.Headers.ContentDisposition = 
                new ContentDispositionHeaderValue("attachment")
            {
                FileName = model.FileName
            };

            result.Content.Headers.ContentType = 
                new MediaTypeHeaderValue(model.ContentType);
            result.Content.Headers.ContentLength = model.Stream.Length;
            return result;
        }

        [HttpPost]
        public IHttpActionResult Reset(string clientKey, string instance)
        {
            try
            {
                verificationService.Reset(clientKey, instance);
                return Json(new { success = true });
            }
            catch (Exception e)
            {
                return Json(new { success = false, data = e.Message });
            }
        }
    }
}