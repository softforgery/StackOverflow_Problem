using Android.App;
using Android.Content.PM;
using Android.OS;
using Camera_sample.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Core;

namespace Camera_sample.Views
{
    [Activity(
      ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize,
      Label = "Problem test",
      LaunchMode = LaunchMode.SingleInstance,
      Theme = "@style/AppTheme",
      ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : MvxAppCompatActivity<MainViewModel>
    {

        protected override void OnCreate(Bundle bundle)
        {
            var setup = MvxAndroidSetupSingleton.EnsureSingletonAvailable(ApplicationContext);
            setup.EnsureInitialized();

            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_main);
        }
    }

}