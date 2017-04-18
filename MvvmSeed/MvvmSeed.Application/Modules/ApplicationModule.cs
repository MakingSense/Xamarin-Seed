using Autofac;
using MvvmCross.Core.ViewModels;
using MvvmSeed.Application.Initializers;
using MvvmSeed.Application.ViewModels;
using MvvmSeed.Application.ViewModels.Interfaces;
using MvvmSeed.Domain.Model;
using MvvmSeed.Domain.Services;

namespace MvvmSeed.Application.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder cb)
        {
            cb.Register(c => c.Resolve<SplashViewModel>()).As<IMvxAppStart>().SingleInstance();
            cb.Register(c => new ApplicationInitializer(c.Resolve<LocalStorageContext>())).As<IApplicationInitializer>();

            cb.Register(c => new LocalStorageContext(c.ResolveNamed<string>(App.BootstrapParamaters.LocalAppDataFolder))).As<LocalStorageContext>().SingleInstance();
            cb.Register(c => new StringRandomizerService(c.Resolve<LocalStorageContext>())).As<IStringRandomizerService>().SingleInstance();

            cb.Register(c => new SplashViewModel(c.Resolve<IApplicationInitializer>())).As<SplashViewModel>();
            cb.Register(c => new SampleViewModel(c.Resolve<IStringRandomizerService>())).As<ISampleViewModel>();
        }
    }

    
}
