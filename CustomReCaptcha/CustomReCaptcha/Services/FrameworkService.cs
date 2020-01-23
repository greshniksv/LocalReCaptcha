using System.IO;
using System.Text;
using CustomReCaptcha.Helpers.Interfaces;
using CustomReCaptcha.Services.Interfaces;

namespace CustomReCaptcha.Services
{
    public class FrameworkService : IFrameworkService
    {
        private readonly IHostingHelper hostingHelper;
        private readonly IAppSettingsHelper appSettingsHelper;

        public FrameworkService(IHostingHelper hostingHelper, IAppSettingsHelper appSettingsHelper)
        {
            this.hostingHelper = hostingHelper;
            this.appSettingsHelper = appSettingsHelper;
        }

        public Stream GetJavascript(string lang)
        {
            var memoryStream = new MemoryStream();
            var baseUrl = appSettingsHelper.Get("BaseUrl");

            var path = hostingHelper.GetRootPath();
            var langPath = Path.Combine(path,
                $"App_Data\\Framework\\Languages\\{lang}.js");

            if (!File.Exists(langPath))
            {
                langPath = Path.Combine(path,
                    "App_Data\\Framework\\Languages\\en.js");
            }

            TextWriter writer = new StreamWriter(memoryStream, Encoding.UTF8);
            using (TextReader reader = new StreamReader(
                Path.Combine(path, "App_Data\\Framework\\framework.js"), Encoding.UTF8))
            {
                string buf;
                while ((buf = reader.ReadLine()) != null)
                {
                    if (buf.Contains("//#BaseUrl"))
                    {
                        buf = $"    var baseUrl = '{baseUrl}';";
                    }

                    if (buf.Contains("//#LanguageKey"))
                    {
                        buf = $"    var languageKey = '{lang}';";
                    }

                    if (buf.Contains("//#LanguageData"))
                    {
                        using (TextReader reader2 = new StreamReader(langPath, Encoding.UTF8))
                        {
                            string buf2;
                            while ((buf2 = reader2.ReadLine()) != null)
                            {
                                writer.WriteLine(buf2);
                            }
                        }

                        buf = string.Empty;
                    }

                    writer.WriteLine(buf);
                }
            }

            writer.Flush();

            // Apply obfuscation algorithm

            memoryStream.Position = 0;
            return memoryStream;
        }
    }
}