using System.Collections.Generic;
using System.Web.Http;
using CustomReCaptcha.Helpers;
using CustomReCaptcha.Helpers.Interfaces;
using CustomReCaptcha.Services;
using CustomReCaptcha.Services.DistortionAlgorithms;
using CustomReCaptcha.Services.Interfaces;
using CustomReCaptcha.Services.PuzzleAlgorithms;
using Unity;
using Unity.Lifetime;

namespace CustomReCaptcha.App_Start
{
    public class UnityConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterSingleton<IClientService, ClientService>();
            container.RegisterSingleton<IStringHelper, StringHelper>();
            container.RegisterType<IImageService, ImageService>(new HierarchicalLifetimeManager());
            container.RegisterType<IFrameworkService, FrameworkService>(new HierarchicalLifetimeManager());
            container.RegisterType<IImageService, ImageService>(new HierarchicalLifetimeManager());
            container.RegisterType<IAudioService, AudioService>(new HierarchicalLifetimeManager());
            container.RegisterType<IVerificationService, VerificationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IHostingHelper, HostingHelper>(new HierarchicalLifetimeManager());
            container.RegisterType<IAppSettingsHelper, AppSettingsHelper>(new HierarchicalLifetimeManager());

            // Distortions
            container.RegisterType<IDistortionAlgorithm, EmptyDistortion>("1");

            // Puzzles
            container.RegisterType<IPuzzleAlgorithm, SimplePuzzle>("1");

            config.DependencyResolver = new UnityResolver(container);

            // Other Web API configuration not shown.
        }
    }
}