using Android.App;
using Android.Content.PM;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;

namespace MvvmSeed.Android.Views
{
    [Activity(MainLauncher = true, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait, Theme = "@style/Theme.Splash")]
    public class SplashView : MvxSplashScreenActivity
    {
        public SplashView() : base(Resource.Layout.View_Splash) { }

        protected override void TriggerFirstNavigate()
        {
            Mvx.Resolve<IMvxAppStart>().Start();
        }
    }
}