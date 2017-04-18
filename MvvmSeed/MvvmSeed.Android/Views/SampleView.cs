using Android.App;
using MvvmCross.Droid.Views;

namespace MvvmSeed.Android.Views
{
    [Activity]
    public class SampleView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.View_Sample);
        }
    }
}