using Camera_sample.Core;
using Camera_sample.Core.Services;
using MvvmCross;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Binding.Views;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Presenters;
using System.Collections.Generic;
using System.Reflection;

namespace Camera_sample
{
    public class Setup : MvxAndroidSetup<App>
    {
        protected override void InitializeIoC()
        {
            base.InitializeIoC();

            Mvx.IoCProvider.RegisterType<IBarcodeService, BarcodeService>();
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            return new MvxAppCompatViewPresenter(AndroidViewAssemblies);
        }


        protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>(base.AndroidViewAssemblies)
        {
            typeof(Android.Support.Design.Widget.CoordinatorLayout).Assembly,
            typeof(Android.Support.Design.Widget.FloatingActionButton).Assembly,
            typeof(Android.Support.Design.Widget.NavigationView).Assembly,
            typeof(Android.Support.V4.Widget.DrawerLayout).Assembly,
            typeof(Android.Support.V4.View.ViewPager).Assembly,
            typeof(Android.Support.V7.Widget.AppCompatCheckBox).Assembly,
            typeof(Android.Support.V7.Widget.Toolbar).Assembly,            
            typeof(MvxListView).Assembly
        };
    }
}