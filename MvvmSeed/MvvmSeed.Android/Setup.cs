using Android.Content;
using Autofac;
using Autofac.Extras.MvvmCross;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Shared.Presenter;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmSeed.Android.Views;
using MvvmSeed.Application;
using MvvmSeed.Application.Modules;
using MvvmSeed.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace MvvmSeed.Android
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext) { }

        protected override IMvxApplication CreateApp() => new App();

        protected override IMvxIoCProvider CreateIocProvider()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<ApplicationModule>();
            containerBuilder.Register(c => Environment.GetFolderPath(Environment.SpecialFolder.Personal)).Named<string>(App.BootstrapParamaters.LocalAppDataFolder);
            return new AutofacMvxIocProvider(containerBuilder.Build());
        }

        protected override void InitializeViewLookup()
        {
            // ViewModel->View relations
            // Used by MvvmCross framework to automatically resolve ShowViewModel<TViewModel> into a view
            // MvvmCross by default uses naming convention, but this approach provides flexibility (we can still rely on naming conventions if we want to and override only when required)
            var viewModelToViewMapping = new Dictionary<Type, Type>
            {
                { typeof(SplashViewModel), typeof(SplashView)},
                { typeof(SampleViewModel), typeof(SampleView)},
            };
            var container = Mvx.Resolve<IMvxViewsContainer>();
            container.AddAll(viewModelToViewMapping);
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var mvxFragmentsPresenter = new MvxFragmentsPresenter(AndroidViewAssemblies);
            Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(mvxFragmentsPresenter);
            return mvxFragmentsPresenter;
        }
    }
}