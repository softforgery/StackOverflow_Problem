using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Camera_sample.Core;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using System.Linq;
using ZXing.Mobile;

namespace Camera_sample
{
    [MvxActivityPresentation]
    [Activity(
       MainLauncher = true,
       Icon = "@mipmap/ic_launcher",
       Theme = "@style/AppTheme",
       NoHistory = true,
       ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen:MvxSplashScreenActivity<Setup, App>
    {
        public SplashScreen()
           : base(Resource.Layout.SplashScreen)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            MobileBarcodeScanner.Initialize(Application);

            if (!IsTaskRoot)
                Finish();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            //global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            //Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnStart()
        {
            base.OnStart();

            // only need to check permissions for marshmallow and later
            if (Build.VERSION.SdkInt < BuildVersionCodes.M)
                return;

            string[] permissionsToCheck =
            {
                Manifest.Permission.AccessCoarseLocation,
                Manifest.Permission.AccessFineLocation,
                Manifest.Permission.Camera,
                Manifest.Permission.AccessNetworkState,
                Manifest.Permission.AccessWifiState,
                Manifest.Permission.Flashlight,
                Manifest.Permission.ReadPhoneState,
                Manifest.Permission.WriteExternalStorage,
                Manifest.Permission.ReadExternalStorage
            };

            var permissionsToGrant = permissionsToCheck.Where(permission =>
                ContextCompat.CheckSelfPermission(this, permission) != Permission.Granted).ToList();

            if (!permissionsToGrant.Any())
                return;

            ActivityCompat.RequestPermissions(this, permissionsToGrant.ToArray(), 0);
        }
    }
}