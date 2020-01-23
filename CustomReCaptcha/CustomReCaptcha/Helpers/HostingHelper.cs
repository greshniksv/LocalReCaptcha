using System.IO;
using System.Web;
using CustomReCaptcha.Helpers.Interfaces;

namespace CustomReCaptcha.Helpers
{
    public class HostingHelper: IHostingHelper
    {
        public string GetRootPath(string additional = null)
        {
            if (string.IsNullOrEmpty(additional))
            {
                return HttpRuntime.AppDomainAppPath;
            }

            return Path.Combine(HttpRuntime.AppDomainAppPath, additional);
        }
    }
}