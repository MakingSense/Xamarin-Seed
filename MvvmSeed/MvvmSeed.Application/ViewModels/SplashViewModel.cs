using MvvmCross.Core.ViewModels;
using MvvmSeed.Application.Initializers;

namespace MvvmSeed.Application.ViewModels
{
    public class SplashViewModel : MvxViewModel, IMvxAppStart
    {
        private readonly IApplicationInitializer _appInitializer;

        public SplashViewModel(IApplicationInitializer appInitializer)
        {
            _appInitializer = appInitializer;
        }

        public void Start(object hint = null)
        {
            _appInitializer.PostBootsrapInitializationAsync().ContinueWith(cf => ShowViewModel<SampleViewModel>());
        }
    }
}
